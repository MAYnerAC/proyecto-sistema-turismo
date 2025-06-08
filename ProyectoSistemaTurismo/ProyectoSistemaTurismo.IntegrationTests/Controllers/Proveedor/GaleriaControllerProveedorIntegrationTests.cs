using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Areas.Proveedor.Controllers;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System.Threading.Tasks;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Proveedor
{
    /// <summary>
    /// Pruebas de integración para GaleriaController del área Proveedor.
    /// </summary>
    [TestClass]
    public class GaleriaControllerProveedorIntegrationTests
    {

        /// <summary>
        /// Inicializa la base de datos solo una vez por clase.
        /// </summary>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Verifica que Index retorna la vista y el modelo de imágenes correcto para la oferta seleccionada en sesión.
        /// </summary>
        [TestMethod]
        public void Index_SesionOfertaValida_RetornaVistaYImagenes()
        {
            // Arrange
            var controller = new GaleriaController();

            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["OfertaId"]).Returns(1);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);
            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Galeria>));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y el modelo de la imagen existente.
        /// </summary>
        [TestMethod]
        public void Detalles_ImagenExistente_RetornaVistaYModelo()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Detalles(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Galeria));
        }

        /// <summary>
        /// Verifica que Detalles redirecciona al Index si la imagen no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ImagenNoExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Detalles(9999) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (GET) retorna la vista correctamente.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVista()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Crear() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y el modelo de la imagen existente.
        /// </summary>
        [TestMethod]
        public void Editar_Get_ImagenExistente_RetornaVistaYModelo()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Editar(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Galeria));
        }

        /// <summary>
        /// Verifica que Editar (GET) redirecciona al Index si la imagen no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_ImagenNoExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Editar(9999) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina correctamente una imagen existente.
        /// </summary>
        [TestMethod]
        public void Eliminar_ImagenExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Eliminar(1) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Eliminar redirecciona a Index si la imagen no existe.
        /// </summary>
        [TestMethod]
        public void Eliminar_ImagenNoExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new GaleriaController();

            // Act
            var result = controller.Eliminar(9999) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos inválidos redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_DatosInvalidos_RedireccionaAIndex()
        {
            // Arrange
            var controller = new GaleriaController();
            controller.ModelState.AddModelError("url_imagen", "Requerido");

            // Act
            var result = await controller.Crear(new Galeria(), null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Editar_Post_DatosInvalidos_RedireccionaAIndex()
        {
            // Arrange
            var controller = new GaleriaController();
            controller.ModelState.AddModelError("url_imagen", "Requerido");

            // Act
            var result = await controller.Editar(new Galeria(), null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        //
    }
}
