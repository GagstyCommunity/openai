from pathlib import Path
import time


def generate_model(image_path: Path, output_dir: Path) -> Path:
    """Placeholder image-to-3D pipeline."""
    output_dir.mkdir(parents=True, exist_ok=True)
    model_path = output_dir / f"{image_path.stem}.glb"
    # Simulate processing time
    time.sleep(0.1)
    with model_path.open("wb") as f:
        # Write dummy data to represent a GLB file
        f.write(b"glTF")
    return model_path
