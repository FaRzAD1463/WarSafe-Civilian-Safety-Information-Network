import 'package:flutter/material.dart';
import 'features/auth/login_screen.dart';

void main() {
  runApp(WarSafeApp());
}

class WarSafeApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'WarSafe',
      debugShowCheckedModeBanner: false,
      home: LoginScreen(),
    );
  }
}