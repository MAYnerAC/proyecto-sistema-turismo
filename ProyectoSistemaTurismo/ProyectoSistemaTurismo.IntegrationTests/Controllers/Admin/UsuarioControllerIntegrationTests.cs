using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using ProyectoSistemaTurismo.Areas.Admin.Controllers;
using ProyectoSistemaTurismo.Models;
using System.Web.Mvc;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Admin
{
    /// <summary>
    /// Pruebas de integración para UsuarioController en el área Admin.
    /// </summary>
    [TestClass]
    public class UsuarioControllerIntegrationTests
    {
        /*--------------------------------------------------*/
        //[TestInitialize]
        //public void Setup()
        /*--------------------------------------------------*/
        //[ClassInitialize]
        //public static void ClassSetup(TestContext context)
        /*--------------------------------------------------*/

        /// <summary>
        /// [TestInitialize] - Inicializa la base de datos antes de cada método de prueba
        /// [ClassInitialize] - Inicializa la base de datos solo una vez por clase
        /// </summary>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Prueba que Index retorna la vista con la lista de usuarios.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new UsuarioController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Prueba que Detalles retorna la vista con el usuario correcto si existe.
        /// </summary>
        [TestMethod]
        public void Detalles_UsuarioExistente_RetornaVistaYModelo()
        {
            var controller = new UsuarioController();
            int usuarioId = 1;

            var result = controller.Detalles(usuarioId) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Usuario));
        }

        /// <summary>
        /// Prueba que Detalles redirige a Index si el usuario no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_UsuarioNoExiste_RedireccionaIndex()
        {
            var controller = new UsuarioController();
            int usuarioId = 999999; // No existe

            var result = controller.Detalles(usuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Crear (GET) retorna la vista y carga el combo de tipos de usuario.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVistaYCombos()
        {
            var controller = new UsuarioController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.TiposUsuario);
        }

        /// <summary>
        /// Prueba que Crear (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Crear_Post_UsuarioValido_RedireccionaAIndex()
        {
            var controller = new UsuarioController();
            var usuario = new Usuario
            {
                nombre = "Usuario Prueba",
                apellido = "Apellido Prueba",
                email = "prueba@email.com",
                contrasena = "Prueba123",
                telefono = "999999999",
                id_tipo_usuario = 1,
                estado = "A",                // Activo
                fecha_registro = DateTime.Now
            };

            var result = controller.Crear(usuario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        /// <summary>
        /// Prueba que Editar (GET) retorna la vista con el usuario si existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_UsuarioExistente_RetornaVistaYModelo()
        {
            var controller = new UsuarioController();
            int usuarioId = 1;

            var result = controller.Editar(usuarioId) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Usuario));
        }

        /// <summary>
        /// Prueba que Editar (GET) redirige a Index si el usuario no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_UsuarioNoExiste_RedireccionaIndex()
        {
            var controller = new UsuarioController();
            int usuarioId = 999999;

            var result = controller.Editar(usuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Editar (POST) con datos válidos redirige a Index.
        /// </summary>
        [TestMethod]
        public void Editar_Post_UsuarioValido_RedireccionaAIndex()
        {
            var controller = new UsuarioController();
            var usuario = new Usuario
            {
                id_usuario = 1,
                nombre = "Usuario Editado",
                apellido = "Apellido Editado",
                email = "editado@email.com",
                contrasena = "NuevaClave123",
                telefono = "888888888",
                id_tipo_usuario = 1,
                estado = "A",
                fecha_registro = DateTime.Now
            };

            var result = controller.Editar(usuario) as RedirectToRouteResult;

            Assert.IsNotNull(result, "La acción debe redireccionar al editar un usuario válido.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Eliminar (POST) con usuario existente redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_UsuarioExistente_RedireccionaAIndex()
        {
            var controller = new UsuarioController();
            int usuarioId = 1;

            var result = controller.Eliminar(usuarioId) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        //
    }
}
