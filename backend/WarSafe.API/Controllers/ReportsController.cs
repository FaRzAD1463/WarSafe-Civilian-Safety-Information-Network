using Microsoft.AspNetCore.Mvc;
using WarSafe.Domain.Entities;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _service;

    public ReportsController(IReportService service)
    {
        _service = service;
    }

  [HttpPost]
public async Task<IActionResult> Create(CreateReportDto dto)
{
    var report = new Report
    {
        Type = dto.Type,
        Description = dto.Description,
        Latitude = dto.Latitude,
        Longitude = dto.Longitude,
        Urgency = dto.Urgency
    };

    ReportValidator.Validate(report);

    return Ok(await _service.CreateAsync(report));
}

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
}