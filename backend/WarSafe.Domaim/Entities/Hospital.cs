namespace WarSafe.Domain.Entities;

public class Hospital
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int BedsAvailable { get; set; }
}
