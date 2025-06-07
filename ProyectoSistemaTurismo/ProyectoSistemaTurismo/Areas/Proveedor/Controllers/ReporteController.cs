using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Areas.Proveedor.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(2)]
    [OfertaSeleccionada]
    public class ReporteController : Controller
    {

        //private ReporteService _reportService = new ReporteService();

        private readonly ReporteService _reporteService;

        public ReporteController()
        {
            _reporteService = new ReporteService(new ModeloSistema());
        }

        public ActionResult ReporteOfertasPorTipo()
        {
            int idOferta = (int)Session["OfertaId"];
            var ofertasPorTipo = _reporteService.ObtenerOfertasPorTipo(idOferta);
            return View(ofertasPorTipo);
        }

        public ActionResult ReporteOfertasPorDestino()
        {
            int idOferta = (int)Session["OfertaId"];
            var ofertasPorDestino = _reporteService.ObtenerOfertasPorDestino(idOferta);
            return View(ofertasPorDestino);
        }


        //
    }
}