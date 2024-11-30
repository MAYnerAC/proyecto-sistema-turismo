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
    public class Preferencias_UsuarioController : Controller
    {




        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Preferencias_Usuario
        public ActionResult Index()
        {
            var preferencias_Usuario = db.Preferencias_Usuario.Include(p => p.Etiqueta).Include(p => p.Usuario);
            return View(preferencias_Usuario.ToList());
        }

        // GET: Admin/Preferencias_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferencias_Usuario preferencias_Usuario = db.Preferencias_Usuario.Find(id);
            if (preferencias_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(preferencias_Usuario);
        }

        // GET: Admin/Preferencias_Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Preferencias_Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_preferencia,estado,id_usuario,id_etiqueta")] Preferencias_Usuario preferencias_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Preferencias_Usuario.Add(preferencias_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta", preferencias_Usuario.id_etiqueta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", preferencias_Usuario.id_usuario);
            return View(preferencias_Usuario);
        }

        // GET: Admin/Preferencias_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferencias_Usuario preferencias_Usuario = db.Preferencias_Usuario.Find(id);
            if (preferencias_Usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta", preferencias_Usuario.id_etiqueta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", preferencias_Usuario.id_usuario);
            return View(preferencias_Usuario);
        }

        // POST: Admin/Preferencias_Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_preferencia,estado,id_usuario,id_etiqueta")] Preferencias_Usuario preferencias_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preferencias_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_etiqueta = new SelectList(db.Etiqueta, "id_etiqueta", "nombre_etiqueta", preferencias_Usuario.id_etiqueta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", preferencias_Usuario.id_usuario);
            return View(preferencias_Usuario);
        }

        // GET: Admin/Preferencias_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferencias_Usuario preferencias_Usuario = db.Preferencias_Usuario.Find(id);
            if (preferencias_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(preferencias_Usuario);
        }

        // POST: Admin/Preferencias_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preferencias_Usuario preferencias_Usuario = db.Preferencias_Usuario.Find(id);
            db.Preferencias_Usuario.Remove(preferencias_Usuario);
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



        */
    }
}
