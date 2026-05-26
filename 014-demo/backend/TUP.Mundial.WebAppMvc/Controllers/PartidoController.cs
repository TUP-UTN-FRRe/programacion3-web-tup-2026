using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TUP.Mundial.Entidades;
using TUP.Mundial.WebAppMvc.Models;

namespace TUP.Mundial.WebAppMvc.Controllers
{
    public class PartidoController: Controller
    {
        public IActionResult Index()
        {
            
            var partidoNegocio = new TUP.Mundial.Negocio.PartidoNegocio();

            var partidos = partidoNegocio.ObtenerListado();

            return View(partidos);
        }




        //public IActionResult Detalle(string fase, 
        //                                string equipo1, 
        //                                string equipo2)
        public IActionResult Detalle(PartidoRequestViewModel partidoVm)
        {
            //var req1 = new PartidoRequestViewModel()  
            //{
            //    Fase = "grupo"
            //};


            return View("DetallePartidoFaseGrupos", partidoVm);
        }
    }
}
