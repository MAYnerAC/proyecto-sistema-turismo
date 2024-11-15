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
    public class ReporteController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Reporte
        public ActionResult Index()
        {
            var reporte = db.Reporte.Include(r => r.Estado_Reporte).Include(r => r.Oferta).Include(r => r.Tipo_Reporte).Include(r => r.Usuario);
            return View(reporte.ToList());
        }

        // GET: Admin/Reporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // GET: Admin/Reporte/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_reporte = new SelectList(db.Estado_Reporte, "id_estado_reporte", "nombre_estado");
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            ViewBag.id_tipo_reporte = new SelectList(db.Tipo_Reporte, "id_tipo_reporte", "nombre_tipo");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Reporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reporte,descripcion,fecha_reporte,estado,id_usuario,id_oferta,id_tipo_reporte,id_estado_reporte")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Reporte.Add(reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado_reporte = new SelectList(db.Estado_Reporte, "id_estado_reporte", "nombre_estado", reporte.id_estado_reporte);
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", reporte.id_oferta);
            ViewBag.id_tipo_reporte = new SelectList(db.Tipo_Reporte, "id_tipo_reporte", "nombre_tipo", reporte.id_tipo_reporte);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", reporte.id_usuario);
            return View(reporte);
        }

        // GET: Admin/Reporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado_reporte = new SelectList(db.Estado_Reporte, "id_estado_reporte", "nombre_estado", reporte.id_estado_reporte);
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", reporte.id_oferta);
            ViewBag.id_tipo_reporte = new SelectList(db.Tipo_Reporte, "id_tipo_reporte", "nombre_tipo", reporte.id_tipo_reporte);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", reporte.id_usuario);
            return View(reporte);
        }

        // POST: Admin/Reporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reporte,descripcion,fecha_reporte,estado,id_usuario,id_oferta,id_tipo_reporte,id_estado_reporte")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado_reporte = new SelectList(db.Estado_Reporte, "id_estado_reporte", "nombre_estado", reporte.id_estado_reporte);
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", reporte.id_oferta);
            ViewBag.id_tipo_reporte = new SelectList(db.Tipo_Reporte, "id_tipo_reporte", "nombre_tipo", reporte.id_tipo_reporte);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", reporte.id_usuario);
            return View(reporte);
        }

        // GET: Admin/Reporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // POST: Admin/Reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte reporte = db.Reporte.Find(id);
            db.Reporte.Remove(reporte);
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
