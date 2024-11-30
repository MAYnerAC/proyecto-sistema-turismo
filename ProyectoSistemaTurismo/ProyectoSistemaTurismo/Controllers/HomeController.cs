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
        private ComentarioService _comentarioService = new ComentarioService();
        private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();
        private Etiqueta_OfertaService _etiquetaOfertaService = new Etiqueta_OfertaService();
        private GaleriaService _galeriaService = new GaleriaService();



        //private DestinoService destinoService = new DestinoService();
        //private Tipo_OfertaService tipoOfertaService = new Tipo_OfertaService();




        public ActionResult Index()
        {
            var ofertas = _ofertaService.ObtenerOfertasPrevias();
            return View(ofertas);
        }


        public ActionResult Detalles(int id)
        {

            //ya no seria un solo metodo "ObtenerDetalleOferta" sino los demas SERVICE usando viewbag

            //oferta.porid                       -  SI
            //comentario.poroferta               -  SI
            //galeria.poroferta                  -  SI
            //etiqueta_oferta.obtenerporoferta   -  SI


            //var oferta = _ofertaService.ObtenerDetalleOferta(id); // Se deja de usar ---x---
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }

            var comentarios = _comentarioService.ObtenerPorOferta(id);
            var galeria = _galeriaService.ObtenerPorOferta(id);
            var etiquetas = _etiquetaOfertaService.ObtenerPorOferta(id);

            ViewBag.Comentarios = comentarios;
            ViewBag.Galeria = galeria;
            ViewBag.Etiquetas = etiquetas;

            return View(oferta);
        }


        //otro action seria foto_comentario.obtenerporcomentario
        public ActionResult DetallesComentario(int id)
        {
            var comentario = _comentarioService.ObtenerPorId(id);

            if (comentario == null)
            {
                TempData["Error"] = "El comentario no fue encontrado.";
                return RedirectToAction("Index");
            }

            var fotosComentario = _fotoComentarioService.ObtenerPorComentario(id);
            ViewBag.FotosComentario = fotosComentario; //Sin SelectList ya q no usaremos "dropdownList"

            return View(comentario);
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