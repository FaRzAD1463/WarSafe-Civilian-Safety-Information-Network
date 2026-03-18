import 'package:flutter/material.dart';
import '../../core/services/api_service.dart';

class ShelterScreen extends StatefulWidget {
  const ShelterScreen({super.key});

  @override
  State<ShelterScreen> createState() => _ShelterState();
}

class _ShelterState extends State<ShelterScreen> {
  List shelters = [];

  @override
  void initState() {
    super.initState();
    load();
  }

  void load() async {
    final data = await ApiService.get("shelters");
    setState(() => shelters = data);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Shelters")),
      body: ListView.builder(
        itemCount: shelters.length,
        itemBuilder: (_, i) => ListTile(
          title: Text(shelters[i]["name"]),
        ),
      ),
    );
  }
}
