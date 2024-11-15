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
    public class Estado_ReporteController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Estado_Reporte
        public ActionResult Index()
        {
            return View(db.Estado_Reporte.ToList());
        }

        // GET: Admin/Estado_Reporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Reporte estado_Reporte = db.Estado_Reporte.Find(id);
            if (estado_Reporte == null)
            {
                return HttpNotFound();
            }
            return View(estado_Reporte);
        }

        // GET: Admin/Estado_Reporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Estado_Reporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_reporte,nombre_estado")] Estado_Reporte estado_Reporte)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Reporte.Add(estado_Reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Reporte);
        }

        // GET: Admin/Estado_Reporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Reporte estado_Reporte = db.Estado_Reporte.Find(id);
            if (estado_Reporte == null)
            {
                return HttpNotFound();
            }
            return View(estado_Reporte);
        }

        // POST: Admin/Estado_Reporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_reporte,nombre_estado")] Estado_Reporte estado_Reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Reporte);
        }

        // GET: Admin/Estado_Reporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Reporte estado_Reporte = db.Estado_Reporte.Find(id);
            if (estado_Reporte == null)
            {
                return HttpNotFound();
            }
            return View(estado_Reporte);
        }

        // POST: Admin/Estado_Reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Reporte estado_Reporte = db.Estado_Reporte.Find(id);
            db.Estado_Reporte.Remove(estado_Reporte);
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
