using WarSafe.Domain.Entities;
using WarSafe.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class ReportService : IReportService
{
    private readonly AppDbContext _context;

    public ReportService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Report> CreateAsync(Report report)
    {
        report.Id = Guid.NewGuid();
        report.CreatedAt = DateTime.UtcNow;

        _context.Reports.Add(report);
        await _context.SaveChangesAsync();

        return report;
    }

    public async Task<List<Report>> GetAllAsync()
    {
        return await _context.Reports.ToListAsync();
    }
}