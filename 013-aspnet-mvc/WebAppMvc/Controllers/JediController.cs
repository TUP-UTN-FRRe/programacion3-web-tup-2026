using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers;

public class JediController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        //acciones 

        return View();
    }

}
