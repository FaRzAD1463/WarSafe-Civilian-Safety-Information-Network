using WarSafe.Domain.Entities;

public interface IAlertService
{
    Task<List<Alert>> GetAlerts();
}
