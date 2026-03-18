namespace WarSafe.Domain.Entities;

using WarSafe.Domain.Enums;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public Role Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
