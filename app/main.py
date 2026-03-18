from fastapi import FastAPI
from app.routes.clustering import router

app = FastAPI(
    title="WarSafe AI Service",
    version="1.0.0"
)

app.include_router(router, prefix="/cluster", tags=["Clustering"])

@app.get("/")
def root():
    return {"message": "WarSafe AI Service Running"}
