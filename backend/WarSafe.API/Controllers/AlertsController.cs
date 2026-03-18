using Microsoft.AspNetCore.Mvc;
using WarSafe.Application.Interfaces;

[ApiController]
[Route("api/alerts")]
public class AlertsController : ControllerBase
{
    private readonly IAlertService _service;

    public AlertsController(IAlertService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlerts()
    {
        var alerts = await _service.GetAlerts();
        return Ok(alerts);
    }
}
