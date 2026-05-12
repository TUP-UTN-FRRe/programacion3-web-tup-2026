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
        var jedis = new List<Jedi>();

        for (int i = 0; i < 10; i++)
        {
            var jedi = new Jedi
            {
                Id = i,
                Name = "Luke Skywalker",
                LightSaberColor = "Green"
            }; 

            jedis.Add(jedi);
        }

        return View(jedis);
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

        return View(jedi);
    }

}
