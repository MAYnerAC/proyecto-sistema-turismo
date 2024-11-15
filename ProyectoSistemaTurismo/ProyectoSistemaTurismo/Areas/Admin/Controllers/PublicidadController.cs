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
    public class PublicidadController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Publicidad
        public ActionResult Index()
        {
            var publicidad = db.Publicidad.Include(p => p.Oferta);
            return View(publicidad.ToList());
        }

        // GET: Admin/Publicidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        // GET: Admin/Publicidad/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            return View();
        }

        // POST: Admin/Publicidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_publicidad,tipo_publicidad,fecha_inicio,fecha_fin,prioridad,estado,id_oferta")] Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Publicidad.Add(publicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", publicidad.id_oferta);
            return View(publicidad);
        }

        // GET: Admin/Publicidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", publicidad.id_oferta);
            return View(publicidad);
        }

        // POST: Admin/Publicidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_publicidad,tipo_publicidad,fecha_inicio,fecha_fin,prioridad,estado,id_oferta")] Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", publicidad.id_oferta);
            return View(publicidad);
        }

        // GET: Admin/Publicidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        // POST: Admin/Publicidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicidad publicidad = db.Publicidad.Find(id);
            db.Publicidad.Remove(publicidad);
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
