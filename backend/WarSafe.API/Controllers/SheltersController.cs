using Microsoft.AspNetCore.Mvc;
using WarSafe.Application.Interfaces;

[ApiController]
[Route("api/shelters")]
public class SheltersController : ControllerBase
{
    private readonly IShelterService _service;

    public SheltersController(IShelterService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetShelters()
    {
        var shelters = await _service.GetShelters();
        return Ok(shelters);
    }
}
