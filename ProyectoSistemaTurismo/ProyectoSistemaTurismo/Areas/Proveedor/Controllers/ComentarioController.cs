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
    public class ComentarioController : Controller
    {
        private ComentarioService _comentarioService = new ComentarioService();


        public ActionResult Index()
        {
            int idOferta = (int)Session["OfertaId"];
            var comentarios = _comentarioService.ObtenerPorOferta(idOferta);
            return View(comentarios);
        }





        //
    }
}