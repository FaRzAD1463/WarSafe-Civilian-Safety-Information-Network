import 'package:flutter/material.dart';
import '../../core/services/api_service.dart';
import '../reports/report_screen.dart';

class LoginScreen extends StatefulWidget {
  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final api = ApiService();
  final email = TextEditingController();
  final password = TextEditingController();

  void login() async {
    await api.login(email.text, password.text);

    Navigator.push(
      context,
      MaterialPageRoute(builder: (_) => ReportScreen()),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("WarSafe Login")),
      body: Padding(
        padding: EdgeInsets.all(16),
        child: Column(
          children: [
            TextField(controller: email, decoration: InputDecoration(labelText: "Email")),
            TextField(controller: password, decoration: InputDecoration(labelText: "Password")),
            SizedBox(height: 20),
            ElevatedButton(onPressed: login, child: Text("Login"))
          ],
        ),
      ),
    );
  }
}