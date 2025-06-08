using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Web.Mvc;
using ProyectoSistemaTurismo.Areas.Admin.Controllers;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Admin
{
    /// <summary>
    /// Pruebas de integración para Etiqueta_OfertaController en el área Admin.
    /// </summary>
    [TestClass]
    public class EtiquetaOfertaControllerIntegrationTests
    {

        /// <summary>
        /// Inicializa la base de datos solo una vez por clase antes de ejecutar las pruebas.
        /// </summary>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Verifica que Index retorna la vista con la lista de relaciones Etiqueta-Oferta.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new Etiqueta_OfertaController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo cuando la relación existe.
        /// </summary>
        [TestMethod]
        public void Detalles_EtiquetaOfertaExistente_RetornaVistaYModelo()
        {
            var controller = new Etiqueta_OfertaController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Etiqueta_Oferta));
        }

        /// <summary>
        /// Verifica que Detalles redirige a Index cuando la relación no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_EtiquetaOfertaNoExiste_RedireccionaIndex()
        {
            var controller = new Etiqueta_OfertaController();
            int id = 99999;

            var result = controller.Detalles(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (GET) retorna la vista.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVista()
        {
            var controller = new Etiqueta_OfertaController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new Etiqueta_OfertaController();
            var etiquetaOferta = new Etiqueta_Oferta
            {
                id_oferta = 1,
                id_etiqueta = 2
            };

            var result = controller.Crear(etiquetaOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos inválidos redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new Etiqueta_OfertaController();
            var etiquetaOferta = new Etiqueta_Oferta(); // No asigna datos obligatorios
            controller.ModelState.AddModelError("id_oferta", "Requerido");
            controller.ModelState.AddModelError("id_etiqueta", "Requerido");

            var result = controller.Crear(etiquetaOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Los datos ingresados no son válidos. No se pudo crear la relación.", controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo cuando la relación existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_EtiquetaOfertaExistente_RetornaVistaYModelo()
        {
            var controller = new Etiqueta_OfertaController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Etiqueta_Oferta));
        }

        /// <summary>
        /// Verifica que Editar (GET) redirige a Index si la relación no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_EtiquetaOfertaNoExiste_RedireccionaIndex()
        {
            var controller = new Etiqueta_OfertaController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new Etiqueta_OfertaController();
            var etiquetaOferta = new Etiqueta_Oferta
            {
                id_etiqueta_oferta = 1,
                id_oferta = 1,
                id_etiqueta = 2
            };

            var result = controller.Editar(etiquetaOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new Etiqueta_OfertaController();
            var etiquetaOferta = new Etiqueta_Oferta(); // Datos incompletos
            controller.ModelState.AddModelError("id_oferta", "Requerido");
            controller.ModelState.AddModelError("id_etiqueta", "Requerido");

            var result = controller.Editar(etiquetaOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Los datos ingresados no son válidos. No se pudo actualizar la relación.", controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina la relación Etiqueta-Oferta y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_EtiquetaOfertaExistente_RedireccionaAIndex()
        {
            var controller = new Etiqueta_OfertaController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        //
    }
}
