using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Controllers
{
    public class DestinosController : Controller
    {

        private DestinoService destinoService = new DestinoService();


        // GET: Destinos
        public ActionResult Index()
        {
            var ofertas = destinoService.ObtenerTodosActivos();
            return View(ofertas);
        }





    }
}