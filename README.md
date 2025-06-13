# MirrorWorld Example

This repository contains a minimal scaffold for the MirrorWorld project. It demonstrates how a photo could be uploaded to a FastAPI backend which, after processing, returns a generated 3D model for rendering inside a Unity scene.

## Running the Backend

```bash
pip install -r backend/requirements.txt
uvicorn backend.app.main:app --reload
```

The upload endpoint (`/upload`) accepts an image. After processing, retrieve the model from `/model/{id}`.

## Frontend and Unity

- **SwiftUI** code is located in `frontend/` and handles image selection and uploading.
- **Unity** scripts in `unity/` show how to download and load the generated model at runtime.

All components are placeholders meant to be extended with real ML and rendering logic.
