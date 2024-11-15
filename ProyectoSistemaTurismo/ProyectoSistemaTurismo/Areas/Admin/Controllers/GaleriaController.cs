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
    public class GaleriaController : Controller
    {
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
    }
}
