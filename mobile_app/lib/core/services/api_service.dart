import 'dart:convert';
import 'package:http/http.dart' as http;

class ApiService {
  final String baseUrl = "http://10.0.2.2:5000/api";

  Future<List<dynamic>> getReports() async {
    final res = await http.get(Uri.parse("$baseUrl/reports"));
    return jsonDecode(res.body);
  }

  Future<void> createReport(Map data) async {
    await http.post(
      Uri.parse("$baseUrl/reports"),
      headers: {"Content-Type": "application/json"},
      body: jsonEncode(data),
    );
  }

  Future<String> login(String email, String password) async {
    final res = await http.post(
      Uri.parse("$baseUrl/auth/login"),
      headers: {"Content-Type": "application/json"},
      body: jsonEncode({"email": email, "password": password}),
    );

    return res.body;
  }
}