using WarSafe.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ReportRepository
{
    private readonly AppDbContext _db;

    public ReportRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Report>> GetAll()
    {
        return await _db.Reports.ToListAsync();
    }

    public async Task<Report> Create(Report report)
    {
        report.Id = Guid.NewGuid();
        _db.Reports.Add(report);
        await _db.SaveChangesAsync();
        return report;
    }
}
