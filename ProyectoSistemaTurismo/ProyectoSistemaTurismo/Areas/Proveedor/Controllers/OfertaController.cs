using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Areas.Proveedor.Controllers
{
    [Autenticado]
    public class OfertaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // Seleccionar una oferta
        public ActionResult Seleccionar(int idOferta)
        {
            var ofertaSeleccionada = db.Oferta
                                         .FirstOrDefault(o => o.id_oferta == idOferta);

            if (ofertaSeleccionada != null)
            {
                Session["OfertaId"] = ofertaSeleccionada.id_oferta;
                Session["OfertaNombre"] = ofertaSeleccionada.nombre;
                Session["id_tipo_oferta"] = ofertaSeleccionada.id_tipo_oferta;
                Session["OfertaTipo"] = ofertaSeleccionada.Tipo_Oferta.nombre_tipo;
                Session["id_destino"] = ofertaSeleccionada.id_destino;
                Session["OfertaDestino"] = ofertaSeleccionada.Destino.nombre_destino;
                Session["OfertaSitioWeb"] = ofertaSeleccionada.sitio_web;


                if (Request.UrlReferrer != null)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }

                return RedirectToAction("MisOfertas", "Oferta", new { area = "Proveedor" });
            }
            else
            {
                TempData["mensaje"] = "No se encontró la oferta seleccionada.";
                return RedirectToAction("MisOfertas", "Oferta", new { area = "Proveedor" });
            }
        }




        public PartialViewResult ListaOfertasUsuario()
        {
            int idUsuario = (int)Session["id_usuario"];

            var ofertas = db.Oferta
                            .Where(o => o.id_usuario == idUsuario)
                            .ToList();

            return PartialView(ofertas);
        }









        // GET: Proveedor/Oferta/Crear - Formulario para crear una nueva oferta
        public ActionResult Crear()
        {
            ViewBag.TipoOfertas = new SelectList(db.Tipo_Oferta.Where(t => t.estado == "A"), "id_tipo_oferta", "nombre_tipo");
            return View();
        }

        // POST: Proveedor/Oferta/Crear - Guardar una nueva oferta
        [HttpPost]
        public ActionResult Crear(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                int usuarioId = (int)Session["id_usuario"];
                oferta.id_usuario = usuarioId;
                oferta.fecha_creacion = DateTime.Now; // Fecha de creación

                using (var db = new ModeloSistema())
                {
                    db.Oferta.Add(oferta);
                    db.SaveChanges();
                }

                TempData["mensaje"] = "Oferta creada con éxito";
                return RedirectToAction("MisOfertas");
            }

            ViewBag.TipoOfertas = new SelectList(db.Tipo_Oferta.Where(t => t.estado == "A"), "id_tipo_oferta", "nombre_tipo");
            TempData["mensaje"] = "Hubo un error al crear la oferta";
            return View(oferta);
        }



        // GET: Proveedor/Oferta/MisOfertas - Ver todas las ofertas del proveedor
        public ActionResult MisOfertas()
        {
            int usuarioId = (int)Session["id_usuario"];
            List<Oferta> ofertas;

            using (var db = new ModeloSistema())
            {
                ofertas = db.Oferta.Where(o => o.id_usuario == usuarioId).ToList();
            }

            return View(ofertas);
        }

        // GET: Proveedor/Oferta/Editar/5 - Editar una oferta
        public ActionResult Editar(int id)
        {
            Oferta oferta;

            using (var db = new ModeloSistema())
            {
                oferta = db.Oferta.Where(o => o.id_oferta == id).SingleOrDefault();
            }

            if (oferta == null)
            {
                TempData["mensaje"] = "Oferta no encontrada";
                return RedirectToAction("MisOfertas");
            }

            return View(oferta);
        }

        // POST: Proveedor/Oferta/Editar/5 - Actualizar la oferta editada
        [HttpPost]
        public ActionResult Editar(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(oferta).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                TempData["mensaje"] = "Oferta actualizada con éxito";
                return RedirectToAction("MisOfertas");
            }

            TempData["mensaje"] = "Hubo un error al actualizar la oferta";
            return View(oferta);
        }

        // GET: Proveedor/Oferta/Eliminar/5 - Eliminar una oferta
        public ActionResult Eliminar(int id)
        {
            using (var db = new ModeloSistema())
            {
                Oferta oferta = db.Oferta.Where(o => o.id_oferta == id).SingleOrDefault();
                if (oferta != null)
                {
                    db.Oferta.Remove(oferta);
                    db.SaveChanges();
                }
            }

            TempData["mensaje"] = "Oferta eliminada con éxito";
            return RedirectToAction("MisOfertas");
        }


        //
    }
}