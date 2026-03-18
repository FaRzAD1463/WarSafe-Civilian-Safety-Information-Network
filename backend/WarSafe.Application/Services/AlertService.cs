using WarSafe.Domain.Entities;
using WarSafe.Infrastructure;

public class AlertService : IAlertService
{
    private readonly AppDbContext _db;

    public AlertService(AppDbContext db)
    {
        _db = db;
    }

   public async Task<List<Alert>> GetAlerts()
{
    return await _db.Alerts.ToListAsync();
}
}
