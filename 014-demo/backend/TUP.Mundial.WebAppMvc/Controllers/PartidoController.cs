using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TUP.Mundial.WebAppMvc.Models;

namespace TUP.Mundial.WebAppMvc.Controllers
{
    public class PartidoController: Controller
    {
        public IActionResult Index()
        {

            var partidos = new List<Partido>();

            for (int i = 1; i < 100; i++)
            {
                partidos.Add(new Partido() { 
                    Local = new Equipo() { Nombre = $"Equipo Local {i}" },
                    Visitante = new Equipo() { Nombre = $"Equipo Visitante {i}" }
                });

            }

            return View(partidos);
        }

        public IActionResult Detalle(string fase, 
                                        string equipo1, 
                                        string equipo2)
        {
            return View("Index");
        }
    }
}
