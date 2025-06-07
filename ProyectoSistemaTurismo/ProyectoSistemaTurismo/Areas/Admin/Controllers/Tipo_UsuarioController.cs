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
    public class Tipo_UsuarioController : Controller
    {

        //private Tipo_UsuarioService _tipoUsuarioService = new Tipo_UsuarioService();

        private readonly Tipo_UsuarioService _tipoUsuarioService;

        public Tipo_UsuarioController()
        {
            _tipoUsuarioService = new Tipo_UsuarioService(new ModeloSistema());
        }

        public ActionResult Index()
        {
            var tiposUsuario = _tipoUsuarioService.ObtenerTodos();
            return View(tiposUsuario);
        }

        public ActionResult Detalles(int id)
        {
            var tipoUsuario = _tipoUsuarioService.ObtenerPorId(id);
            if (tipoUsuario == null)
            {
                TempData["Error"] = "El tipo de usuario no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(tipoUsuario);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Tipo_Usuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _tipoUsuarioService.Agregar(tipoUsuario);
                TempData["Mensaje"] = "Tipo de usuario creado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear el tipo de usuario.";
            }

            return RedirectToAction("Index");

        }

        public ActionResult Editar(int id)
        {
            var tipoUsuario = _tipoUsuarioService.ObtenerPorId(id);
            if (tipoUsuario == null)
            {
                TempData["Error"] = "El tipo de usuario no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(tipoUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Tipo_Usuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _tipoUsuarioService.Actualizar(tipoUsuario);
                TempData["Mensaje"] = "Tipo de usuario actualizado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar el tipo de usuario.";
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var tipoUsuario = _tipoUsuarioService.ObtenerPorId(id);
            if (tipoUsuario == null)
            {
                TempData["Error"] = "El tipo de usuario no fue encontrado.";
                return RedirectToAction("Index");
            }

            _tipoUsuarioService.Eliminar(id);
            TempData["Mensaje"] = "Tipo de usuario eliminado con éxito.";
            return RedirectToAction("Index");
        }











        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Tipo_Usuario
        public ActionResult Index()
        {
            return View(db.Tipo_Usuario.ToList());
        }

        // GET: Admin/Tipo_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            if (tipo_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Usuario);
        }

        // GET: Admin/Tipo_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tipo_Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_usuario,nombre_tipo,estado")] Tipo_Usuario tipo_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Usuario.Add(tipo_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Usuario);
        }

        // GET: Admin/Tipo_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            if (tipo_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Usuario);
        }

        // POST: Admin/Tipo_Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_usuario,nombre_tipo,estado")] Tipo_Usuario tipo_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Usuario);
        }

        // GET: Admin/Tipo_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            if (tipo_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Usuario);
        }

        // POST: Admin/Tipo_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            db.Tipo_Usuario.Remove(tipo_Usuario);
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
