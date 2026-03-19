import 'package:flutter/material.dart';
import 'package:camera/camera.dart';
import 'media_service.dart';

class RecordScreen extends StatefulWidget {
  const RecordScreen({super.key});

  @override
  State<RecordScreen> createState() => _RecordScreenState();
}

class _RecordScreenState extends State<RecordScreen> {
  CameraController? controller;
  bool isRecording = false;

  @override
  void initState() {
    super.initState();
    initCamera();
  }

  Future<void> initCamera() async {
    final cameras = await availableCameras();
    controller = CameraController(cameras[0], ResolutionPreset.medium);
    await controller!.initialize();
    setState(() {});
  }

  Future<void> record() async {
    if (!isRecording) {
      await controller!.startVideoRecording();
      setState(() => isRecording = true);
    } else {
      final file = await controller!.stopVideoRecording();
      setState(() => isRecording = false);

      await MediaService.saveVideo(file.path);

      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("Saved locally")),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    if (controller == null || !controller!.value.isInitialized) {
      return const Scaffold(body: Center(child: CircularProgressIndicator()));
    }

    return Scaffold(
      appBar: AppBar(title: const Text("Record")),
      body: Column(
        children: [
          Expanded(child: CameraPreview(controller!)),
          ElevatedButton(
            onPressed: record,
            child: Text(isRecording ? "Stop" : "Record"),
          )
        ],
      ),
    );
  }
}