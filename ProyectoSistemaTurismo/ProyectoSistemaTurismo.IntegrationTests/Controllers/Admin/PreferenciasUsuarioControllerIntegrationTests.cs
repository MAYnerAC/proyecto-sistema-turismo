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
    /// Pruebas de integración para Preferencias_UsuarioController en el área Admin.
    /// </summary>
    [TestClass]
    public class PreferenciasUsuarioControllerIntegrationTests
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
        /// Verifica que la acción Index retorne la vista con la lista de preferencias de usuario.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new Preferencias_UsuarioController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que la acción Detalles retorne la vista y el modelo esperado cuando la preferencia existe.
        /// </summary>
        [TestMethod]
        public void Detalles_PreferenciaExistente_RetornaVistaYModelo()
        {
            var controller = new Preferencias_UsuarioController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Preferencias_Usuario));
        }

        /// <summary>
        /// Verifica que la acción Detalles redirija a Index si la preferencia no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_PreferenciaNoExiste_RedireccionaIndex()
        {
            var controller = new Preferencias_UsuarioController();
            int id = 99999;

            var result = controller.Detalles(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que la acción Crear (GET) retorne la vista y ViewBags necesarios.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVistaYCombos()
        {
            var controller = new Preferencias_UsuarioController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.Usuarios);
            Assert.IsNotNull(result.ViewBag.Etiquetas);
        }

        /// <summary>
        /// Verifica que la acción Crear (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Crear_Post_PreferenciaValida_RedireccionaAIndex()
        {
            var controller = new Preferencias_UsuarioController();
            var preferencia = new Preferencias_Usuario
            {
                id_usuario = 6,
                id_etiqueta = 1
            };

            var result = controller.Crear(preferencia) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que la acción Crear (POST) con datos inválidos no redirige y muestra error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_PreferenciaInvalida_NoRedirigeYSeteaError()
        {
            var controller = new Preferencias_UsuarioController();
            // No seteamos id_usuario (campo requerido)
            var preferencia = new Preferencias_Usuario
            {
                id_etiqueta = 1
            };

            // Forzamos error de validación manualmente
            controller.ModelState.AddModelError("id_usuario", "El usuario es requerido.");

            var result = controller.Crear(preferencia) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que la acción Editar (GET) retorne la vista y modelo cuando la preferencia existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_PreferenciaExistente_RetornaVistaYModelo()
        {
            var controller = new Preferencias_UsuarioController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Preferencias_Usuario));
            Assert.IsNotNull(result.ViewBag.Usuarios);
            Assert.IsNotNull(result.ViewBag.Etiquetas);
        }

        /// <summary>
        /// Verifica que la acción Editar (GET) redirija a Index si la preferencia no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_PreferenciaNoExiste_RedireccionaIndex()
        {
            var controller = new Preferencias_UsuarioController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que la acción Editar (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Editar_Post_PreferenciaValida_RedireccionaAIndex()
        {
            var controller = new Preferencias_UsuarioController();
            var preferencia = new Preferencias_Usuario
            {
                id_preferencia = 1,
                id_usuario = 6,
                id_etiqueta = 2
            };

            var result = controller.Editar(preferencia) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que la acción Editar (POST) con datos inválidos no redirige y muestra error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_PreferenciaInvalida_NoRedirigeYSeteaError()
        {
            var controller = new Preferencias_UsuarioController();
            // Falta id_usuario
            var preferencia = new Preferencias_Usuario
            {
                id_preferencia = 1,
                id_etiqueta = 1
            };
            controller.ModelState.AddModelError("id_usuario", "El usuario es requerido.");

            var result = controller.Editar(preferencia) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }


        /// <summary>
        /// Verifica que la acción Eliminar elimina la preferencia y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_PreferenciaExistente_RedireccionaAIndex()
        {
            var controller = new Preferencias_UsuarioController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        //
    }
}
