using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Controllers
{
    public class ComentariosController : Controller
    {


        private ComentarioService _comentarioService = new ComentarioService();
        private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();



        //otro action seria foto_comentario.obtenerporcomentario
        public ActionResult Detalles(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarComentario(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _comentarioService.Agregar(comentario);
                TempData["Mensaje"] = "Comentario creado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear el comentario.";
            }

            return RedirectToAction("Detalles", "Ofertas", new { id = comentario.id_oferta });
        }










        //
    }
}