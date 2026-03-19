import 'dart:convert';
import 'dart:io';
import 'package:shared_preferences/shared_preferences.dart';
import '../../core/services/api_service.dart';
import '../../core/services/network_service.dart';

class UploadQueue {
  static const String key = "upload_queue";

  static Future<void> add(String path) async {
    final prefs = await SharedPreferences.getInstance();
    final list = prefs.getStringList(key) ?? [];
    list.add(path);
    await prefs.setStringList(key, list);
  }

  static Future<void> processQueue() async {
    if (!await NetworkService.isOnline()) return;

    final prefs = await SharedPreferences.getInstance();
    final list = prefs.getStringList(key) ?? [];

    final List<String> remaining = [];

    for (var path in list) {
      try {
        final file = File(path);

        var request = await ApiService.multipart(
          "media/upload",
          file,
        );

      } catch (e) {
        remaining.add(path);
      }
    }

    await prefs.setStringList(key, remaining);
  }
}