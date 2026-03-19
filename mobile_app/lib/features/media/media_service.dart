import 'dart:io';
import 'package:path_provider/path_provider.dart';
import 'upload_queue.dart';

class MediaService {
  static Future<void> saveVideo(String tempPath) async {
    final dir = await getApplicationDocumentsDirectory();
    final fileName = DateTime.now().millisecondsSinceEpoch.toString();

    final savedPath = "${dir.path}/$fileName.mp4";

    final file = await File(tempPath).copy(savedPath);

    await UploadQueue.add(file.path);
  }
}