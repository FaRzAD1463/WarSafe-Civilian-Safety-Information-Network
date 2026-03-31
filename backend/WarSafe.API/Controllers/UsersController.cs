using Microsoft.AspNetCore.Mvc;
using WarSafe.Application.Interfaces;


[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }
}
