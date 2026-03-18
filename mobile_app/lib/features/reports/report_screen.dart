import 'package:flutter/material.dart';
import '../../core/services/api_service.dart';
import 'report_model.dart';

class ReportScreen extends StatefulWidget {
  const ReportScreen({super.key});

  @override
  State<ReportScreen> createState() => _ReportState();
}

class _ReportState extends State<ReportScreen> {
  final desc = TextEditingController();

  void submit() async {
    final report = Report(
      type: "incident",
      description: desc.text,
      lat: 23.8,
      lng: 90.4,
    );

    await ApiService.post("reports", report.toJson());

    ScaffoldMessenger.of(context)
        .showSnackBar(const SnackBar(content: Text("Reported")));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Report")),
      body: Column(
        children: [
          TextField(controller: desc),
          ElevatedButton(onPressed: submit, child: const Text("Send"))
        ],
      ),
    );
  }
}
