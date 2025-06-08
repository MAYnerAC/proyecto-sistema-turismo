using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using Moq;
using ProyectoSistemaTurismo.Areas.Proveedor.Controllers;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Proveedor
{
    /// <summary>
    /// Pruebas de integración para OfertaController del área Proveedor.
    /// </summary>
    [TestClass]
    public class OfertaControllerProveedorIntegrationTests
    {
        /// <summary>
        /// Pruebas de integración para ComentarioController del área Proveedor.
        /// </summary>
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            PruebaDbHelper.InicializarBD();
        }

        /// <summary>
        /// Verifica que MisOfertas retorna la vista y modelo correcto para el usuario en sesión.
        /// </summary>
        [TestMethod]
        public void MisOfertas_SesionUsuarioValida_RetornaVistaYOfertas()
        {
            var controller = new OfertaController();

            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["id_usuario"]).Returns(1);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            var result = controller.MisOfertas() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Oferta>));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo para una oferta existente.
        /// </summary>
        [TestMethod]
        public void Detalles_OfertaExistente_RetornaVistaYModelo()
        {
            var controller = new OfertaController();

            var result = controller.Detalles(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Oferta));
        }

        /// <summary>
        /// Verifica que Detalles redirecciona a Index si la oferta no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_OfertaNoExistente_RedireccionaAIndex()
        {
            var controller = new OfertaController();

            var result = controller.Detalles(9999) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (GET) retorna la vista correctamente.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVista()
        {
            var controller = new OfertaController();
            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo de la oferta existente.
        /// </summary>
        [TestMethod]
        public void Editar_Get_OfertaExistente_RetornaVistaYModelo()
        {
            var controller = new OfertaController();
            var result = controller.Editar(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Oferta));
        }

        /// <summary>
        /// Verifica que Editar (GET) redirecciona si la oferta no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_OfertaNoExistente_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();
            var result = controller.Editar(9999) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina una oferta existente y redirecciona.
        /// </summary>
        [TestMethod]
        public void Eliminar_OfertaExistente_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();
            var result = controller.Eliminar(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Eliminar redirecciona si la oferta no existe.
        /// </summary>
        [TestMethod]
        public void Eliminar_OfertaNoExistente_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();
            var result = controller.Eliminar(9999) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos válidos redirecciona a MisOfertas.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosValidos_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();

            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["id_usuario"]).Returns(1);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);
            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            var oferta = new Oferta
            {
                nombre = "Oferta Test",
                descripcion = "Prueba",
                id_tipo_oferta = 1,
                id_destino = 1,
                direccion = "Calle X",
                telefono = "123456789",
                email_contacto = "test@correo.com",
                estado = "A",
                verificado = "S",
                visible = "S"
            };

            var result = controller.Crear(oferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos inválidos redirecciona a MisOfertas y no crea la oferta.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosInvalidos_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();

            // Simula sesión
            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["id_usuario"]).Returns(1);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);
            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            controller.ModelState.AddModelError("nombre", "Requerido");

            var oferta = new Oferta(); // Datos incompletos

            var result = controller.Crear(oferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos válidos redirecciona a MisOfertas.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosValidos_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();

            var oferta = new Oferta
            {
                id_oferta = 1,
                nombre = "Oferta Modificada",
                descripcion = "Nueva Desc",
                id_usuario = 1,
                id_tipo_oferta = 1,
                id_destino = 1,
                direccion = "Av. Nueva",
                telefono = "999999999",
                email_contacto = "mod@correo.com",
                estado = "A",
                verificado = "S",
                visible = "S"
            };

            var result = controller.Editar(oferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirecciona a MisOfertas.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosInvalidos_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();
            controller.ModelState.AddModelError("nombre", "Requerido");

            var oferta = new Oferta(); // Datos incompletos

            var result = controller.Editar(oferta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Seleccionar con oferta válida guarda datos en sesión y redirecciona.
        /// </summary>
        [TestMethod]
        public void Seleccionar_OfertaExistente_SesionActualizadaYRedirige()
        {
            var controller = new OfertaController();

            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();

            // Hacer que Session guarde y lea valores
            var sessionItems = new Dictionary<string, object>();
            sessionMock.Setup(s => s[It.IsAny<string>()])
                .Returns((string key) => sessionItems.ContainsKey(key) ? sessionItems[key] : null);
            sessionMock.SetupSet(s => s[It.IsAny<string>()] = It.IsAny<object>())
                .Callback<string, object>((key, value) => sessionItems[key] = value);

            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            // Simular referrer
            var requestMock = new Mock<HttpRequestBase>();
            requestMock.Setup(r => r.UrlReferrer).Returns(new Uri("http://localhost/prueba"));
            contextMock.Setup(c => c.Request).Returns(requestMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            var result = controller.Seleccionar(1) as RedirectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("http://localhost/prueba", result.Url);
            Assert.AreEqual(1, sessionItems["OfertaId"]);
        }


        /// <summary>
        /// Verifica que Seleccionar con oferta inválida redirecciona a MisOfertas.
        /// </summary>
        [TestMethod]
        public void Seleccionar_OfertaNoExistente_RedireccionaAMisOfertas()
        {
            var controller = new OfertaController();

            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.SetupAllProperties();
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            var result = controller.Seleccionar(9999) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("MisOfertas", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que ListaOfertasUsuario retorna el partial view con el modelo correcto.
        /// </summary>
        [TestMethod]
        public void ListaOfertasUsuario_SesionUsuarioValida_RetornaPartialViewYModelo()
        {
            var controller = new OfertaController();

            var contextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(s => s["id_usuario"]).Returns(1);
            contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);

            var result = controller.ListaOfertasUsuario() as PartialViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Oferta>));
        }

        //
    }
}
