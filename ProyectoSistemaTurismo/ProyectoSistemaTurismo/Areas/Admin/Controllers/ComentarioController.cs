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
    public class ComentarioController : Controller
    {
        private ComentarioService _comentarioService = new ComentarioService();
        //private OfertaService ofertaService = new OfertaService();
        //private UsuarioService usuarioService = new UsuarioService();

        //private readonly ComentarioService _comentarioService;
        private readonly OfertaService _ofertaService;
        private readonly UsuarioService _usuarioService;

        public ComentarioController()
        {
            //_comentarioService = new ComentarioService(new ModeloSistema());
            _ofertaService = new OfertaService(new ModeloSistema());
            _usuarioService = new UsuarioService(new ModeloSistema());
        }

        public ActionResult Index()
        {
            var comentarios = _comentarioService.ObtenerTodos();
            return View(comentarios);
        }

        public ActionResult Detalles(int id)
        {
            var comentario = _comentarioService.ObtenerPorId(id);
            if (comentario == null)
            {
                TempData["Error"] = "El comentario no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        public ActionResult Crear()
        {
            var ofertas = _ofertaService.ObtenerTodosActivos();
            var usuarios = _usuarioService.ObtenerTodosActivos();

            ViewBag.Ofertas = new SelectList(ofertas, "id_oferta", "nombre");
            ViewBag.Usuarios = new SelectList(usuarios, "id_usuario", "nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _comentarioService.Agregar(comentario);
                TempData["Mensaje"] = "Comentario creado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear el comentario.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var comentario = _comentarioService.ObtenerPorId(id);
            if (comentario == null)
            {
                TempData["Error"] = "El comentario no fue encontrado.";
                return RedirectToAction("Index");
            }

            var ofertas = _ofertaService.ObtenerTodosActivos();
            var usuarios = _usuarioService.ObtenerTodosActivos();

            ViewBag.Ofertas = new SelectList(ofertas, "id_oferta", "nombre", comentario.id_oferta);
            ViewBag.Usuarios = new SelectList(usuarios, "id_usuario", "nombre", comentario.id_usuario);

            return View(comentario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _comentarioService.Actualizar(comentario);
                TempData["Mensaje"] = "Comentario actualizado con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar el comentario.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var comentario = _comentarioService.ObtenerPorId(id);
            if (comentario == null)
            {
                TempData["Error"] = "El comentario no fue encontrado.";
                return RedirectToAction("Index");
            }

            _comentarioService.Eliminar(id);
            TempData["Mensaje"] = "Comentario eliminado con éxito.";
            return RedirectToAction("Index");
        }









        /*
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Comentario
        public ActionResult Index()
        {
            var comentario = db.Comentario.Include(c => c.Oferta).Include(c => c.Usuario);
            return View(comentario.ToList());
        }

        // GET: Admin/Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Admin/Comentario/Create
        public ActionResult Create()
        {
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Comentario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_comentario,comentario1,puntuacion,fecha_comentario,estado,id_oferta,id_usuario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", comentario.id_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", comentario.id_usuario);
            return View(comentario);
        }

        // GET: Admin/Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", comentario.id_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", comentario.id_usuario);
            return View(comentario);
        }

        // POST: Admin/Comentario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_comentario,comentario1,puntuacion,fecha_comentario,estado,id_oferta,id_usuario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_oferta = new SelectList(db.Oferta, "id_oferta", "nombre", comentario.id_oferta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", comentario.id_usuario);
            return View(comentario);
        }

        // GET: Admin/Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Admin/Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
