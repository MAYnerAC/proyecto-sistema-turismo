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
        
        //private OfertaService _ofertaService = new OfertaService();
        
        //private ComentarioService _comentarioService = new ComentarioService();
        //private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();
        //private Etiqueta_OfertaService _etiquetaOfertaService = new Etiqueta_OfertaService();
        //private GaleriaService _galeriaService = new GaleriaService();


        //private DestinoService destinoService = new DestinoService();
        //private Tipo_OfertaService tipoOfertaService = new Tipo_OfertaService();


        private readonly OfertaService _ofertaService;

        public HomeController()
        {
            _ofertaService = new OfertaService(new ModeloSistema());
        }



        public ActionResult Index()
        {
            var ofertas = _ofertaService.ObtenerOfertasPrevias();
            return View(ofertas);
        }


        public ActionResult Mapas()
        {
            Oferta oferta1 = _ofertaService.ObtenerPorId(1);
            Oferta oferta2 = _ofertaService.ObtenerPorId(13);

            //decimal latitudA = 18.457232m;
            //decimal longitudA = -70.660000m;

            // Coordenadas de la ubicación B
            //decimal latitudB = 18.467232m;
            //decimal longitudB = -70.650000m;

            // Pasar las coordenadas al ViewBag
            ViewBag.LatitudA = oferta1.ubicacion_lat;
            ViewBag.LongitudA = oferta1.ubicacion_lon;

            ViewBag.LatitudB = oferta2.ubicacion_lat;
            ViewBag.LongitudB = oferta2.ubicacion_lon;

            return View();
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