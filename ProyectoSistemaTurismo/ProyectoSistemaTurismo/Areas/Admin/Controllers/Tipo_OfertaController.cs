using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;

namespace ProyectoSistemaTurismo.Areas.Admin.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(1)]
    public class Tipo_OfertaController : Controller
    {

        private Tipo_OfertaService tipoOfertaService = new Tipo_OfertaService();

        public ActionResult Index()
        {
            var tiposOferta = tipoOfertaService.ObtenerTodos();
            return View(tiposOferta);
        }

        public ActionResult Detalles(int id)
        {
            var tipoOferta = tipoOfertaService.ObtenerPorId(id);
            if (tipoOferta == null)
            {
                TempData["Error"] = "El tipo de oferta no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(tipoOferta);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Tipo_Oferta tipoOferta)
        {
            if (ModelState.IsValid)
            {
                tipoOfertaService.Agregar(tipoOferta);
                TempData["Mensaje"] = "Tipo de oferta creado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear el tipo de oferta.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var tipoOferta = tipoOfertaService.ObtenerPorId(id);
            if (tipoOferta == null)
            {
                TempData["Error"] = "El tipo de oferta no fue encontrado.";
                return RedirectToAction("Index");
            }

            return View(tipoOferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Tipo_Oferta tipoOferta)
        {
            if (ModelState.IsValid)
            {
                tipoOfertaService.Actualizar(tipoOferta);
                TempData["Mensaje"] = "Tipo de oferta actualizado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar el tipo de oferta.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var tipoOferta = tipoOfertaService.ObtenerPorId(id);
            if (tipoOferta == null)
            {
                TempData["Error"] = "El tipo de oferta no fue encontrado.";
                return RedirectToAction("Index");
            }

            tipoOfertaService.Eliminar(id);
            TempData["Mensaje"] = "Tipo de oferta eliminado con éxito.";
            return RedirectToAction("Index");
        }






        /*
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


        */
    }
}
