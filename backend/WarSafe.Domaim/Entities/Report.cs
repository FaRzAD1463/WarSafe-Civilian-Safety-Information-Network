namespace WarSafe.Domain.Entities;

public class Report
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Urgency { get; set; }
    public DateTime CreatedAt { get; set; }
}