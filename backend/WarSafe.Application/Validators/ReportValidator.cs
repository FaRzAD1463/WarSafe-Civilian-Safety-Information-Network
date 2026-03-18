using WarSafe.Domain.Entities;

public class ReportValidator
{
    public static void Validate(Report report)
    {
        if (string.IsNullOrEmpty(report.Type))
            throw new Exception("Type is required");

        if (report.Latitude == 0 || report.Longitude == 0)
            throw new Exception("Invalid location");
    }
}
