using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string email, string password)
    {
        return Ok(await _auth.Register(email, password));
    }

   [HttpPost("login")]
public async Task<IActionResult> Login(LoginDto dto)
{
    return Ok(await _auth.Login(dto.Email, dto.Password));
}