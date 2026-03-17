from fastapi import APIRouter
from sklearn.cluster import DBSCAN
import numpy as np

router = APIRouter()

@router.post("/")
def cluster(data: list):
    coords = np.array(data)
    labels = DBSCAN(eps=0.01).fit_predict(coords)
    return {"clusters": labels.tolist()}