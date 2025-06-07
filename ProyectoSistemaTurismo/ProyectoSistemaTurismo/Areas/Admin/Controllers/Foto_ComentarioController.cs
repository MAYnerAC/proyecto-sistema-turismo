using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;

namespace ProyectoSistemaTurismo.Areas.Admin.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(1)]
    public class Foto_ComentarioController : Controller
    {
        //private Foto_ComentarioService _fotoComentarioService = new Foto_ComentarioService();
        //private ComentarioService _comentarioService = new ComentarioService();
        private FirebaseStorageService _firebaseStorageService = new FirebaseStorageService();


        private readonly Foto_ComentarioService _fotoComentarioService;
        private readonly ComentarioService _comentarioService;
        //private readonly FirebaseStorageService _firebaseStorageService;

        public Foto_ComentarioController()
        {
            _fotoComentarioService = new Foto_ComentarioService(new ModeloSistema());
            _comentarioService = new ComentarioService(new ModeloSistema());
            //_firebaseStorageService = new FirebaseStorageService(); // solo si no requiere contexto
        }


        public ActionResult Index()
        {
            var fotosComentarios = _fotoComentarioService.ObtenerTodos();
            return View(fotosComentarios);
        }

        public ActionResult Detalles(int id)
        {
            var fotoComentario = _fotoComentarioService.ObtenerPorId(id);
            if (fotoComentario == null)
            {
                TempData["Error"] = "La foto de comentario no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(fotoComentario);
        }

        public ActionResult Crear()
        {
            var comentarios = _comentarioService.ObtenerTodosActivos();
            ViewBag.Comentarios = new SelectList(comentarios, "id_comentario", "contenido");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Foto_Comentario fotoComentario, HttpPostedFileBase archivoImagen)
        {
            if (ModelState.IsValid)
            {
                if (archivoImagen != null)
                {
                    //// Simular URL de Firebase
                    //string nombreArchivo = Path.GetFileName(archivoImagen.FileName);
                    //fotoComentario.url_foto = "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);

                    if ((TempData["Error"] = _firebaseStorageService.ValidarArchivoImagen(archivoImagen)) != null)
                    {
                        return RedirectToAction("Index");
                    }

                    // Subir el archivo a Firebase
                    string urlFotoFirebase = await _firebaseStorageService.SubirArchivo(archivoImagen);
                    fotoComentario.url_foto = urlFotoFirebase;
                }
                else
                {
                    TempData["Error"] = "Debe seleccionar un archivo para la imagen.";
                    return RedirectToAction("Index");
                }

                _fotoComentarioService.Agregar(fotoComentario);
                TempData["Mensaje"] = "Foto de comentario creada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear la foto de comentario.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var fotoComentario = _fotoComentarioService.ObtenerPorId(id);
            if (fotoComentario == null)
            {
                TempData["Error"] = "La foto de comentario no fue encontrada.";
                return RedirectToAction("Index");
            }

            var comentarios = _comentarioService.ObtenerTodosActivos();
            ViewBag.Comentarios = new SelectList(comentarios, "id_comentario", "contenido", fotoComentario.id_comentario);

            return View(fotoComentario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Foto_Comentario fotoComentario, HttpPostedFileBase archivoImagen)
        {
            if (ModelState.IsValid)
            {
                if (archivoImagen != null)
                {
                    //// Simular URL de Firebase
                    //string nombreArchivo = Path.GetFileName(archivoImagen.FileName);
                    //fotoComentario.url_foto = "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);

                    if ((TempData["Error"] = _firebaseStorageService.ValidarArchivoImagen(archivoImagen)) != null)
                    {
                        return RedirectToAction("Index");
                    }

                    // Subir el archivo a Firebase
                    string urlFotoFirebase = await _firebaseStorageService.SubirArchivo(archivoImagen);
                    fotoComentario.url_foto = urlFotoFirebase;
                }


                _fotoComentarioService.Actualizar(fotoComentario);
                TempData["Mensaje"] = "Foto de comentario actualizada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar la foto de comentario.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var fotoComentario = _fotoComentarioService.ObtenerPorId(id);
            if (fotoComentario == null)
            {
                TempData["Error"] = "La foto de comentario no fue encontrada.";
                return RedirectToAction("Index");
            }

            _fotoComentarioService.Eliminar(id);
            TempData["Mensaje"] = "Foto de comentario eliminada con éxito.";
            return RedirectToAction("Index");
        }



        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Foto_Comentario
        public ActionResult Index()
        {
            var foto_Comentario = db.Foto_Comentario.Include(f => f.Comentario);
            return View(foto_Comentario.ToList());
        }

        // GET: Admin/Foto_Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            if (foto_Comentario == null)
            {
                return HttpNotFound();
            }
            return View(foto_Comentario);
        }

        // GET: Admin/Foto_Comentario/Create
        public ActionResult Create()
        {
            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1");
            return View();
        }

        // POST: Admin/Foto_Comentario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_foto,url_foto,descripcion,fecha_subida,estado,id_comentario")] Foto_Comentario foto_Comentario)
        {
            if (ModelState.IsValid)
            {
                db.Foto_Comentario.Add(foto_Comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1", foto_Comentario.id_comentario);
            return View(foto_Comentario);
        }

        // GET: Admin/Foto_Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            if (foto_Comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1", foto_Comentario.id_comentario);
            return View(foto_Comentario);
        }

        // POST: Admin/Foto_Comentario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_foto,url_foto,descripcion,fecha_subida,estado,id_comentario")] Foto_Comentario foto_Comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto_Comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1", foto_Comentario.id_comentario);
            return View(foto_Comentario);
        }

        // GET: Admin/Foto_Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            if (foto_Comentario == null)
            {
                return HttpNotFound();
            }
            return View(foto_Comentario);
        }

        // POST: Admin/Foto_Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            db.Foto_Comentario.Remove(foto_Comentario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        */
    }
}
