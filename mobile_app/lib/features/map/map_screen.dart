import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class MapScreen extends StatefulWidget {
  @override
  _MapScreenState createState() => _MapScreenState();
}

class _MapScreenState extends State<MapScreen> {
  static const LatLng center = LatLng(31.5, 34.4);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("WarSafe Map")),
      body: GoogleMap(
        initialCameraPosition: CameraPosition(
          target: center,
          zoom: 10,
        ),
      ),
    );
  }
}