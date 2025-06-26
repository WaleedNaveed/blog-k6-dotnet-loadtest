using K6LoadTestDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Login = K6LoadTestDemo.DTOs.Login;

namespace K6LoadTestDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login.Request request)
    {
        var response = await _authService.LoginAsync(request);
        return Ok(response);
    }
}