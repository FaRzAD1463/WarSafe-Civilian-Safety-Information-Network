from fastapi import APIRouter
from app.schemas.report_schema import ClusterRequest, ClusterResponse
from app.services.clustering_service import ClusteringService

router = APIRouter()

@router.post("/", response_model=ClusterResponse)
def cluster(data: ClusterRequest):
    clusters = ClusteringService.run(data.points)
    return {"clusters": clusters}
