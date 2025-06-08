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
    /// Pruebas de integración para Tipo_UsuarioController en el área Admin.
    /// </summary>
    [TestClass]
    public class TipoUsuarioControllerIntegrationTests
    {
        /// <summary>
        /// Inicializa la base de datos solo una vez por clase
        /// </summary>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Prueba que Index retorna la vista con la lista de tipos de usuario.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new Tipo_UsuarioController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result, "Debe retornar una vista.");
            Assert.IsNotNull(result.Model, "Debe retornar un modelo.");
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable), "El modelo debe ser IEnumerable.");
        }

        /// <summary>
        /// Prueba que Detalles retorna la vista con el tipo de usuario correcto si existe.
        /// </summary>
        [TestMethod]
        public void Detalles_TipoUsuarioExistente_RetornaVistaYModelo()
        {
            var controller = new Tipo_UsuarioController();
            int tipoUsuarioId = 1;

            var result = controller.Detalles(tipoUsuarioId) as ViewResult;

            Assert.IsNotNull(result, "Debe retornar una vista.");
            Assert.IsNotNull(result.Model, "Debe retornar un modelo.");
            Assert.IsInstanceOfType(result.Model, typeof(Tipo_Usuario));
        }

        /// <summary>
        /// Prueba que Detalles redirige a Index si el tipo de usuario no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_TipoUsuarioNoExiste_RedireccionaIndex()
        {
            var controller = new Tipo_UsuarioController();
            int tipoUsuarioId = 99999;

            var result = controller.Detalles(tipoUsuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redireccionar.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Crear (GET) retorna la vista.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVista()
        {
            var controller = new Tipo_UsuarioController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result, "Debe retornar una vista.");
        }

        /// <summary>
        /// Prueba que Crear (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Crear_Post_TipoUsuarioValido_RedireccionaAIndex()
        {
            var controller = new Tipo_UsuarioController();
            var tipoUsuario = new Tipo_Usuario
            {
                nombre_tipo = "Tester_" + Guid.NewGuid().ToString("N").Substring(0, 8),
                estado = "A"
            };

            var result = controller.Crear(tipoUsuario) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redireccionar después de crear.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Crear (POST) con datos inválidos no crea el tipo de usuario y retorna error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_TipoUsuarioInvalido_NoRedirigeYSeteaError()
        {
            var controller = new Tipo_UsuarioController();
            var tipoUsuario = new Tipo_Usuario
            {
                // nombre_tipo es requerido, se deja vacío para simular inválido
                estado = "A"
            };
            controller.ModelState.AddModelError("nombre_tipo", "El nombre es obligatorio.");

            var result = controller.Crear(tipoUsuario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Prueba que Editar (GET) retorna la vista con el tipo de usuario si existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_TipoUsuarioExistente_RetornaVistaYModelo()
        {
            var controller = new Tipo_UsuarioController();
            int tipoUsuarioId = 1;

            var result = controller.Editar(tipoUsuarioId) as ViewResult;

            Assert.IsNotNull(result, "Debe retornar una vista.");
            Assert.IsNotNull(result.Model, "Debe retornar un modelo.");
            Assert.IsInstanceOfType(result.Model, typeof(Tipo_Usuario));
        }

        /// <summary>
        /// Prueba que Editar (GET) redirige a Index si el tipo de usuario no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_TipoUsuarioNoExiste_RedireccionaIndex()
        {
            var controller = new Tipo_UsuarioController();
            int tipoUsuarioId = 99999; // No existe

            var result = controller.Editar(tipoUsuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redireccionar.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Editar (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Editar_Post_TipoUsuarioValido_RedireccionaAIndex()
        {
            var controller = new Tipo_UsuarioController();
            var tipoUsuario = new Tipo_Usuario
            {
                id_tipo_usuario = 1,
                nombre_tipo = "Editado_" + Guid.NewGuid().ToString("N").Substring(0, 8),
                estado = "A"
            };

            var result = controller.Editar(tipoUsuario) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redireccionar después de editar.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Editar (POST) con datos inválidos no actualiza y retorna error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_TipoUsuarioInvalido_NoRedirigeYSeteaError()
        {
            var controller = new Tipo_UsuarioController();
            var tipoUsuario = new Tipo_Usuario
            {
                id_tipo_usuario = 1,
                // nombre_tipo vacío (inválido)
                estado = "A"
            };
            controller.ModelState.AddModelError("nombre_tipo", "El nombre es obligatorio.");

            var result = controller.Editar(tipoUsuario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Prueba que Eliminar (POST) con tipo de usuario existente redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_TipoUsuarioExistente_RedireccionaAIndex()
        {
            var controller = new Tipo_UsuarioController();
            int tipoUsuarioId = 1;

            var result = controller.Eliminar(tipoUsuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Debe redireccionar después de eliminar.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Eliminar (POST) con tipo de usuario inexistente redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Eliminar_TipoUsuarioNoExistente_RedireccionaAIndexYError()
        {
            var controller = new Tipo_UsuarioController();
            int tipoUsuarioId = 99999;

            var result = controller.Eliminar(tipoUsuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        //
    }
}
