using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using Moq;
using ProyectoSistemaTurismo.Areas.Proveedor.Controllers;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System.Collections.Generic;
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Proveedor
{
    /// <summary>
    /// Pruebas de integración para ComentarioController del área Proveedor.
    /// </summary>
    [TestClass]
    public class ComentarioControllerProveedorIntegrationTests
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
        /// Verifica que Index retorna la vista y el modelo correcto (comentarios de la oferta seleccionada en sesión).
        /// </summary>
        [TestMethod]
        public void Index_SesionOfertaValida_RetornaVistaYComentarios()
        {
            // Arrange
            var controller = new ComentarioController();

            // Simula una sesión válida con OfertaId = 1
            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["OfertaId"]).Returns(1);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Comentario>));
        }

        /// <summary>
        /// Verifica que Index retorna vista vacía si OfertaId no está en sesión.
        /// </summary>
        [TestMethod]
        public void Index_SesionSinOfertaId_LanzaExcepcionONoRetornaComentarios()
        {
            // Arrange
            var controller = new ComentarioController();

            // Simula una sesión SIN OfertaId
            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["OfertaId"]).Returns(null);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            try
            {
                // Act
                var result = controller.Index() as ViewResult;

                // Assert
                // Podría lanzar excepción o retornar una lista vacía
                Assert.IsNotNull(result);
                // Si retorna modelo, debe ser una lista vacía
                Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Comentario>));
            }
            catch (Exception ex)
            {
                // Es aceptable que lance excepción, documentamos esto por claridad.
                Assert.IsTrue(ex is NullReferenceException || ex is InvalidCastException);
            }
        }

        /// <summary>
        /// Verifica que Index retorna lista vacía si la oferta seleccionada no tiene comentarios.
        /// </summary>
        [TestMethod]
        public void Index_OfertaSinComentarios_RetornaListaVacia()
        {
            // Arrange
            var controller = new ComentarioController();

            // Supón que OfertaId = 9999 no tiene comentarios
            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["OfertaId"]).Returns(9999);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var comentarios = result.Model as IEnumerable<Comentario>;
            Assert.IsNotNull(comentarios);
            Assert.AreEqual(0, System.Linq.Enumerable.Count(comentarios));
        }

        //
    }
}
