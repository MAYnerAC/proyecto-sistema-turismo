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
    public class Etiqueta_OfertaController : Controller
    {
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
    }
}
