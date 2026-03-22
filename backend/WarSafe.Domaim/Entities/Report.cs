namespace WarSafe.Domain.Entities;
using WarSafe.Domain.Enums;
public class Report
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public ReportStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
