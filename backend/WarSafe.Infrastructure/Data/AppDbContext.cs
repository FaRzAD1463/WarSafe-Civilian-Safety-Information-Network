using Microsoft.EntityFrameworkCore;
using WarSafe.Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Report> Reports { get; set; }

    public DbSet<Shelter> Shelters { get; set; }

    public DbSet<Alert> Alerts { get; set; }

    public DbSet<Hospital> Hospitals { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
