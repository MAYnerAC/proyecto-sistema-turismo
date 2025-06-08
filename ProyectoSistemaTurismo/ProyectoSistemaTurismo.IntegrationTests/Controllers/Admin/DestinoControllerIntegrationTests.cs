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
    /// Pruebas de integración para DestinoController.
    /// </summary>
    [TestClass]
    public class DestinoControllerIntegrationTests
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
        /// Verifica que Index retorna la vista con la lista de destinos.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new DestinoController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo cuando el destino existe.
        /// </summary>
        [TestMethod]
        public void Detalles_DestinoExistente_RetornaVistaYModelo()
        {
            var controller = new DestinoController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Destino));
        }

        /// <summary>
        /// Verifica que Detalles redirige a Index cuando el destino no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_DestinoNoExiste_RedireccionaIndex()
        {
            var controller = new DestinoController();
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
            var controller = new DestinoController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos válidos redirige a Index y muestra mensaje de éxito.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new DestinoController();
            var destino = new Destino
            {
                nombre_destino = "Arequipa",
                tipo_destino = "Ciudad",
                descripcion = "La ciudad blanca",
                pais = "Perú",
                estado = "A"
            };

            var result = controller.Crear(destino) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Destino creado con éxito.", controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos inválidos redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new DestinoController();
            var destino = new Destino(); // Falta nombre, país (requeridos)
            controller.ModelState.AddModelError("nombre_destino", "Requerido");
            controller.ModelState.AddModelError("pais", "Requerido");

            var result = controller.Crear(destino) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Los datos ingresados no son válidos. No se pudo crear el destino.", controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo cuando el destino existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_DestinoExistente_RetornaVistaYModelo()
        {
            var controller = new DestinoController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Destino));
        }

        /// <summary>
        /// Verifica que Editar (GET) redirige a Index si el destino no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_DestinoNoExiste_RedireccionaIndex()
        {
            var controller = new DestinoController();
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
            var controller = new DestinoController();
            var destino = new Destino
            {
                id_destino = 1,
                nombre_destino = "Arequipa Modificado",
                tipo_destino = "Ciudad",
                descripcion = "Nueva descripcion",
                pais = "Perú",
                estado = "A"
            };

            var result = controller.Editar(destino) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Destino actualizado con éxito.", controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirige a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new DestinoController();
            var destino = new Destino { id_destino = 1 }; // Falta nombre, país
            controller.ModelState.AddModelError("nombre_destino", "Requerido");
            controller.ModelState.AddModelError("pais", "Requerido");

            var result = controller.Editar(destino) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Los datos ingresados no son válidos. No se pudo actualizar el destino.", controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina el destino y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_DestinoExistente_RedireccionaAIndex()
        {
            var controller = new DestinoController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Destino eliminado con éxito.", controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Eliminar redirige a Index si el destino no existe.
        /// </summary>
        [TestMethod]
        public void Eliminar_DestinoNoExiste_RedireccionaIndex()
        {
            var controller = new DestinoController();
            int id = 99999;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("El destino no fue encontrado.", controller.TempData["Error"]);
        }

        //
    }
}
