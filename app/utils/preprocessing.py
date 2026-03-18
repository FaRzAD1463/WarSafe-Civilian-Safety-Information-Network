import numpy as np

def to_numpy(points):
    return np.array([[p.latitude, p.longitude] for p in points])
