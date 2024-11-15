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
    public class Log_VisitasController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Log_Visitas
        public ActionResult Index()
        {
            var log_Visitas = db.Log_Visitas.Include(l => l.Oferta).Include(l => l.Usuario);
            return View(log_Visitas.ToList());
        }

        // GET: Admin/Log_Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log_Visitas log_Visitas = db.Log_Visitas.Find(id);
            if (log_Visitas == null)
            {
                return HttpNotFound();
            }
            return View(log_Visitas);
        }

        // GET: Admin/Log_Visitas/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Log_Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_log,fecha_visita,estado,id_oferta,id_usuario")] Log_Visitas log_Visitas)
        {
            if (ModelState.IsValid)
            {
                db.Log_Visitas.Add(log_Visitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", log_Visitas.id_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", log_Visitas.id_usuario);
            return View(log_Visitas);
        }

        // GET: Admin/Log_Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log_Visitas log_Visitas = db.Log_Visitas.Find(id);
            if (log_Visitas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", log_Visitas.id_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", log_Visitas.id_usuario);
            return View(log_Visitas);
        }

        // POST: Admin/Log_Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_log,fecha_visita,estado,id_oferta,id_usuario")] Log_Visitas log_Visitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log_Visitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", log_Visitas.id_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", log_Visitas.id_usuario);
            return View(log_Visitas);
        }

        // GET: Admin/Log_Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log_Visitas log_Visitas = db.Log_Visitas.Find(id);
            if (log_Visitas == null)
            {
                return HttpNotFound();
            }
            return View(log_Visitas);
        }

        // POST: Admin/Log_Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Log_Visitas log_Visitas = db.Log_Visitas.Find(id);
            db.Log_Visitas.Remove(log_Visitas);
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
