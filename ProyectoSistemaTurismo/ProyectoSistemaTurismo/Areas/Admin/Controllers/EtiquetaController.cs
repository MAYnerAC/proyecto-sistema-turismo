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
    public class EtiquetaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Etiqueta
        public ActionResult Index()
        {
            return View(db.Etiqueta.ToList());
        }

        // GET: Admin/Etiqueta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta);
        }

        // GET: Admin/Etiqueta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Etiqueta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_etiqueta,nombre_etiqueta,estado")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Etiqueta.Add(etiqueta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etiqueta);
        }

        // GET: Admin/Etiqueta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta);
        }

        // POST: Admin/Etiqueta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_etiqueta,nombre_etiqueta,estado")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiqueta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etiqueta);
        }

        // GET: Admin/Etiqueta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta);
        }

        // POST: Admin/Etiqueta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            db.Etiqueta.Remove(etiqueta);
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
