from app.services.clustering_service import ClusteringService

class DummyPoint:
    def __init__(self, lat, lng):
        self.latitude = lat
        self.longitude = lng

def test_cluster():
    points = [
        DummyPoint(31.5, 34.4),
        DummyPoint(31.5001, 34.4001),
        DummyPoint(40.0, 50.0),
    ]

    clusters = ClusteringService.run(points)
    assert isinstance(clusters, dict)
