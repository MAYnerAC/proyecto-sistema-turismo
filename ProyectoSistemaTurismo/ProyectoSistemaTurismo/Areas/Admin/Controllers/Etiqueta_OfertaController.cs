using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;

namespace ProyectoSistemaTurismo.Areas.Admin.Controllers
{
    public class Etiqueta_OfertaController : Controller
    {
        private Etiqueta_OfertaService _etiquetaOfertaService = new Etiqueta_OfertaService();
        private OfertaService _ofertaService = new OfertaService();
        private EtiquetaService _etiquetaService = new EtiquetaService();

        public ActionResult Index()
        {
            var etiquetaOfertas = _etiquetaOfertaService.ObtenerTodos();
            return View(etiquetaOfertas);
        }

        public ActionResult Detalles(int id)
        {
            var etiquetaOferta = _etiquetaOfertaService.ObtenerPorId(id);
            if (etiquetaOferta == null)
            {
                TempData["Error"] = "La relación Etiqueta-Oferta no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(etiquetaOferta);
        }

        public ActionResult Crear()
        {
            var ofertas = _ofertaService.ObtenerTodosActivos(); // Obtener todas las ofertas
            var etiquetas = _etiquetaService.ObtenerTodosActivos(); // Obtener todas las etiquetas

            ViewBag.Ofertas = new SelectList(ofertas, "id_oferta", "nombre");
            ViewBag.Etiquetas = new SelectList(etiquetas, "id_etiqueta", "nombre_etiqueta");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Etiqueta_Oferta etiquetaOferta)
        {
            if (ModelState.IsValid)
            {
                _etiquetaOfertaService.Agregar(etiquetaOferta);
                TempData["Mensaje"] = "Relación Etiqueta-Oferta creada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear la relación.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var etiquetaOferta = _etiquetaOfertaService.ObtenerPorId(id);
            if (etiquetaOferta == null)
            {
                TempData["Error"] = "La relación Etiqueta-Oferta no fue encontrada.";
                return RedirectToAction("Index");
            }

            var ofertas = _ofertaService.ObtenerTodosActivos();
            var etiquetas = _etiquetaService.ObtenerTodosActivos();

            ViewBag.Ofertas = new SelectList(ofertas, "id_oferta", "nombre", etiquetaOferta.id_oferta);
            ViewBag.Etiquetas = new SelectList(etiquetas, "id_etiqueta", "nombre_etiqueta", etiquetaOferta.id_etiqueta);

            return View(etiquetaOferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Etiqueta_Oferta etiquetaOferta)
        {
            if (ModelState.IsValid)
            {
                _etiquetaOfertaService.Actualizar(etiquetaOferta);
                TempData["Mensaje"] = "Relación Etiqueta-Oferta actualizada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar la relación.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var etiquetaOferta = _etiquetaOfertaService.ObtenerPorId(id);
            if (etiquetaOferta == null)
            {
                TempData["Error"] = "La relación Etiqueta-Oferta no fue encontrada.";
                return RedirectToAction("Index");
            }

            _etiquetaOfertaService.Eliminar(id);
            TempData["Mensaje"] = "Relación Etiqueta-Oferta eliminada con éxito.";
            return RedirectToAction("Index");
        }





        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Etiqueta_Oferta
        public ActionResult Index()
        {
            var etiqueta_Oferta = db.Etiqueta_Oferta.Include(e => e.Etiqueta).Include(e => e.Oferta);
            return View(etiqueta_Oferta.ToList());
        }

        // GET: Admin/Etiqueta_Oferta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta_Oferta etiqueta_Oferta = db.Etiqueta_Oferta.Find(id);
            if (etiqueta_Oferta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta_Oferta);
        }

        // GET: Admin/Etiqueta_Oferta/Create
        public ActionResult Create()
        {
            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta");
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            return View();
        }

        // POST: Admin/Etiqueta_Oferta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_etiqueta_oferta,id_oferta,id_etiqueta")] Etiqueta_Oferta etiqueta_Oferta)
        {
            if (ModelState.IsValid)
            {
                db.Etiqueta_Oferta.Add(etiqueta_Oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta", etiqueta_Oferta.id_etiqueta);
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", etiqueta_Oferta.id_oferta);
            return View(etiqueta_Oferta);
        }

        // GET: Admin/Etiqueta_Oferta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta_Oferta etiqueta_Oferta = db.Etiqueta_Oferta.Find(id);
            if (etiqueta_Oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta", etiqueta_Oferta.id_etiqueta);
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", etiqueta_Oferta.id_oferta);
            return View(etiqueta_Oferta);
        }

        // POST: Admin/Etiqueta_Oferta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_etiqueta_oferta,id_oferta,id_etiqueta")] Etiqueta_Oferta etiqueta_Oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiqueta_Oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta", etiqueta_Oferta.id_etiqueta);
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", etiqueta_Oferta.id_oferta);
            return View(etiqueta_Oferta);
        }

        // GET: Admin/Etiqueta_Oferta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta_Oferta etiqueta_Oferta = db.Etiqueta_Oferta.Find(id);
            if (etiqueta_Oferta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta_Oferta);
        }

        // POST: Admin/Etiqueta_Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etiqueta_Oferta etiqueta_Oferta = db.Etiqueta_Oferta.Find(id);
            db.Etiqueta_Oferta.Remove(etiqueta_Oferta);
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
