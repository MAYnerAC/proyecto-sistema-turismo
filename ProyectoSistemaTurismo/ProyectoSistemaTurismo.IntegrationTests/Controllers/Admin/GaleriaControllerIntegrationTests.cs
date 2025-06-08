using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Web.Mvc;
using ProyectoSistemaTurismo.Areas.Admin.Controllers;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using System.Threading.Tasks;

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

        // Los métodos Crear (POST) y Editar (POST) con archivo requieren pruebas avanzadas/mocks y no siempre se prueban en integración (mejor en pruebas de servicio o mocks).
        // Se muestra estructura pero normalmente deberías mockear la subida.

        /*
        /// <summary>
        /// Verifica que Crear (POST) con datos válidos y archivo imagen redirige a Index.
        /// </summary>
        [TestMethod]
        public async Task Crear_Post_ImagenValida_RedireccionaAIndex()
        {
            var controller = new GaleriaController();
            var galeria = new Galeria
            {
                descripcion = "Imagen de prueba",
                tipo_imagen = "Foto",
                fecha_subida = DateTime.Now,
                estado = "A",
                id_oferta = 1
            };
            // Aquí normalmente debes simular/mockear el archivo
            HttpPostedFileBase archivoImagen = null;

            var result = await controller.Crear(galeria, archivoImagen) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        */

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
