[ApiController]
[Route("api/shelters")]
public class SheltersController : ControllerBase
{
    private readonly AppDbContext _context;

    public SheltersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Add(Shelter shelter)
    {
        shelter.Id = Guid.NewGuid();
        _context.Add(shelter);
        await _context.SaveChangesAsync();

        return Ok(shelter);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Set<Shelter>().ToList());
    }
}