using ProyectoSistemaTurismo.Filters;
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


        private ReporteService _reportService = new ReporteService();



        public ActionResult ReporteOfertasPorTipo()
        {
            int idOferta = (int)Session["OfertaId"];
            var ofertasPorTipo = _reportService.ObtenerOfertasPorTipo(idOferta);
            return View(ofertasPorTipo);
        }

        public ActionResult ReporteOfertasPorDestino()
        {
            int idOferta = (int)Session["OfertaId"];
            var ofertasPorDestino = _reportService.ObtenerOfertasPorDestino(idOferta);
            return View(ofertasPorDestino);
        }


        //
    }
}