using WarSafe.Domain.Entities;

public interface IReportService
{
    Task<Report> CreateAsync(Report report);
    Task<List<Report>> GetAllAsync();
}