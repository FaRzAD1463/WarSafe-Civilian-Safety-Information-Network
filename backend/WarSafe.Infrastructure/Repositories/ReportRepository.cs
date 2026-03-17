using WarSafe.Domain.Entities;

public class ReportRepository
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Report report)
    {
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
    }

    public List<Report> GetAll()
    {
        return _context.Reports.ToList();
    }
}