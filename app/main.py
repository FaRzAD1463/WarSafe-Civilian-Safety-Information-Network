from fastapi import FastAPI
from sklearn.cluster import DBSCAN
from app.routes.clustering import router
import numpy as np

app = FastAPI()
app.include_router(router, prefix="/cluster")

@app.post("/cluster")
def cluster(data: list):
    coords = np.array(data)

    model = DBSCAN(eps=0.01, min_samples=2)
    labels = model.fit_predict(coords)

    return {"clusters": labels.tolist()}