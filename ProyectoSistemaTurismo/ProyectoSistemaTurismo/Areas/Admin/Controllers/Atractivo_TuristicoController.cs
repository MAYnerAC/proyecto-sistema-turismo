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
    public class Atractivo_TuristicoController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Atractivo_Turistico
        public ActionResult Index()
        {
            var atractivo_Turistico = db.Atractivo_Turistico.Include(a => a.Oferta);
            return View(atractivo_Turistico.ToList());
        }

        // GET: Admin/Atractivo_Turistico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atractivo_Turistico atractivo_Turistico = db.Atractivo_Turistico.Find(id);
            if (atractivo_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(atractivo_Turistico);
        }

        // GET: Admin/Atractivo_Turistico/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            return View();
        }

        // POST: Admin/Atractivo_Turistico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_atractivo,tipo_vegetacion,ubicacion_referencia,horario_apertura,horario_cierre,capacidad,id_oferta")] Atractivo_Turistico atractivo_Turistico)
        {
            if (ModelState.IsValid)
            {
                db.Atractivo_Turistico.Add(atractivo_Turistico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", atractivo_Turistico.id_oferta);
            return View(atractivo_Turistico);
        }

        // GET: Admin/Atractivo_Turistico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atractivo_Turistico atractivo_Turistico = db.Atractivo_Turistico.Find(id);
            if (atractivo_Turistico == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", atractivo_Turistico.id_oferta);
            return View(atractivo_Turistico);
        }

        // POST: Admin/Atractivo_Turistico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_atractivo,tipo_vegetacion,ubicacion_referencia,horario_apertura,horario_cierre,capacidad,id_oferta")] Atractivo_Turistico atractivo_Turistico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atractivo_Turistico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", atractivo_Turistico.id_oferta);
            return View(atractivo_Turistico);
        }

        // GET: Admin/Atractivo_Turistico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atractivo_Turistico atractivo_Turistico = db.Atractivo_Turistico.Find(id);
            if (atractivo_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(atractivo_Turistico);
        }

        // POST: Admin/Atractivo_Turistico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atractivo_Turistico atractivo_Turistico = db.Atractivo_Turistico.Find(id);
            db.Atractivo_Turistico.Remove(atractivo_Turistico);
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
