from fastapi import FastAPI, UploadFile, File, BackgroundTasks
from fastapi.responses import FileResponse
from pathlib import Path
import uuid

from .pipeline import generate_model

app = FastAPI()

UPLOAD_DIR = Path("/tmp/uploads")
MODEL_DIR = Path("/tmp/models")
UPLOAD_DIR.mkdir(parents=True, exist_ok=True)
MODEL_DIR.mkdir(parents=True, exist_ok=True)


def process_image(image_id: str, temp_path: Path):
    model_path = generate_model(temp_path, MODEL_DIR)
    final_path = MODEL_DIR / f"{image_id}.glb"
    model_path.rename(final_path)


@app.post("/upload")
async def upload_image(image: UploadFile = File(...), background_tasks: BackgroundTasks = None):
    image_id = str(uuid.uuid4())
    temp_path = UPLOAD_DIR / f"{image_id}_{image.filename}"
    with temp_path.open("wb") as f:
        f.write(await image.read())
    if background_tasks is not None:
        background_tasks.add_task(process_image, image_id, temp_path)
    else:
        process_image(image_id, temp_path)
    return {"id": image_id}


@app.get("/model/{image_id}")
async def get_model(image_id: str):
    model_path = MODEL_DIR / f"{image_id}.glb"
    if model_path.exists():
        return FileResponse(model_path)
    return {"status": "processing"}
