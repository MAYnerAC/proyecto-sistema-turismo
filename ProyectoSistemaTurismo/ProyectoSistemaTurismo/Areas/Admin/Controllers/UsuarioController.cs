using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

//
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using ProyectoSistemaTurismo.Filters;

namespace ProyectoSistemaTurismo.Areas.Admin.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(1)]
    public class UsuarioController : Controller
    {

        //private UsuarioService _usuarioService = new UsuarioService();
        //private Tipo_UsuarioService _tipoUsuarioService = new Tipo_UsuarioService();

        private UsuarioService _usuarioService;
        private Tipo_UsuarioService _tipoUsuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService(new ModeloSistema());
            _tipoUsuarioService = new Tipo_UsuarioService(new ModeloSistema());
        }



        public ActionResult Index()
        {
            var usuarios = _usuarioService.ObtenerTodos();
            return View(usuarios);
        }

        public ActionResult Detalles(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            if (usuario == null)
            {
                TempData["Error"] = "El usuario no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Crear()
        {
            var tiposUsuario = _tipoUsuarioService.ObtenerTodosActivos();
            ViewBag.TiposUsuario = new SelectList(tiposUsuario, "id_tipo_usuario", "nombre_tipo");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Agregar(usuario);
                TempData["Mensaje"] = "Usuario creado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear el usuario.";
            }

            return RedirectToAction("Index");

        }

        public ActionResult Editar(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            if (usuario == null)
            {
                TempData["Error"] = "El usuario no fue encontrado.";
                return RedirectToAction("Index");
            }

            var tiposUsuario = _tipoUsuarioService.ObtenerTodosActivos();
            ViewBag.TiposUsuario = new SelectList(tiposUsuario, "id_tipo_usuario", "nombre_tipo", usuario.id_tipo_usuario);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Actualizar(usuario);
                TempData["Mensaje"] = "Usuario actualizado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar el usuario.";
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            if (usuario == null)
            {
                TempData["Error"] = "El usuario no fue encontrado.";
                return RedirectToAction("Index");
            }

            _usuarioService.Eliminar(id);
            TempData["Mensaje"] = "Usuario eliminado con éxito.";
            return RedirectToAction("Index");
        }










        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Tipo_Usuario);
            return View(usuario.ToList());
        }

        // GET: Admin/Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Admin/Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre_tipo");
            return View();
        }

        // POST: Admin/Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre_tipo", usuario.id_tipo_usuario);
            return View(usuario);
        }

        // GET: Admin/Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre_tipo", usuario.id_tipo_usuario);
            return View(usuario);
        }

        // POST: Admin/Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre_tipo", usuario.id_tipo_usuario);
            return View(usuario);
        }

        // GET: Admin/Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Admin/Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
