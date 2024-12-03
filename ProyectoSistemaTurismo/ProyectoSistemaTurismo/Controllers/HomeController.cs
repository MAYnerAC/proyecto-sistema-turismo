using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using ProyectoSistemaTurismo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Controllers
{
    public class HomeController : Controller
    {
        //Falta separar? o usar FACADE?
        private OfertaService _ofertaService = new OfertaService();
        //private ComentarioService _comentarioService = new ComentarioService();
        //private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();
        //private Etiqueta_OfertaService _etiquetaOfertaService = new Etiqueta_OfertaService();
        //private GaleriaService _galeriaService = new GaleriaService();


        //private DestinoService destinoService = new DestinoService();
        //private Tipo_OfertaService tipoOfertaService = new Tipo_OfertaService();




        public ActionResult Index()
        {
            var ofertas = _ofertaService.ObtenerOfertasPrevias();
            return View(ofertas);
        }






        public ActionResult AccessDenied()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


        //
    }
}