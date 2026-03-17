class Report {
  final String type;
  final String description;
  final double lat;
  final double lng;

  Report({
    required this.type,
    required this.description,
    required this.lat,
    required this.lng,
  });

  factory Report.fromJson(Map json) {
    return Report(
      type: json['type'],
      description: json['description'],
      lat: json['latitude'],
      lng: json['longitude'],
    );
  }
}