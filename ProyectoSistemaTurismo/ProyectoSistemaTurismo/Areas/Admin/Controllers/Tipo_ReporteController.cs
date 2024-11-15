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
    public class Tipo_ReporteController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Tipo_Reporte
        public ActionResult Index()
        {
            return View(db.Tipo_Reporte.ToList());
        }

        // GET: Admin/Tipo_Reporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Reporte tipo_Reporte = db.Tipo_Reporte.Find(id);
            if (tipo_Reporte == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Reporte);
        }

        // GET: Admin/Tipo_Reporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tipo_Reporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_reporte,nombre_tipo,estado")] Tipo_Reporte tipo_Reporte)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Reporte.Add(tipo_Reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Reporte);
        }

        // GET: Admin/Tipo_Reporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Reporte tipo_Reporte = db.Tipo_Reporte.Find(id);
            if (tipo_Reporte == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Reporte);
        }

        // POST: Admin/Tipo_Reporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_reporte,nombre_tipo,estado")] Tipo_Reporte tipo_Reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Reporte);
        }

        // GET: Admin/Tipo_Reporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Reporte tipo_Reporte = db.Tipo_Reporte.Find(id);
            if (tipo_Reporte == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Reporte);
        }

        // POST: Admin/Tipo_Reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Reporte tipo_Reporte = db.Tipo_Reporte.Find(id);
            db.Tipo_Reporte.Remove(tipo_Reporte);
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
