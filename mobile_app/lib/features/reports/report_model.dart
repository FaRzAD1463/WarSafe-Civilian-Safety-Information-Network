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

  Map<String, dynamic> toJson() => {
        "type": type,
        "description": description,
        "latitude": lat,
        "longitude": lng,
      };
}
