using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using ProyectoSistemaTurismo.Controllers;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers
{
    /// <summary>
    /// Pruebas de integración para ComentariosController (raíz).
    /// </summary>
    [TestClass]
    public class ComentariosControllerIntegrationTests
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
        /// Verifica que Detalles retorna la vista y el comentario correcto cuando existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ComentarioExistente_RetornaVistaYModelo()
        {
            var controller = new ComentariosController();

            // Asume que existe el comentario con ID 1 en el DML de pruebas
            var result = controller.Detalles(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Comentario));
            var comentario = (Comentario)result.Model;
            Assert.AreEqual(1, comentario.id_comentario);
        }

        /// <summary>
        /// Verifica que Detalles redirecciona a Index si el comentario no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ComentarioNoExistente_RedireccionaAIndex()
        {
            var controller = new ComentariosController();

            var result = controller.Detalles(9999) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que AgregarComentario (POST) con datos válidos redirecciona a Detalles de Ofertas.
        /// </summary>
        [TestMethod]
        public void AgregarComentario_DatosValidos_RedireccionaADetallesOfertas()
        {
            var controller = new ComentariosController();

            var comentario = new Comentario
            {
                contenido = "Comentario de integración válido",
                id_oferta = 1,
                id_usuario = 1,
                estado = "A"
            };

            var result = controller.AgregarComentario(comentario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Detalles", result.RouteValues["action"]);
            Assert.AreEqual("Ofertas", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        /// <summary>
        /// Verifica que AgregarComentario (POST) con datos inválidos redirecciona a Detalles de Ofertas.
        /// </summary>
        [TestMethod]
        public void AgregarComentario_DatosInvalidos_RedireccionaADetallesOfertas()
        {
            var controller = new ComentariosController();

            // Faltan campos requeridos
            var comentario = new Comentario
            {
                // Falta contenido, id_usuario
                id_oferta = 1,
                estado = "A"
            };
            controller.ModelState.AddModelError("contenido", "Requerido");

            var result = controller.AgregarComentario(comentario) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Detalles", result.RouteValues["action"]);
            Assert.AreEqual("Ofertas", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        /// <summary>
        /// Verifica que AgregarFoto (POST) con datos válidos y archivo válido redirecciona a Detalles.
        /// </summary>
        [TestMethod]
        public async Task AgregarFoto_DatosYArchivoValidos_RedireccionaADetalles()
        {
            var controller = new ComentariosController();

            var fotoComentario = new Foto_Comentario
            {
                id_comentario = 1,
                descripcion = "Foto válida"
            };

            // Simula archivo válido
            var archivoMock = new Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("foto.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));

            // Cambiar el mock del servicio a DataValidationService
            var dataValidationMock = new Mock<ProyectoSistemaTurismo.Service.DataValidationService>();
            dataValidationMock.Setup(f => f.ValidarArchivoImagen(It.IsAny<HttpPostedFileBase>())).Returns((string)null);  // No hay error, es válido

            // Inyectar el mock del servicio en el controlador
            typeof(ComentariosController)
                .GetField("_dataValidationService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, dataValidationMock.Object);

            // Configurar el mock de Firebase para la subida de archivo (si sigue siendo necesario en el controlador)
            var firebaseMock = new Mock<ProyectoSistemaTurismo.Service.FirebaseStorageService>();
            firebaseMock.Setup(f => f.SubirArchivo(It.IsAny<HttpPostedFileBase>())).ReturnsAsync("https://fakeurl.com/foto.jpg");  // URL simulada de la imagen subida
            typeof(ComentariosController)
                .GetField("_firebaseStorageService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, firebaseMock.Object);

            var result = await controller.AgregarFoto(fotoComentario, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Detalles", result.RouteValues["action"]);
            Assert.AreEqual("Comentarios", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }


        /*
        /// <summary>
        /// Verifica que AgregarFoto (POST) con datos válidos y archivo válido redirecciona a Detalles.
        /// </summary>
        [TestMethod]
        public async Task AgregarFoto_DatosYArchivoValidos_RedireccionaADetalles()
        {
            var controller = new ComentariosController();

            var fotoComentario = new Foto_Comentario
            {
                id_comentario = 1,
                descripcion = "Foto válida"
            };

            // Simula archivo válido
            var archivoMock = new Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("foto.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));

            // Simula que la subida a Firebase siempre devuelve una URL dummy
            var firebaseMock = new Mock<ProyectoSistemaTurismo.Service.FirebaseStorageService>();
            firebaseMock.Setup(f => f.ValidarArchivoImagen(It.IsAny<HttpPostedFileBase>())).Returns((string)null);
            firebaseMock.Setup(f => f.SubirArchivo(It.IsAny<HttpPostedFileBase>())).ReturnsAsync("https://fakeurl.com/foto.jpg");
            typeof(ComentariosController)
                .GetField("_firebaseStorageService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, firebaseMock.Object);

            var result = await controller.AgregarFoto(fotoComentario, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Detalles", result.RouteValues["action"]);
            Assert.AreEqual("Comentarios", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }
        */

        /// <summary>
        /// Verifica que AgregarFoto (POST) con datos inválidos redirecciona a Detalles.
        /// </summary>
        [TestMethod]
        public async Task AgregarFoto_DatosInvalidos_RedireccionaADetalles()
        {
            var controller = new ComentariosController();

            var fotoComentario = new Foto_Comentario
            {
                id_comentario = 1
                // Falta url_foto, descripción, etc.
            };

            controller.ModelState.AddModelError("url_foto", "Requerido");

            var result = await controller.AgregarFoto(fotoComentario, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Detalles", result.RouteValues["action"]);
            Assert.AreEqual("Comentarios", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        /// <summary>
        /// Verifica que AgregarFoto retorna a Detalles con error si no se selecciona archivo.
        /// </summary>
        [TestMethod]
        public async Task AgregarFoto_SinArchivo_RedireccionaADetalles()
        {
            var controller = new ComentariosController();

            var fotoComentario = new Foto_Comentario
            {
                id_comentario = 1,
                descripcion = "Sin archivo"
            };

            var result = await controller.AgregarFoto(fotoComentario, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Detalles", result.RouteValues["action"]);
            Assert.AreEqual("Comentarios", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        //
    }
}
