using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starwars.Auth.Api.Entities;

namespace Starwars.Auth.Api.Controllers;

[ApiController]
[Route("api/time2")]
public class Time2Controller : ControllerBase
{
    //public Saludo SaludoInstance { get; set; }

    private readonly Saludo _saludo;

    public Time2Controller(Saludo saludoParam)
    {
        _saludo = saludoParam;
    }


    // GET /api/time2 — público, sin autenticación
    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetTime()
    {
        //var saludo = new Saludo();

        //Generar random bool
        Random random = new Random();
        bool randomBool = random.NextDouble() >= 0.5;

        if (randomBool) {
            return Ok(new
            {
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                secured = false,
                messsage = _saludo.Saludar()
            });
        } else {
            return Ok(
                new
                {
                    hasError = true,
                    message = "json_invalido",
                    code = "0067"

                });
        }
       
    }

    // GET /api/time2/secure — requiere JWT válido
    [HttpGet("secure")]
    [Authorize]
    public IActionResult GetSecureTime()
    {
        //var saludo = new Saludo();

        return Ok(new
        {
            time    = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            secured = true,
            user    = User.Identity?.Name,
            messsage = _saludo.Saludar()
        });
    }
}
