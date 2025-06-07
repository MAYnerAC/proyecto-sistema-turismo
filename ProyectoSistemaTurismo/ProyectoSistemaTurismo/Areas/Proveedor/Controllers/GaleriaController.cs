using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//
using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;

namespace ProyectoSistemaTurismo.Areas.Proveedor.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(2)]
    [OfertaSeleccionada]
    public class GaleriaController : Controller
    {
        private GaleriaService _galeriaService = new GaleriaService();
        //private OfertaService _ofertaService = new OfertaService();
        private FirebaseStorageService _firebaseStorageService = new FirebaseStorageService();


        //private readonly GaleriaService _galeriaService;
        private readonly OfertaService _ofertaService;
        //private readonly FirebaseStorageService _firebaseStorageService;

        public GaleriaController()
        {
            //_galeriaService = new GaleriaService(new ModeloSistema());
            _ofertaService = new OfertaService(new ModeloSistema());
            //_firebaseStorageService = new FirebaseStorageService(); // Solo si no necesita contexto
        }

        public ActionResult Index()
        {
            int idOferta = (int)Session["OfertaId"];
            var imagenes = _galeriaService.ObtenerPorOferta(idOferta);
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
                    //galeria.url_imagen = "https://firebasestorage.googleapis.com/v0/b/tu-proyecto.appspot.com/o/" + Uri.EscapeDataString(nombreArchivo);

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
                    //galeria.url_imagen = "https://firebasestorage.googleapis.com/v0/b/tu-proyecto.appspot.com/o/" + Uri.EscapeDataString(nombreArchivo);

                    if ((TempData["Error"] = _firebaseStorageService.ValidarArchivoImagen(archivoImagen)) != null)
                    {
                        return RedirectToAction("Index");
                    }

                    // Subir el archivo a Firebase
                    string urlFotoFirebase = await _firebaseStorageService.SubirArchivo(archivoImagen);
                    galeria.url_imagen = urlFotoFirebase;
                }

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

        // GET: Proveedor/Galeria
        public ActionResult Index()
        {
            if (Session["OfertaId"] == null)
            {
                TempData["mensaje"] = "Debe seleccionar una oferta para gestionar su galería.";
                return RedirectToAction("MisOfertas", "Oferta");
            }

            int ofertaId = (int)Session["OfertaId"];
            var imagenes = db.Galeria.Where(g => g.id_oferta == ofertaId && g.estado == "A").ToList();

            return View(imagenes);
        }

        // GET: Proveedor/Galeria/AgregarImagen
        public ActionResult AgregarImagen()
        {
            if (Session["OfertaId"] == null)
            {
                TempData["mensaje"] = "Debe seleccionar una oferta para agregar imágenes.";
                return RedirectToAction("MisOfertas", "Oferta");
            }

            return View();
        }

        // POST: Proveedor/Galeria/AgregarImagen
        [HttpPost]
        public ActionResult AgregarImagen(HttpPostedFileBase archivoImagen, string descripcion, string tipoImagen)
        {
            if (Session["OfertaId"] == null)
            {
                TempData["mensaje"] = "Debe seleccionar una oferta para agregar imágenes.";
                return RedirectToAction("MisOfertas", "Oferta");
            }

            if (archivoImagen != null && archivoImagen.ContentLength > 0)
            {
                try
                {
                    string nombreArchivo = Path.GetFileName(archivoImagen.FileName);
                    string rutaCarpeta = Server.MapPath("~/Content/Imagenes/Galeria/");
                    if (!Directory.Exists(rutaCarpeta))
                    {
                        Directory.CreateDirectory(rutaCarpeta);
                    }
                    string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);
                    archivoImagen.SaveAs(rutaCompleta);

                    Galeria nuevaImagen = new Galeria
                    {
                        url_imagen = "/Content/Imagenes/Galeria/" + nombreArchivo,
                        descripcion = descripcion,
                        tipo_imagen = tipoImagen,
                        fecha_subida = DateTime.Now,
                        estado = "A",
                        id_oferta = (int)Session["OfertaId"]
                    };

                    db.Galeria.Add(nuevaImagen);
                    db.SaveChanges();

                    TempData["mensaje"] = "Imagen subida exitosamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensaje"] = "Error al subir la imagen: " + ex.Message;
                    return View();
                }
            }
            else
            {
                TempData["mensaje"] = "Debe seleccionar una imagen.";
                return View();
            }
        }

        // GET: Proveedor/Galeria/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            if (Session["OfertaId"] == null)
            {
                TempData["mensaje"] = "Debe seleccionar una oferta para eliminar imágenes.";
                return RedirectToAction("MisOfertas", "Oferta");
            }

            var imagen = db.Galeria.Find(id);
            if (imagen == null || imagen.id_oferta != (int)Session["OfertaId"])
            {
                TempData["mensaje"] = "Imagen no encontrada o no pertenece a su oferta.";
                return RedirectToAction("Index");
            }

            return View(imagen);
        }

        // POST: Proveedor/Galeria/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminacion(int id)
        {
            var imagen = db.Galeria.Find(id);
            if (imagen != null && imagen.id_oferta == (int)Session["OfertaId"])
            {
                imagen.estado = "I"; // Cambiar el estado a inactivo
                db.Entry(imagen).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                TempData["mensaje"] = "Imagen eliminada exitosamente.";
            }
            else
            {
                TempData["mensaje"] = "Imagen no encontrada o no pertenece a su oferta.";
            }

            return RedirectToAction("Index");
        }
        */




        //
    }
}