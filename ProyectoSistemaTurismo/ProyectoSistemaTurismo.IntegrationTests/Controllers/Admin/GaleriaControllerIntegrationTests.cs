using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Web.Mvc;
using ProyectoSistemaTurismo.Areas.Admin.Controllers;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System.Threading.Tasks;
using Moq;
using System.IO;
using System.Web;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Admin
{
    /// <summary>
    /// Pruebas de integración para GaleriaController en el área Admin.
    /// </summary>
    [TestClass]
    public class GaleriaControllerIntegrationTests
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
        /// Verifica que Index retorna la vista con la lista de imágenes.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new GaleriaController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo cuando la imagen existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ImagenExistente_RetornaVistaYModelo()
        {
            var controller = new GaleriaController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Galeria));
        }

        /// <summary>
        /// Verifica que Detalles redirige a Index cuando la imagen no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_ImagenNoExiste_RedireccionaIndex()
        {
            var controller = new GaleriaController();
            int id = 99999;

            var result = controller.Detalles(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Crear (GET) retorna la vista y combos de ofertas.
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVistaYCombos()
        {
            var controller = new GaleriaController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.Ofertas);
        }

        [TestMethod]
        public async Task Crear_Post_ImagenValidaYArchivo_RedireccionaAIndex()
        {
            var controller = new GaleriaController();

            var galeria = new Galeria
            {
                descripcion = "Imagen test integración",
                tipo_imagen = "JPEG",
                fecha_subida = DateTime.Now,
                estado = "A",
                id_oferta = 1 // Debe existir oferta 1
            };

            var archivoMock = new Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("foto.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));
            archivoMock.Setup(f => f.ContentType).Returns("image/jpeg");

            // Cambiar el mock del servicio
            var dataValidationMock = new Mock<ProyectoSistemaTurismo.Service.DataValidationService>();
            dataValidationMock.Setup(f => f.ValidarArchivoImagen(It.IsAny<HttpPostedFileBase>())).Returns((string)null);

            // Inyectar el mock en el controlador
            typeof(GaleriaController)
                .GetField("_dataValidationService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, dataValidationMock.Object);

            var result = await controller.Crear(galeria, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }


        /*
        /// <summary>
        /// Verifica que Crear (POST) con datos válidos y archivo válido redirecciona a Index.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_ImagenValidaYArchivo_RedireccionaAIndex()
        {
            var controller = new GaleriaController();

            var galeria = new Galeria
            {
                descripcion = "Imagen test integración",
                tipo_imagen = "JPEG",
                fecha_subida = DateTime.Now,
                estado = "A",
                id_oferta = 1 // Debe existir oferta 1
            };

            var archivoMock = new Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("foto.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));
            archivoMock.Setup(f => f.ContentType).Returns("image/jpeg");

            var firebaseMock = new Mock<ProyectoSistemaTurismo.Service.FirebaseStorageService>();
            firebaseMock.Setup(f => f.ValidarArchivoImagen(It.IsAny<HttpPostedFileBase>())).Returns((string)null);
            firebaseMock.Setup(f => f.SubirArchivo(It.IsAny<HttpPostedFileBase>())).ReturnsAsync("https://fakeurl.com/foto.jpg");
            typeof(GaleriaController)
                .GetField("_firebaseStorageService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, firebaseMock.Object);

            var result = await controller.Crear(galeria, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }
        */

        /// <summary>
        /// Verifica que Crear (POST) sin archivo retorna a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_SinArchivo_RedireccionaAIndexConError()
        {
            var controller = new GaleriaController();

            var galeria = new Galeria
            {
                descripcion = "Imagen sin archivo",
                tipo_imagen = "PNG",
                fecha_subida = DateTime.Now,
                estado = "A",
                id_oferta = 1
            };

            var result = await controller.Crear(galeria, null) as RedirectToRouteResult;

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
            var controller = new GaleriaController();

            var galeria = new Galeria
            {
                // Falta url_imagen (Required)
                descripcion = "Inválido",
                id_oferta = 1
            };
            controller.ModelState.AddModelError("url_imagen", "La URL de la imagen es obligatoria.");

            var result = await controller.Crear(galeria, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo cuando la imagen existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_ImagenExistente_RetornaVistaYModelo()
        {
            var controller = new GaleriaController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Galeria));
            Assert.IsNotNull(result.ViewBag.Ofertas);
        }

        /// <summary>
        /// Verifica que Editar (GET) redirige a Index si la imagen no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_ImagenNoExiste_RedireccionaIndex()
        {
            var controller = new GaleriaController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public async Task Editar_Post_DatosValidosYArchivo_RedireccionaAIndex()
        {
            var controller = new GaleriaController();

            int idImagen = 1;
            var imagenExistente = controller.Detalles(idImagen) as ViewResult;
            var galeria = imagenExistente?.Model as Galeria;
            if (galeria == null) Assert.Inconclusive("No existe la imagen a editar para la prueba.");

            galeria.descripcion = "Imagen editada";
            galeria.estado = "A";

            var archivoMock = new Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("editada.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));
            archivoMock.Setup(f => f.ContentType).Returns("image/jpeg");

            // Cambiar el mock del servicio
            var dataValidationMock = new Mock<ProyectoSistemaTurismo.Service.DataValidationService>();
            dataValidationMock.Setup(f => f.ValidarArchivoImagen(It.IsAny<HttpPostedFileBase>())).Returns((string)null);

            // Inyectar el mock en el controlador
            typeof(GaleriaController)
                .GetField("_dataValidationService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, dataValidationMock.Object);

            var result = await controller.Editar(galeria, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }


        /*
        /// <summary>
        /// Verifica que Editar (POST) con datos válidos y archivo válido redirecciona a Index.
        /// </summary>
        [TestMethod]
        public async Task Editar_Post_DatosValidosYArchivo_RedireccionaAIndex()
        {
            var controller = new GaleriaController();

            int idImagen = 1;
            var imagenExistente = controller.Detalles(idImagen) as ViewResult;
            var galeria = imagenExistente?.Model as Galeria;
            if (galeria == null) Assert.Inconclusive("No existe la imagen a editar para la prueba.");

            galeria.descripcion = "Imagen editada";
            galeria.estado = "A";

            var archivoMock = new Mock<HttpPostedFileBase>();
            archivoMock.Setup(f => f.ContentLength).Returns(100);
            archivoMock.Setup(f => f.FileName).Returns("editada.jpg");
            archivoMock.Setup(f => f.InputStream).Returns(new MemoryStream(new byte[100]));
            archivoMock.Setup(f => f.ContentType).Returns("image/jpeg");

            var firebaseMock = new Mock<ProyectoSistemaTurismo.Service.FirebaseStorageService>();
            firebaseMock.Setup(f => f.ValidarArchivoImagen(It.IsAny<HttpPostedFileBase>())).Returns((string)null);
            firebaseMock.Setup(f => f.SubirArchivo(It.IsAny<HttpPostedFileBase>())).ReturnsAsync("https://fakeurl.com/editada.jpg");
            typeof(GaleriaController)
                .GetField("_firebaseStorageService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(controller, firebaseMock.Object);

            var result = await controller.Editar(galeria, archivoMock.Object) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }
        */

        /// <summary>
        /// Verifica que Editar (POST) con datos inválidos redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public async Task Editar_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new GaleriaController();

            int idImagen = 1;
            var imagenExistente = controller.Detalles(idImagen) as ViewResult;
            var galeria = imagenExistente?.Model as Galeria;
            if (galeria == null) Assert.Inconclusive("No existe la imagen a editar para la prueba.");

            galeria.url_imagen = null; // Campo requerido omitido
            controller.ModelState.AddModelError("url_imagen", "La URL de la imagen es obligatoria.");

            var result = await controller.Editar(galeria, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina la imagen y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_ImagenExistente_RedireccionaAIndex()
        {
            var controller = new GaleriaController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }





        //
    }
}
