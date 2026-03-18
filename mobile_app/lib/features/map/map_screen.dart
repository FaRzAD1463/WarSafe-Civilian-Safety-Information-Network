import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import '../../core/services/api_service.dart';

class MapScreen extends StatefulWidget {
  const MapScreen({super.key});

  @override
  State<MapScreen> createState() => _MapState();
}

class _MapState extends State<MapScreen> {
  Set<Marker> markers = {};

  @override
  void initState() {
    super.initState();
    loadReports();
  }

  Future<void> loadReports() async {
    final data = await ApiService.get("reports");

    final Set<Marker> loadedMarkers = {};

    for (var r in data) {
      loadedMarkers.add(
        Marker(
          markerId: MarkerId(r["id"]),
          position: LatLng(r["latitude"], r["longitude"]),
          infoWindow: InfoWindow(title: r["type"]),
        ),
      );
    }

    setState(() {
      markers = loadedMarkers;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("WarSafe Map")),
      body: GoogleMap(
        initialCameraPosition: const CameraPosition(
          target: LatLng(23.8103, 90.4125),
          zoom: 12,
        ),
        markers: markers,
      ),
    );
  }
}
