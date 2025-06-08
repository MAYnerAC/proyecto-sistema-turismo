using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Web.Mvc;
using ProyectoSistemaTurismo.Areas.Admin.Controllers;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Admin
{
    /// <summary>
    /// Pruebas de integración para Foto_ComentarioController en el área Admin.
    /// </summary>
    [TestClass]
    public class FotoComentarioControllerIntegrationTests
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
        /// Verifica que Index retorna la vista con la lista de fotos/comentarios.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new Foto_ComentarioController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo cuando la foto de comentario existe.
        /// </summary>
        [TestMethod]
        public void Detalles_FotoComentarioExistente_RetornaVistaYModelo()
        {
            var controller = new Foto_ComentarioController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Foto_Comentario));
        }

        /// <summary>
        /// Verifica que Detalles redirige a Index cuando la foto de comentario no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_FotoComentarioNoExiste_RedireccionaIndex()
        {
            var controller = new Foto_ComentarioController();
            int id = 99999;

            var result = controller.Detalles(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (GET) retorna la vista y el combo de comentarios.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVistaYCombos()
        {
            var controller = new Foto_ComentarioController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.Comentarios);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos válidos y archivo válido redirecciona a Index.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_DatosValidosYArchivo_RedireccionaAIndex()
        {
            var controller = new Foto_ComentarioController();

            var fotoComentario = new Foto_Comentario
            {
                descripcion = "Foto integración test",
                id_comentario = 1,
                estado = "A"
            };

            // Simula un archivo válido
            var archivoMock = new Moq.Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("test.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));
            archivoMock.Setup(f => f.ContentType).Returns("image/jpeg");

            // Ejecuta
            var result = await controller.Crear(fotoComentario, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }


        /// <summary>
        /// Verifica que Crear (POST) sin archivo retorna a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_SinArchivo_RedireccionaAIndexConError()
        {
            var controller = new Foto_ComentarioController();

            var fotoComentario = new Foto_Comentario
            {
                descripcion = "Foto sin archivo",
                id_comentario = 1,
                estado = "A"
            };

            var result = await controller.Crear(fotoComentario, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos inválidos redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new Foto_ComentarioController();

            var fotoComentario = new Foto_Comentario
            {
                // Falta url_foto (Required) y otros campos
                descripcion = "Inválido",
                id_comentario = 1
            };
            controller.ModelState.AddModelError("url_foto", "La URL de la foto es obligatoria.");

            var result = await controller.Crear(fotoComentario, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo cuando la foto de comentario existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_FotoComentarioExistente_RetornaVistaYModelo()
        {
            var controller = new Foto_ComentarioController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Foto_Comentario));
            Assert.IsNotNull(result.ViewBag.Comentarios);
        }

        /// <summary>
        /// Verifica que Editar (GET) redirige a Index si la foto de comentario no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_FotoComentarioNoExiste_RedireccionaIndex()
        {
            var controller = new Foto_ComentarioController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos válidos y archivo válido redirecciona a Index.
        /// </summary>
        [TestMethod]
        public async Task Editar_Post_DatosValidosYArchivo_RedireccionaAIndex()
        {
            var controller = new Foto_ComentarioController();

            int idFotoComentario = 1;
            var fotoExistente = controller.Detalles(idFotoComentario) as ViewResult;
            var fotoComentario = fotoExistente?.Model as Foto_Comentario;
            if (fotoComentario == null) Assert.Inconclusive("No existe la foto de comentario a editar para la prueba.");

            fotoComentario.descripcion = "Actualizada";
            fotoComentario.estado = "A";

            var archivoMock = new Moq.Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("actualizada.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));
            archivoMock.Setup(f => f.ContentType).Returns("image/jpeg");

            var result = await controller.Editar(fotoComentario, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Editar_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new Foto_ComentarioController();

            int idFotoComentario = 1;
            var fotoExistente = controller.Detalles(idFotoComentario) as ViewResult;
            var fotoComentario = fotoExistente?.Model as Foto_Comentario;
            if (fotoComentario == null) Assert.Inconclusive("No existe la foto de comentario a editar para la prueba.");

            fotoComentario.url_foto = null; // Campo requerido omitido
            controller.ModelState.AddModelError("url_foto", "La URL de la foto es obligatoria.");

            var result = await controller.Editar(fotoComentario, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina la foto de comentario y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_FotoComentarioExistente_RedireccionaAIndex()
        {
            var controller = new Foto_ComentarioController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        //
    }
}
