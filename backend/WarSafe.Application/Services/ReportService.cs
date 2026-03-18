using WarSafe.Domain.Entities;
using WarSafe.Infrastructure.Repositories;

public class ReportService : IReportService
{
    private readonly ReportRepository _repo;

    public ReportService(ReportRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Report>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Report> Create(Report report)
    {
        return await _repo.Create(report);
    }
}
