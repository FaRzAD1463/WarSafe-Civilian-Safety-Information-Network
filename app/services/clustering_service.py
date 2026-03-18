from sklearn.cluster import DBSCAN
from app.core.config import settings
from app.utils.preprocessing import to_numpy

class ClusteringService:

    @staticmethod
    def run(points):
        coords = to_numpy(points)

        model = DBSCAN(
            eps=settings.EPS,
            min_samples=settings.MIN_SAMPLES
        )

        labels = model.fit_predict(coords)

        clusters = {}

        for i, label in enumerate(labels):
            if label == -1:
                continue

            clusters.setdefault(int(label), []).append({
                "lat": float(coords[i][0]),
                "lng": float(coords[i][1])
            })

        return clusters
