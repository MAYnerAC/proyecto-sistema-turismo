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
    public class Foto_ComentarioController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Foto_Comentario
        public ActionResult Index()
        {
            var foto_Comentario = db.Foto_Comentario.Include(f => f.Comentario);
            return View(foto_Comentario.ToList());
        }

        // GET: Admin/Foto_Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            if (foto_Comentario == null)
            {
                return HttpNotFound();
            }
            return View(foto_Comentario);
        }

        // GET: Admin/Foto_Comentario/Create
        public ActionResult Create()
        {
            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1");
            return View();
        }

        // POST: Admin/Foto_Comentario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_foto,url_foto,descripcion,fecha_subida,estado,id_comentario")] Foto_Comentario foto_Comentario)
        {
            if (ModelState.IsValid)
            {
                db.Foto_Comentario.Add(foto_Comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1", foto_Comentario.id_comentario);
            return View(foto_Comentario);
        }

        // GET: Admin/Foto_Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            if (foto_Comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1", foto_Comentario.id_comentario);
            return View(foto_Comentario);
        }

        // POST: Admin/Foto_Comentario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_foto,url_foto,descripcion,fecha_subida,estado,id_comentario")] Foto_Comentario foto_Comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto_Comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_comentario = new SelectList(db.Comentario, "id_comentario", "comentario1", foto_Comentario.id_comentario);
            return View(foto_Comentario);
        }

        // GET: Admin/Foto_Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            if (foto_Comentario == null)
            {
                return HttpNotFound();
            }
            return View(foto_Comentario);
        }

        // POST: Admin/Foto_Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foto_Comentario foto_Comentario = db.Foto_Comentario.Find(id);
            db.Foto_Comentario.Remove(foto_Comentario);
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
