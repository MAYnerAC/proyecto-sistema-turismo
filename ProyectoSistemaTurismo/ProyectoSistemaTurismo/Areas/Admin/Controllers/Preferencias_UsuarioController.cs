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
    public class Preferencias_UsuarioController : Controller
    {

        private Preferencias_UsuarioService _preferenciasUsuarioService = new Preferencias_UsuarioService();
        private UsuarioService usuarioService = new UsuarioService();
        private EtiquetaService etiquetaService = new EtiquetaService();

        public ActionResult Index()
        {
            var preferenciasUsuarios = _preferenciasUsuarioService.ObtenerTodos();
            return View(preferenciasUsuarios);
        }

        public ActionResult Detalles(int id)
        {
            var preferenciaUsuario = _preferenciasUsuarioService.ObtenerPorId(id);
            if (preferenciaUsuario == null)
            {
                TempData["Error"] = "La preferencia de usuario no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(preferenciaUsuario);
        }

        public ActionResult Crear()
        {
            var usuarios = usuarioService.ObtenerTodosActivos();
            var etiquetas = etiquetaService.ObtenerTodosActivos();

            ViewBag.Usuarios = new SelectList(usuarios, "id_usuario", "nombre");
            ViewBag.Etiquetas = new SelectList(etiquetas, "id_etiqueta", "nombre_etiqueta");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Preferencias_Usuario preferenciaUsuario)
        {
            if (ModelState.IsValid)
            {
                _preferenciasUsuarioService.Agregar(preferenciaUsuario);
                TempData["Mensaje"] = "Preferencia de usuario creada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear la preferencia de usuario.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var preferenciaUsuario = _preferenciasUsuarioService.ObtenerPorId(id);
            if (preferenciaUsuario == null)
            {
                TempData["Error"] = "La preferencia de usuario no fue encontrada.";
                return RedirectToAction("Index");
            }

            var usuarios = usuarioService.ObtenerTodosActivos();
            var etiquetas = etiquetaService.ObtenerTodosActivos();

            ViewBag.Usuarios = new SelectList(usuarios, "id_usuario", "nombre", preferenciaUsuario.id_usuario);
            ViewBag.Etiquetas = new SelectList(etiquetas, "id_etiqueta", "nombre_etiqueta", preferenciaUsuario.id_etiqueta);

            return View(preferenciaUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Preferencias_Usuario preferenciaUsuario)
        {
            if (ModelState.IsValid)
            {
                _preferenciasUsuarioService.Actualizar(preferenciaUsuario);
                TempData["Mensaje"] = "Preferencia de usuario actualizada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar la preferencia de usuario.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var preferenciaUsuario = _preferenciasUsuarioService.ObtenerPorId(id);
            if (preferenciaUsuario == null)
            {
                TempData["Error"] = "La preferencia de usuario no fue encontrada.";
                return RedirectToAction("Index");
            }

            _preferenciasUsuarioService.Eliminar(id);
            TempData["Mensaje"] = "Preferencia de usuario eliminada con éxito.";
            return RedirectToAction("Index");
        }


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
