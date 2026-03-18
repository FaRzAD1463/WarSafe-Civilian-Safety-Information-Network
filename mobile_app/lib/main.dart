import 'package:flutter/material.dart';
import 'features/map/map_screen.dart';

void main() {
  runApp(const WarSafeApp());
}

class WarSafeApp extends StatelessWidget {
  const WarSafeApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'WarSafe',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(primarySwatch: Colors.red),
      home: const MapScreen(),
    );
  }
}


