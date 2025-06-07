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
    public class GaleriaController : Controller
    {

        //private GaleriaService _galeriaService = new GaleriaService();
        //private OfertaService _ofertaService = new OfertaService();
        //private FirebaseStorageService _firebaseStorageService = new FirebaseStorageService();


        private readonly GaleriaService _galeriaService;
        private readonly OfertaService _ofertaService;
        private readonly FirebaseStorageService _firebaseStorageService;

        public GaleriaController()
        {
            _galeriaService = new GaleriaService(new ModeloSistema());
            _ofertaService = new OfertaService(new ModeloSistema());
            _firebaseStorageService = new FirebaseStorageService(); // Solo si no necesita contexto
        }


        public ActionResult Index()
        {
            var imagenes = _galeriaService.ObtenerTodos();
            return View(imagenes);
        }

        public ActionResult Detalles(int id)
        {
            var imagen = _galeriaService.ObtenerPorId(id);
            if (imagen == null)
            {
                TempData["Error"] = "La imagen no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(imagen);
        }

        public ActionResult Crear()
        {
            var ofertas = _ofertaService.ObtenerTodosActivos();
            ViewBag.Ofertas = new SelectList(ofertas, "id_oferta", "nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Galeria galeria, HttpPostedFileBase archivoImagen)
        {
            if (ModelState.IsValid)
            {
                if (archivoImagen != null)
                {
                    //// Simular URL de Firebase
                    //string nombreArchivo = Path.GetFileName(archivoImagen.FileName);
                    //galeria.url_imagen = "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);

                    if ((TempData["Error"] = _firebaseStorageService.ValidarArchivoImagen(archivoImagen)) != null)
                    {
                        return RedirectToAction("Index");
                    }

                    // Subir el archivo a Firebase
                    string urlFotoFirebase = await _firebaseStorageService.SubirArchivo(archivoImagen);
                    galeria.url_imagen = urlFotoFirebase;
                }
                else
                {
                    TempData["Error"] = "Debe seleccionar un archivo para la imagen.";
                    return RedirectToAction("Index");
                }

                _galeriaService.Agregar(galeria);
                TempData["Mensaje"] = "Imagen creada con éxito.";
            }
            else
            {

                //// Diagnóstico de errores en caso de fallo
                //var errores = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                //foreach (var error in errores)
                //{
                //    System.Diagnostics.Debug.WriteLine(error); // Ver en salida de depuración
                //}

                TempData["Error"] = "Los datos ingresados no son válidos.";
            }

            return RedirectToAction("Index");
        }


        public ActionResult Editar(int id)
        {
            var galeria = _galeriaService.ObtenerPorId(id);
            if (galeria == null)
            {
                TempData["Error"] = "La imagen no fue encontrada.";
                return RedirectToAction("Index");
            }

            var ofertas = _ofertaService.ObtenerTodosActivos();
            ViewBag.Ofertas = new SelectList(ofertas, "id_oferta", "nombre", galeria.id_oferta);
            return View(galeria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Galeria galeria, HttpPostedFileBase archivoImagen)
        {
            if (ModelState.IsValid)
            {
                if (archivoImagen != null)
                {
                    //// Simular URL de Firebase
                    //string nombreArchivo = Path.GetFileName(archivoImagen.FileName);
                    //galeria.url_imagen = "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);

                    if ((TempData["Error"] = _firebaseStorageService.ValidarArchivoImagen(archivoImagen)) != null)
                    {
                        return RedirectToAction("Index");
                    }

                    // Subir el archivo a Firebase
                    string urlFotoFirebase = await _firebaseStorageService.SubirArchivo(archivoImagen);
                    galeria.url_imagen = urlFotoFirebase;
                }
                //else
                //{
                //    TempData["Error"] = "Debe seleccionar un archivo para la imagen.";
                //    return RedirectToAction("Index");
                //}

                _galeriaService.Actualizar(galeria);
                TempData["Mensaje"] = "Imagen actualizada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos.";
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var galeria = _galeriaService.ObtenerPorId(id);
            if (galeria == null)
            {
                TempData["Error"] = "La imagen no fue encontrada.";
                return RedirectToAction("Index");
            }

            _galeriaService.Eliminar(id);
            TempData["Mensaje"] = "Imagen eliminada con éxito.";
            return RedirectToAction("Index");
        }




        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Galeria
        public ActionResult Index()
        {
            var galeria = db.Galeria.Include(g => g.Oferta);
            return View(galeria.ToList());
        }

        // GET: Admin/Galeria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        // GET: Admin/Galeria/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            return View();
        }

        // POST: Admin/Galeria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_imagen,url_imagen,descripcion,tipo_imagen,fecha_subida,estado,id_oferta")] Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                db.Galeria.Add(galeria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", galeria.id_oferta);
            return View(galeria);
        }

        // GET: Admin/Galeria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", galeria.id_oferta);
            return View(galeria);
        }

        // POST: Admin/Galeria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_imagen,url_imagen,descripcion,tipo_imagen,fecha_subida,estado,id_oferta")] Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galeria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", galeria.id_oferta);
            return View(galeria);
        }

        // GET: Admin/Galeria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        // POST: Admin/Galeria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galeria galeria = db.Galeria.Find(id);
            db.Galeria.Remove(galeria);
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
