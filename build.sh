#!/bin/bash
# Simple Unity build script
# Set UNITY_PATH to your local Unity executable if not already defined
UNITY_PATH="${UNITY_PATH:-/Applications/Unity/Hub/Editor/2021.3.0f1/Unity.app/Contents/MacOS/Unity}"
PROJECT_PATH="$(pwd)"
OUTPUT_PATH="$PROJECT_PATH/Builds"

mkdir -p "$OUTPUT_PATH"
"$UNITY_PATH" -batchmode -nographics -quit -projectPath "$PROJECT_PATH" -buildWindows64Player "$OUTPUT_PATH/VRExperience.exe"

