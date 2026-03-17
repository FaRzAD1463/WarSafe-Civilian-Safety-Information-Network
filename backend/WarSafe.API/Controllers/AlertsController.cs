[ApiController]
[Route("api/alerts")]
public class AlertsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlertsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Alert alert)
    {
        alert.Id = Guid.NewGuid();
        alert.CreatedAt = DateTime.UtcNow;

        _context.Add(alert);
        await _context.SaveChangesAsync();

        return Ok(alert);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Set<Alert>().ToList());
    }
}