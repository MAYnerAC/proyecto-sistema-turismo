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
    public class OfertaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Oferta
        public ActionResult Index()
        {
            var oferta = db.Oferta.Include(o => o.Destino).Include(o => o.Tipo_Oferta).Include(o => o.Usuario);
            return View(oferta.ToList());
        }

        // GET: Admin/Oferta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Oferta.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // GET: Admin/Oferta/Create
        public ActionResult Create()
        {
            ViewBag.id_destino = new SelectList(db.Destino, "id_destino", "nombre_destino");
            ViewBag.id_tipo_oferta = new SelectList(db.Tipo_Oferta, "id_tipo_oferta", "nombre_tipo");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Oferta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_oferta,nombre,descripcion,direccion,ubicacion_lat,ubicacion_lon,telefono,email_contacto,sitio_web,vinculo_con_oferta,id_usuario,id_tipo_oferta,id_destino,fecha_creacion,estado,verificado,visible,fecha_baja,motivo_baja")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Oferta.Add(oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_destino = new SelectList(db.Destino, "id_destino", "nombre_destino", oferta.id_destino);
            ViewBag.id_tipo_oferta = new SelectList(db.Tipo_Oferta, "id_tipo_oferta", "nombre_tipo", oferta.id_tipo_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", oferta.id_usuario);
            return View(oferta);
        }

        // GET: Admin/Oferta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Oferta.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_destino = new SelectList(db.Destino, "id_destino", "nombre_destino", oferta.id_destino);
            ViewBag.id_tipo_oferta = new SelectList(db.Tipo_Oferta, "id_tipo_oferta", "nombre_tipo", oferta.id_tipo_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", oferta.id_usuario);
            return View(oferta);
        }

        // POST: Admin/Oferta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_oferta,nombre,descripcion,direccion,ubicacion_lat,ubicacion_lon,telefono,email_contacto,sitio_web,vinculo_con_oferta,id_usuario,id_tipo_oferta,id_destino,fecha_creacion,estado,verificado,visible,fecha_baja,motivo_baja")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_destino = new SelectList(db.Destino, "id_destino", "nombre_destino", oferta.id_destino);
            ViewBag.id_tipo_oferta = new SelectList(db.Tipo_Oferta, "id_tipo_oferta", "nombre_tipo", oferta.id_tipo_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", oferta.id_usuario);
            return View(oferta);
        }

        // GET: Admin/Oferta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Oferta.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // POST: Admin/Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferta oferta = db.Oferta.Find(id);
            db.Oferta.Remove(oferta);
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
