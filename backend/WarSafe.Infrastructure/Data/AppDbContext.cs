using Microsoft.EntityFrameworkCore;
using WarSafe.Domain.Entities;

namespace WarSafe.Infrastructure;

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}

public class AppDbContext : DbContext
{
    public DbSet<Report> Reports { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}

