# WarSafe AI Service

## Run locally
uvicorn app.main:app --reload

## API
POST /cluster

Body:
{
  "points": [
    {"latitude": 31.5, "longitude": 34.4}
  ]
}
