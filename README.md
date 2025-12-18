🧠 DeepSeek-Based AI NPC in Unity

A real-time AI-driven NPC system built in Unity that generates intelligent, context-aware responses based on human interaction.
The NPC’s personality, behavior, and scene context can be customized dynamically, making it suitable for games, simulations, XR experiences, and interactive storytelling.


🚀 Project Overview

This project demonstrates an AI-powered NPC that:

Responds in real time using the DeepSeek language model

Adapts its responses based on:

  Scene description

  Environment context
  
  Custom personality traits

  Uses real-time lip synchronization for immersive interaction

  Can be easily customized and extended for different use cases

The system is fully integrated inside Unity, allowing developers to modify NPC behavior directly from the editor.



🛠️ Tech Stack

  Unity: 2022.3.50f1 (LTS)

  AI Model: DeepSeek (via OpenRouter API)

  Lip Sync: OVR Lip Sync SDK

  Character Creation: Ready Player Me

  Interaction / Intent Handling: Wit.ai

  Language: C#



✨ Key Features

  🔹 Real-time AI dialogue generation

  🔹 Customizable NPC personality and behavior

  🔹 Scene-aware responses

  🔹 Real-time lip sync for speech

  🔹 Modular and extensible Unity setup

  🔹 Ready Player Me character integration

  🔹 OpenRouter support for DeepSeek API

  

▶️ How to Run the Project Locally
1️⃣ Clone the Repository
git clone https://github.com/Lucky1403/Deepseek-NPC.git

2️⃣ Open in Unity

Open Unity Hub

Select Unity 2022.3.50f1

Open the cloned project

3️⃣ Get DeepSeek API Key (via OpenRouter)

Go to: https://openrouter.ai

Create an account

Generate a DeepSeek API key

4️⃣ Configure the API Key in Unity

In Unity, locate:

Assets → DeepSeek → DeepSeekAPI.asset


Paste your OpenRouter DeepSeek API key

Save the asset

5️⃣ Customize NPC Personality & Scene

Select the NPC GameObject

Locate the DeepSeek Manager component

Modify:

Scene Description

Personality Description

These parameters directly affect NPC responses

6️⃣ Play the Scene

Press ▶ Play

Interact with the NPC and observe:

Real-time dialogue

Lip-synced facial animation

Context-aware responses

🎭 Character & Lip Sync Setup

Characters are created using Ready Player Me

Facial blendshapes are applied to:

Wolf3D_Head (SkinnedMeshRenderer)


OVR Lip Sync Context Morph Target is attached only to the head mesh

🧩 Base Project Reference & Credits

This project is built upon the following open-source implementation:

🔗 DeepSeek Unity Integration (Base Project):
https://github.com/yagizeraslan/DeepSeek-Unity

Modifications Made:

Replaced official DeepSeek API with OpenRouter API

Extended functionality for:

Custom personality control

Scene-based response generation

NPC-focused interaction workflow

Integrated lip sync and Ready Player Me characters

Full credit to the original author for the initial DeepSeek–Unity setup.




📌 Use Cases

🎮 AI-driven NPCs in games

🧪 Simulations and training environments

🥽 XR / VR / AR applications

📖 Interactive storytelling

🗣️ Conversational agents in Unity
