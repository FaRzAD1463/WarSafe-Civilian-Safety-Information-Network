from pydantic import BaseModel
from typing import List

class Coordinate(BaseModel):
    latitude: float
    longitude: float

class ClusterRequest(BaseModel):
    points: List[Coordinate]

class ClusterResponse(BaseModel):
    clusters: dict
