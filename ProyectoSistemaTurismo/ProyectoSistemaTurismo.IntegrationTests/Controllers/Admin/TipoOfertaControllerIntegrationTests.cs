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
    /// Pruebas de integración para TipoOfertaController en el área Admin.
    /// </summary>
    [TestClass]
    public class TipoOfertaControllerIntegrationTests
    {
        /// <summary>
        /// Inicializa la base de datos solo una vez por clase antes de ejecutar las pruebas.
        /// </summary>
        /// <param name="context">Contexto de prueba de MSTest.</param>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Verifica que la acción Index retorne una vista y un modelo de tipo IEnumerable.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new Tipo_OfertaController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result, "La vista no debe ser nula.");
            Assert.IsNotNull(result.Model, "El modelo no debe ser nulo.");
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable), "El modelo debe ser IEnumerable.");
        }

        /// <summary>
        /// Verifica que la acción Detalles retorne la vista y el modelo esperado cuando el registro existe.
        /// </summary>
        [TestMethod]
        public void Detalles_TipoOfertaExistente_RetornaVistaYModelo()
        {
            var controller = new Tipo_OfertaController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result, "La vista no debe ser nula.");
            Assert.IsNotNull(result.Model, "El modelo no debe ser nulo.");
            Assert.IsInstanceOfType(result.Model, typeof(Tipo_Oferta), "El modelo debe ser Tipo_Oferta.");
        }

        /// <summary>
        /// Verifica que la acción Detalles redirija a Index si el tipo de oferta no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_TipoOfertaNoExiste_RedireccionaIndex()
        {
            var controller = new Tipo_OfertaController();
            int id = 99999; // ID inexistente

            var result = controller.Detalles(id) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redirigir si no existe el registro.");
            Assert.AreEqual("Index", result.RouteValues["action"], "Debe redirigir a Index.");
        }

        /// <summary>
        /// Verifica que la acción Crear (GET) retorne la vista de creación.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVista()
        {
            var controller = new Tipo_OfertaController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result, "La vista de creación no debe ser nula.");
        }

        /// <summary>
        /// Verifica que la acción Crear (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Crear_Post_TipoOfertaValido_RedireccionaAIndex()
        {
            var controller = new Tipo_OfertaController();
            var tipoOferta = new Tipo_Oferta
            {
                nombre_tipo = "Oferta Test",
                estado = "A"
            };

            var result = controller.Crear(tipoOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redirigir tras creación exitosa.");
            Assert.AreEqual("Index", result.RouteValues["action"], "Debe redirigir a Index tras crear.");
        }

        /// <summary>
        /// Verifica que la acción Crear (POST) con datos inválidos no crea el tipo de oferta y retorna error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_TipoOfertaInvalido_NoRedirigeYSeteaError()
        {
            var controller = new Tipo_OfertaController();
            var tipoOferta = new Tipo_Oferta
            {
                // nombre_tipo es requerido, lo dejamos vacío
                estado = "A"
            };
            controller.ModelState.AddModelError("nombre_tipo", "El nombre es obligatorio.");

            var result = controller.Crear(tipoOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que la acción Editar (GET) retorne la vista y modelo esperados cuando el registro existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_TipoOfertaExistente_RetornaVistaYModelo()
        {
            var controller = new Tipo_OfertaController();
            int id = 1; // Debe existir

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result, "La vista no debe ser nula.");
            Assert.IsNotNull(result.Model, "El modelo no debe ser nulo.");
            Assert.IsInstanceOfType(result.Model, typeof(Tipo_Oferta), "El modelo debe ser Tipo_Oferta.");
        }

        /// <summary>
        /// Verifica que la acción Editar (GET) redirija a Index si el tipo de oferta no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_TipoOfertaNoExiste_RedireccionaIndex()
        {
            var controller = new Tipo_OfertaController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redirigir si no existe el registro.");
            Assert.AreEqual("Index", result.RouteValues["action"], "Debe redirigir a Index.");
        }

        /// <summary>
        /// Verifica que la acción Editar (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Editar_Post_TipoOfertaValido_RedireccionaAIndex()
        {
            var controller = new Tipo_OfertaController();
            var tipoOferta = new Tipo_Oferta
            {
                id_tipo_oferta = 1,
                nombre_tipo = "Actualizado Test",
                estado = "A"
            };

            var result = controller.Editar(tipoOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redirigir tras edición exitosa.");
            Assert.AreEqual("Index", result.RouteValues["action"], "Debe redirigir a Index tras editar.");
        }

        /// <summary>
        /// Verifica que la acción Editar (POST) con datos inválidos no actualiza y retorna error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_TipoOfertaInvalido_NoRedirigeYSeteaError()
        {
            var controller = new Tipo_OfertaController();
            var tipoOferta = new Tipo_Oferta
            {
                id_tipo_oferta = 1,
                // nombre_tipo es requerido
                estado = "A"
            };
            controller.ModelState.AddModelError("nombre_tipo", "El nombre es obligatorio.");

            var result = controller.Editar(tipoOferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que la acción Eliminar elimine un tipo de oferta existente y redirija a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_TipoOfertaExistente_RedireccionaAIndex()
        {
            var controller = new Tipo_OfertaController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redirigir tras eliminar.");
            Assert.AreEqual("Index", result.RouteValues["action"], "Debe redirigir a Index tras eliminar.");
        }

        /// <summary>
        /// Verifica que la acción Eliminar con tipo de oferta inexistente redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Eliminar_TipoOfertaNoExistente_RedireccionaAIndexYError()
        {
            var controller = new Tipo_OfertaController();
            int id = 99999;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        //
    }
}
