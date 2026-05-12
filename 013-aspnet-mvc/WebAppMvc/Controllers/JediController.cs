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


    [HttpGet]
    public IActionResult Detail(int id)
    {
        //acciones 
        var jedi = new Jedi
        {
            Id = id,
            Name = "Luke Skywalker",
            LightSaberColor = "Green"
        };

        return View();
    }

}
