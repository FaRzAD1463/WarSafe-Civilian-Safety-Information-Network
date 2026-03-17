import 'package:flutter/material.dart';
import '../../core/services/api_service.dart';
import 'report_model.dart';

class ReportScreen extends StatefulWidget {
  @override
  _ReportScreenState createState() => _ReportScreenState();
}

class _ReportScreenState extends State<ReportScreen> {
  final api = ApiService();
  List<Report> reports = [];

  @override
  void initState() {
    super.initState();
    loadReports();
  }

  void loadReports() async {
    final data = await api.getReports();
    setState(() {
      reports = data.map((e) => Report.fromJson(e)).toList();
    });
  }

  void sendReport() async {
    await api.createReport({
      "type": "danger",
      "description": "Explosion nearby",
      "latitude": 31.5,
      "longitude": 34.4,
      "urgency": "high"
    });

    loadReports();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Reports"),
        actions: [
          IconButton(onPressed: sendReport, icon: Icon(Icons.add))
        ],
      ),
      body: ListView.builder(
        itemCount: reports.length,
        itemBuilder: (_, i) {
          return ListTile(
            title: Text(reports[i].type),
            subtitle: Text(reports[i].description),
          );
        },
      ),
    );
  }
}