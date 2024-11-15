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
    public class HospedajeController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Hospedaje
        public ActionResult Index()
        {
            var hospedaje = db.Hospedaje.Include(h => h.Oferta);
            return View(hospedaje.ToList());
        }

        // GET: Admin/Hospedaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedaje hospedaje = db.Hospedaje.Find(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // GET: Admin/Hospedaje/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            return View();
        }

        // POST: Admin/Hospedaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_hospedaje,categoria,precio_minimo,precio_maximo,horario_checkin,horario_checkout,servicios_adicionales,capacidad,id_oferta")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                db.Hospedaje.Add(hospedaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", hospedaje.id_oferta);
            return View(hospedaje);
        }

        // GET: Admin/Hospedaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedaje hospedaje = db.Hospedaje.Find(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", hospedaje.id_oferta);
            return View(hospedaje);
        }

        // POST: Admin/Hospedaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_hospedaje,categoria,precio_minimo,precio_maximo,horario_checkin,horario_checkout,servicios_adicionales,capacidad,id_oferta")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospedaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", hospedaje.id_oferta);
            return View(hospedaje);
        }

        // GET: Admin/Hospedaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedaje hospedaje = db.Hospedaje.Find(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // POST: Admin/Hospedaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospedaje hospedaje = db.Hospedaje.Find(id);
            db.Hospedaje.Remove(hospedaje);
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
