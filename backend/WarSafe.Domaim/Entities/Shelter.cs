namespace WarSafe.Domain.Entities;

public class Shelter
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int Capacity { get; set; }
}
