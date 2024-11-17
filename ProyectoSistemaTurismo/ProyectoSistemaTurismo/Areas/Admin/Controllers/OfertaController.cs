using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaTurismo.Filters;

//
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;

namespace ProyectoSistemaTurismo.Areas.Admin.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(1)]
    [ManejoErroresFiltro]
    public class OfertaController : Controller
    {
        private readonly OfertaService _ofertaService = new OfertaService();
        //private readonly DestinoService destinoService = new DestinoService();
        //private readonly TipoOfertaService tipoOfertaService = new TipoOfertaService();

        private void CargarRelaciones()
        {
            //var destinos = destinoService.ObtenerTodosActivos();
            //var tiposOferta = tipoOfertaService.ObtenerTodosActivos();

            //ViewBag.Destinos = new SelectList(destinos, "id_destino", "nombre_destino");
            //ViewBag.TiposOferta = new SelectList(tiposOferta, "id_tipo_oferta", "nombre_tipo");
        }
        public ActionResult Index()
        {
            var ofertas = _ofertaService.ObtenerTodos();
            return View(ofertas);
        }

        public ActionResult Detalles(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(oferta);
        }

        public ActionResult Crear()
        {
            CargarRelaciones();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _ofertaService.Agregar(oferta);
                TempData["Mensaje"] = "Oferta creada con éxito.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Por favor corrige los errores del formulario.";
            CargarRelaciones();
            return View(oferta);
        }

        public ActionResult Editar(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }

            CargarRelaciones();
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _ofertaService.Actualizar(oferta);
                TempData["Mensaje"] = "Oferta actualizada con éxito.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Por favor corrige los errores del formulario.";
            CargarRelaciones();
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }

            _ofertaService.Eliminar(id);
            TempData["Mensaje"] = "Oferta eliminada con éxito.";
            return RedirectToAction("Index");
        }


        /*-------------------------------------------------------------------------------------------------------*/

        /*
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
        */


        //
    }
}
