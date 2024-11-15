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
    public class Tipo_OfertaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Tipo_Oferta
        public ActionResult Index()
        {
            return View(db.Tipo_Oferta.ToList());
        }

        // GET: Admin/Tipo_Oferta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Oferta tipo_Oferta = db.Tipo_Oferta.Find(id);
            if (tipo_Oferta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Oferta);
        }

        // GET: Admin/Tipo_Oferta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tipo_Oferta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_oferta,nombre_tipo,estado")] Tipo_Oferta tipo_Oferta)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Oferta.Add(tipo_Oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Oferta);
        }

        // GET: Admin/Tipo_Oferta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Oferta tipo_Oferta = db.Tipo_Oferta.Find(id);
            if (tipo_Oferta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Oferta);
        }

        // POST: Admin/Tipo_Oferta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_oferta,nombre_tipo,estado")] Tipo_Oferta tipo_Oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Oferta);
        }

        // GET: Admin/Tipo_Oferta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Oferta tipo_Oferta = db.Tipo_Oferta.Find(id);
            if (tipo_Oferta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Oferta);
        }

        // POST: Admin/Tipo_Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Oferta tipo_Oferta = db.Tipo_Oferta.Find(id);
            db.Tipo_Oferta.Remove(tipo_Oferta);
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
