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
    public class DestinoController : Controller
    {


        private DestinoService _destinoService = new DestinoService();


        // GET: Admin/Destino
        public ActionResult Index()
        {
            var destinos = _destinoService.ObtenerTodos();
            return View(destinos);
        }

        // GET: Admin/Destino/Detalles/5
        public ActionResult Detalles(int id)
        {
            var destino = _destinoService.ObtenerPorId(id);
            if (destino == null)
            {
                TempData["Error"] = "El destino no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: Admin/Destino/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Admin/Destino/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Destino destino)
        {
            if (ModelState.IsValid)
            {
                _destinoService.Agregar(destino);
                TempData["Mensaje"] = "Destino creado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear el destino.";
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Destino/Editar/5
        public ActionResult Editar(int id)
        {
            var destino = _destinoService.ObtenerPorId(id);
            if (destino == null)
            {
                TempData["Error"] = "El destino no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // POST: Admin/Destino/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Destino destino)
        {
            if (ModelState.IsValid)
            {
                _destinoService.Actualizar(destino);
                TempData["Mensaje"] = "Destino actualizado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar el destino.";
            }

            return RedirectToAction("Index");
        }

        // POST: Admin/Destino/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var destino = _destinoService.ObtenerPorId(id);
            if (destino == null)
            {
                TempData["Error"] = "El destino no fue encontrado.";
                return RedirectToAction("Index");
            }

            _destinoService.Eliminar(id);
            TempData["Mensaje"] = "Destino eliminado con éxito.";
            return RedirectToAction("Index");
        }

















        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Destino
        public ActionResult Index()
        {
            return View(db.Destino.ToList());
        }

        // GET: Admin/Destino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // GET: Admin/Destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Destino/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_destino,nombre_destino,tipo_destino,descripcion,pais,estado")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Destino.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET: Admin/Destino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Admin/Destino/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_destino,nombre_destino,tipo_destino,descripcion,pais,estado")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: Admin/Destino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Admin/Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destino.Find(id);
            db.Destino.Remove(destino);
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
