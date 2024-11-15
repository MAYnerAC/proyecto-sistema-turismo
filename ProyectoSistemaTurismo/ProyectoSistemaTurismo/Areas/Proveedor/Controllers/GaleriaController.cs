using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Areas.Proveedor.Controllers
{
    [Autenticado]
    public class GaleriaController : Controller
    {



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





        //
    }
}