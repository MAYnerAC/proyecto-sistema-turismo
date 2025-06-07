using ProyectoSistemaTurismo.Models;
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

        //private DestinoService destinoService = new DestinoService();

        private readonly DestinoService _destinoService;

        public DestinosController()
        {
            _destinoService = new DestinoService(new ModeloSistema());
        }

        // GET: Destinos
        public ActionResult Index()
        {
            var ofertas = _destinoService.ObtenerTodosActivos();
            return View(ofertas);
        }





    }
}