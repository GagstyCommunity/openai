# Therapeutic VR Experience

This project is a prototype for an immersive VR application focused on emotional healing. It leverages Unity to integrate 3D environments, user interfaces, and AI-driven interactions. It includes an inner child avatar system for expressive emotional feedback.

## Project Setup
1. **Requirements**
   - Unity 2021.3 or newer.
   - VR headset compatible with your development machine.
2. **Getting Started**
   - Clone this repository.
   - Open the project with Unity Hub or the Unity Editor.
   - Import your preferred VR SDK (e.g., Oculus or OpenXR) if not already installed.
   - Create `Assets/Resources` if it doesn't exist and add any avatar models.

## Repository Structure
- `Assets/` – Main Unity assets, scripts, and models.
- `ProjectSettings/` – Unity project configuration files.
- `LICENSE` – GPL-3.0 license for this repository.

## Inner Child Avatar
The `InnerChildAvatar` component uses blendshapes and animations to express
four emotional states. You can drive the avatar with an `EmotionVariable`
ScriptableObject or by calling `SetEmotion` at runtime. The accompanying
editor script adds an **Auto Assign Blendshapes** button that attempts to
bind the `SkinnedMeshRenderer` and checks for required blendshapes.

## Building
Run `./build.sh` to create a standalone build. Override the `UNITY_PATH`
environment variable if Unity is installed in a custom location.

## License
This project is licensed under the [GNU GPLv3](LICENSE). You are free to modify and distribute the code under the same license terms.

