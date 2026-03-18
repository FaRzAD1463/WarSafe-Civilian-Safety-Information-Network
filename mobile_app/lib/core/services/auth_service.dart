import 'api_service.dart';

class AuthService {
  static Future<String> login(String email, String password) async {
    final res = await ApiService.post("auth/login", {
      "email": email,
      "password": password
    });

    return res;
  }
}
