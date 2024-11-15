using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Areas.Admin.Controllers
{
    public class Suscripcion_NegocioController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Suscripcion_Negocio
        public ActionResult Index()
        {
            var suscripcion_Negocio = db.Suscripcion_Negocio.Include(s => s.Oferta);
            return View(suscripcion_Negocio.ToList());
        }

        // GET: Admin/Suscripcion_Negocio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripcion_Negocio suscripcion_Negocio = db.Suscripcion_Negocio.Find(id);
            if (suscripcion_Negocio == null)
            {
                return HttpNotFound();
            }
            return View(suscripcion_Negocio);
        }

        // GET: Admin/Suscripcion_Negocio/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            return View();
        }

        // POST: Admin/Suscripcion_Negocio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_suscripcion,tipo_plan,fecha_inicio,fecha_expiracion,estado,id_oferta")] Suscripcion_Negocio suscripcion_Negocio)
        {
            if (ModelState.IsValid)
            {
                db.Suscripcion_Negocio.Add(suscripcion_Negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", suscripcion_Negocio.id_oferta);
            return View(suscripcion_Negocio);
        }

        // GET: Admin/Suscripcion_Negocio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripcion_Negocio suscripcion_Negocio = db.Suscripcion_Negocio.Find(id);
            if (suscripcion_Negocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", suscripcion_Negocio.id_oferta);
            return View(suscripcion_Negocio);
        }

        // POST: Admin/Suscripcion_Negocio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_suscripcion,tipo_plan,fecha_inicio,fecha_expiracion,estado,id_oferta")] Suscripcion_Negocio suscripcion_Negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suscripcion_Negocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", suscripcion_Negocio.id_oferta);
            return View(suscripcion_Negocio);
        }

        // GET: Admin/Suscripcion_Negocio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripcion_Negocio suscripcion_Negocio = db.Suscripcion_Negocio.Find(id);
            if (suscripcion_Negocio == null)
            {
                return HttpNotFound();
            }
            return View(suscripcion_Negocio);
        }

        // POST: Admin/Suscripcion_Negocio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suscripcion_Negocio suscripcion_Negocio = db.Suscripcion_Negocio.Find(id);
            db.Suscripcion_Negocio.Remove(suscripcion_Negocio);
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
    }
}
