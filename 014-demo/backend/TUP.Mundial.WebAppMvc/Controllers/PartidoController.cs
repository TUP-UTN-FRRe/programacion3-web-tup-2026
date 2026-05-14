using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TUP.Mundial.WebAppMvc.Models;

namespace TUP.Mundial.WebAppMvc.Controllers
{
    public class PartidoController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalle(string fase, 
                                        string equipo1, 
                                        string equipo2)
        {
            return View("Index");
        }
    }
}
