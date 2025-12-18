using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using YagizEraslan.DeepSeek.Unity;
using Oculus.Voice.Dictation;
using Unity.VisualScripting;
using UnityEngine.Video;
public class DeepSeekNPCManager : MonoBehaviour
{
    [TextArea(5, 20)]
    public string Personality;
    [TextArea(5, 20)]
    public string scene;
    public int maxResponseWordLimit = 50;

    public OnResponseEvent OnResponse;

    public List<NPCAction> actions;
    public AppDictationExperience voiceToText;

    [System.Serializable]
    public struct NPCAction
    {
        public string actionKeyword;
        [TextArea(2, 5)]
        public string actionDescription;
        public UnityEvent actionEvent;
    }

    [Serializable]
    public class OnResponseEvent : UnityEvent<string> { }

    [Header("DeepSeek Configuration")]
    [SerializeField]
    private DeepSeekSettings deepSeekSettings;
    [SerializeField]
    private string openRouterModelId = "deepseek/deepseek-chat";

    [SerializeField]
    private bool useStreaming = false;

    private DeepSeekChatController deepSeekController;
    private bool controllerInitialized = false;

    private readonly List<ChatMessage> messages = new List<ChatMessage>();

    private void Start()
    {
        InitializeController();
        voiceToText.DictationEvents.OnFullTranscription.AddListener(AskDeepSeek);
    }

    private void InitializeController()
    {
        if (!controllerInitialized)
        {
            deepSeekController = new DeepSeekChatController(
                new DeepSeekApi(deepSeekSettings),
                openRouterModelId,
                OnNewMessageReceived,
                OnStreamingMessageReceived,
                useStreaming
            );

            controllerInitialized = true;
        }
    }

    private void OnNewMessageReceived(ChatMessage message, bool isUser)
    {
        if (isUser)
        {
            messages.Add(message);
        }
        else
        {
            string content = message.content;

            foreach (var item in actions)
            {
                if (content.Contains(item.actionKeyword))
                {
                    content = content.Replace(item.actionKeyword, "");
                    item.actionEvent.Invoke();
                }
            }

            var aiMessage = new ChatMessage
            {
                content = content,
                role = "assistant"
            };
            messages.Add(aiMessage);

            Debug.Log($"DeepSeek AI Response: {content}");
            OnResponse.Invoke(content);
        }
    }

    private void OnStreamingMessageReceived(string partialContent)
    {
        Debug.Log($"Streaming partial response: {partialContent}");
    }

    public string GetInstructions()
    {
        string instructions = "You are a video game character responding only based on your personality and the scene context.\n" +
        "You must reply to the player message only using the information from your personality and the Scene that are provided afterwards.\n" +
        "Do not invent or create response that are not mentioned in these informations.\n" +
        "Do not break character or mention you are an AI or a video game character.\n" +
            $"You must answer in less than {maxResponseWordLimit} words.\n" +
            "Here is the information about your personality:\n" + Personality + "\n" +
            "Here is the information about the Scene around you :\n" + scene + "\n" +
            BuildActionInstructions() +
            "Here is the message of the player :\n";

        return instructions;
    }

    public string BuildActionInstructions()
    {
        string instructions = "";
        foreach (var action in actions)
        {
            instructions += $"If the player implies {action.actionDescription}, add the keyword {action.actionKeyword} to your response.\n";
        }
        return instructions;
    }

    public void AskDeepSeek(string playerMessage)
    {
        if (!controllerInitialized)
            InitializeController();

        string prompt = GetInstructions() + playerMessage;

        deepSeekController.SendUserMessage(prompt);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            voiceToText.Activate();
        }
    }
}
