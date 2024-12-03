using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Controllers
{
    public class OfertasController : Controller
    {

        private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();


        //Falta separar? o usar FACADE?
        private OfertaService _ofertaService = new OfertaService();
        private ComentarioService _comentarioService = new ComentarioService();
        private Etiqueta_OfertaService _etiquetaOfertaService = new Etiqueta_OfertaService();
        private GaleriaService _galeriaService = new GaleriaService();


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



        //
    }
}