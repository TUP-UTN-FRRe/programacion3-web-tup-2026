using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Starwars.Auth.Api.Controllers;

[ApiController]
[Route("api/time2")]
public class Time2Controller : ControllerBase
{
    // GET /api/time2 — público, sin autenticación
    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetTime()
    {
        return Ok(new
        {
            time    = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            secured = false
        });
    }

    // GET /api/time2/secure — requiere JWT válido
    [HttpGet("secure")]
    [Authorize]
    public IActionResult GetSecureTime()
    {
        return Ok(new
        {
            time    = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            secured = true,
            user    = User.Identity?.Name
        });
    }
}
