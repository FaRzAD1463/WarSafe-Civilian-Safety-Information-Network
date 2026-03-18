using WarSafe.Domain.Entities;

public interface IReportService
{
    Task<List<Report>> GetAll();
    Task<Report> Create(Report report);
}
