namespace WarSafe.Domain.Entities;

public class Alert
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Severity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
