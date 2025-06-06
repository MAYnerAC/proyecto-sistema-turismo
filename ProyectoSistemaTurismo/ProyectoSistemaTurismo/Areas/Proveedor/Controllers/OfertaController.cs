using ProyectoSistemaTurismo.Filters;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Areas.Proveedor.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(2)]
    public class OfertaController : Controller
    {

        private OfertaService _ofertaService = new OfertaService();
        private DestinoService destinoService = new DestinoService();
        //private Tipo_OfertaService tipoOfertaService = new Tipo_OfertaService();

        //private readonly OfertaService _ofertaService;
        //private readonly DestinoService _destinoService;
        private readonly Tipo_OfertaService _tipoOfertaService;

        public OfertaController()
        {
            //_ofertaService = new OfertaService(new ModeloSistema());
            //_destinoService = new DestinoService(new ModeloSistema());
            _tipoOfertaService = new Tipo_OfertaService(new ModeloSistema());
        }

        // Seleccionar una oferta
        //post
        public ActionResult Seleccionar(int idOferta)
        {
            var ofertaSeleccionada = _ofertaService.ObtenerPorId(idOferta);

            if (ofertaSeleccionada != null)
            {
                Session["OfertaId"] = ofertaSeleccionada.id_oferta;
                Session["OfertaNombre"] = ofertaSeleccionada.nombre;
                Session["id_tipo_oferta"] = ofertaSeleccionada.id_tipo_oferta;
                Session["OfertaTipo"] = ofertaSeleccionada.Tipo_Oferta.nombre_tipo;
                Session["id_destino"] = ofertaSeleccionada.id_destino;
                Session["OfertaDestino"] = ofertaSeleccionada.Destino?.nombre_destino;
                Session["OfertaSitioWeb"] = ofertaSeleccionada.sitio_web;

                if (Request.UrlReferrer != null)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }

                return RedirectToAction("MisOfertas", "Oferta", new { area = "Proveedor" });
            }
            else
            {
                TempData["mensaje"] = "No se encontró la oferta seleccionada.";
                return RedirectToAction("MisOfertas", "Oferta", new { area = "Proveedor" });
            }
        }




        public PartialViewResult ListaOfertasUsuario()
        {
            int idUsuario = (int)Session["id_usuario"];

            var ofertas = _ofertaService.ObtenerPorUsuario(idUsuario);

            return PartialView(ofertas);
        }


        public ActionResult MisOfertas()
        {
            int usuarioId = (int)Session["id_usuario"];

            var ofertas = _ofertaService.ObtenerPorUsuario(usuarioId);

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
            var destinos = destinoService.ObtenerTodosActivos();
            var tiposOferta = _tipoOfertaService.ObtenerTodosActivos();

            ViewBag.Destinos = new SelectList(destinos, "id_destino", "nombre_destino");
            ViewBag.TiposOferta = new SelectList(tiposOferta, "id_tipo_oferta", "nombre_tipo");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                int usuarioId = (int)Session["id_usuario"];
                oferta.id_usuario = usuarioId;

                _ofertaService.Agregar(oferta);
                TempData["Mensaje"] = "Oferta creada con éxito.";
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo crear la oferta.";
            }

            return RedirectToAction("MisOfertas");
        }




        public ActionResult Editar(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("MisOfertas");
            }

            var destinos = destinoService.ObtenerTodosActivos();
            var tiposOferta = _tipoOfertaService.ObtenerTodosActivos();

            ViewBag.Destinos = new SelectList(destinos, "id_destino", "nombre_destino", oferta.id_destino);
            ViewBag.TiposOferta = new SelectList(tiposOferta, "id_tipo_oferta", "nombre_tipo", oferta.id_tipo_oferta);

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
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos. No se pudo actualizar la oferta.";
            }

            return RedirectToAction("MisOfertas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("MisOfertas");
            }

            _ofertaService.Eliminar(id);
            TempData["Mensaje"] = "Oferta eliminada con éxito.";
            return RedirectToAction("MisOfertas");
        }




        //
    }
}