using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Controllers
{
    public class ComentariosController : Controller
    {


        private ComentarioService _comentarioService = new ComentarioService();
        private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();
        private FirebaseStorageService _firebaseStorageService = new FirebaseStorageService();



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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AgregarFoto(Foto_Comentario fotoComentario, HttpPostedFileBase archivoImagen)
        {
            if (ModelState.IsValid)
            {
                if (archivoImagen != null)
                {
                    //// Simular URL de Firebase
                    //string nombreArchivo = Path.GetFileName(archivoImagen.FileName);
                    //fotoComentario.url_foto = "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);

                    // Subir el archivo a Firebase
                    string urlFotoFirebase = await _firebaseStorageService.SubirArchivo(archivoImagen);
                    fotoComentario.url_foto = urlFotoFirebase;
                }
                else
                {
                    TempData["Error"] = "Debe seleccionar un archivo para la imagen.";
                    return RedirectToAction("Detalles", "Comentarios", new { id = fotoComentario.id_comentario });
                }

                _fotoComentarioService.Agregar(fotoComentario);
                TempData["Mensaje"] = "Foto subida con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear la foto de comentario.";
            }

            return RedirectToAction("Detalles", "Comentarios", new { id = fotoComentario.id_comentario });
        }







        //
    }
}