import 'dart:convert';
import 'package:http/http.dart' as http;

class ApiService {
  static const String baseUrl = "http://10.0.2.2:5000/api";

  static Future<dynamic> get(String endpoint) async {
    final res = await http.get(Uri.parse("$baseUrl/$endpoint"));

    if (res.statusCode == 200) {
      return jsonDecode(res.body);
    } else {
      throw Exception("API Error");
    }
  }

  static Future<dynamic> post(String endpoint, Map data) async {
    final res = await http.post(
      Uri.parse("$baseUrl/$endpoint"),
      headers: {"Content-Type": "application/json"},
      body: jsonEncode(data),
    );

    if (res.statusCode == 200) {
      return jsonDecode(res.body);
    } else {
      throw Exception("API Error");
    }
  }
}
