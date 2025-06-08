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
    /// Pruebas de integración para ComentarioController.
    /// </summary>
    [TestClass]
    public class ComentarioControllerIntegrationTests
    {

        /// <summary>
        /// Inicializa la base de datos solo una vez por clase antes de las pruebas.
        /// </summary>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Verifica que Index retorna la vista con la lista de comentarios.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new ComentarioController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo cuando el comentario existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ComentarioExistente_RetornaVistaYModelo()
        {
            var controller = new ComentarioController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Comentario));
        }

        /// <summary>
        /// Verifica que Detalles redirige a Index cuando el comentario no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ComentarioNoExiste_RedireccionaIndex()
        {
            var controller = new ComentarioController();
            int id = 99999;

            var result = controller.Detalles(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (GET) retorna la vista correctamente.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVistaYCombos()
        {
            var controller = new ComentarioController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.Ofertas);
            Assert.IsNotNull(result.ViewBag.Usuarios);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos válidos redirige a Index y muestra mensaje de éxito.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new ComentarioController();
            var comentario = new Comentario
            {
                contenido = "Excelente lugar para visitar",
                puntuacion = 5,
                fecha_comentario = System.DateTime.Today,
                estado = "A",
                id_oferta = 1,
                id_usuario = 1
            };

            var result = controller.Crear(comentario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Comentario creado con éxito.", controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos inválidos redirige a Index y muestra mensaje de error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new ComentarioController();
            var comentario = new Comentario(); // Falta contenido y claves foráneas
            controller.ModelState.AddModelError("contenido", "Requerido");
            controller.ModelState.AddModelError("id_oferta", "Requerido");
            controller.ModelState.AddModelError("id_usuario", "Requerido");

            var result = controller.Crear(comentario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Los datos ingresados no son válidos. No se pudo crear el comentario.", controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo cuando el comentario existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_ComentarioExistente_RetornaVistaYModelo()
        {
            var controller = new ComentarioController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Comentario));
            Assert.IsNotNull(result.ViewBag.Ofertas);
            Assert.IsNotNull(result.ViewBag.Usuarios);
        }

        /// <summary>
        /// Verifica que Editar (GET) redirige a Index si el comentario no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_ComentarioNoExiste_RedireccionaIndex()
        {
            var controller = new ComentarioController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos válidos redirige a Index y muestra mensaje de éxito.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new ComentarioController();
            var comentario = new Comentario
            {
                id_comentario = 1,
                contenido = "Actualización de comentario",
                puntuacion = 4,
                fecha_comentario = System.DateTime.Today,
                estado = "A",
                id_oferta = 1,
                id_usuario = 1
            };

            var result = controller.Editar(comentario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Comentario actualizado con éxito.", controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new ComentarioController();
            var comentario = new Comentario { id_comentario = 1 }; // Falta contenido y claves foráneas
            controller.ModelState.AddModelError("contenido", "Requerido");
            controller.ModelState.AddModelError("id_oferta", "Requerido");
            controller.ModelState.AddModelError("id_usuario", "Requerido");

            var result = controller.Editar(comentario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Los datos ingresados no son válidos. No se pudo actualizar el comentario.", controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina el comentario y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_ComentarioExistente_RedireccionaAIndex()
        {
            var controller = new ComentarioController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Comentario eliminado con éxito.", controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Eliminar redirige a Index si el comentario no existe.
        /// </summary>
        [TestMethod]
        public void Eliminar_ComentarioNoExiste_RedireccionaIndex()
        {
            var controller = new ComentarioController();
            int id = 99999;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("El comentario no fue encontrado.", controller.TempData["Error"]);
        }

        //
    }
}
