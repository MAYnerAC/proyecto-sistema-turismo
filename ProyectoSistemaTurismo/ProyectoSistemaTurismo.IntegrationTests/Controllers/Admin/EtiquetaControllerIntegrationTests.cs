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
    /// Pruebas de integración para EtiquetaController en el área Admin.
    /// </summary>
    [TestClass]
    public class EtiquetaControllerIntegrationTests
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
        /// Verifica que Index retorna la vista con la lista de etiquetas.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            var controller = new EtiquetaController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(System.Collections.IEnumerable));
        }

        /// <summary>
        /// Verifica que Detalles retorna la vista y modelo cuando la etiqueta existe.
        /// </summary>
        [TestMethod]
        public void Detalles_EtiquetaExistente_RetornaVistaYModelo()
        {
            var controller = new EtiquetaController();
            int id = 1;

            var result = controller.Detalles(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Etiqueta));
        }

        /// <summary>
        /// Verifica que Detalles redirige a Index cuando la etiqueta no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_EtiquetaNoExiste_RedireccionaIndex()
        {
            var controller = new EtiquetaController();
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
            var controller = new EtiquetaController();

            var result = controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica que Crear (POST) con datos válidos redirecciona a Index.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new EtiquetaController();
            var etiqueta = new Etiqueta
            {
                nombre_etiqueta = "Etiqueta Integración",
                estado = "A"
            };

            var result = controller.Crear(etiqueta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Crear (POST) con modelo inválido redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Crear_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new EtiquetaController();
            var etiqueta = new Etiqueta
            {
                // nombre_etiqueta = null, // Campo requerido omitido
                estado = "A"
            };
            controller.ModelState.AddModelError("nombre_etiqueta", "El nombre de la etiqueta es obligatorio");

            var result = controller.Crear(etiqueta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }


        /// <summary>
        /// Verifica que Editar (GET) retorna la vista y modelo cuando la etiqueta existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_EtiquetaExistente_RetornaVistaYModelo()
        {
            var controller = new EtiquetaController();
            int id = 1;

            var result = controller.Editar(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Etiqueta));
        }

        /// <summary>
        /// Verifica que Editar (GET) redirige a Index si la etiqueta no existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_EtiquetaNoExiste_RedireccionaIndex()
        {
            var controller = new EtiquetaController();
            int id = 99999;

            var result = controller.Editar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con datos válidos redirecciona a Index.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosValidos_RedireccionaAIndex()
        {
            var controller = new EtiquetaController();

            // Busca la etiqueta existente para editar
            int idEtiqueta = 1;
            var etiquetaExistente = controller.Detalles(idEtiqueta) as ViewResult;
            var etiqueta = etiquetaExistente?.Model as Etiqueta;
            if (etiqueta == null) Assert.Inconclusive("No existe la etiqueta a editar para la prueba.");

            etiqueta.nombre_etiqueta = "Etiqueta Editada Integración";

            var result = controller.Editar(etiqueta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Mensaje"]);
        }

        /// <summary>
        /// Verifica que Editar (POST) con modelo inválido redirecciona a Index y muestra error.
        /// </summary>
        [TestMethod]
        public void Editar_Post_DatosInvalidos_RedireccionaAIndexConError()
        {
            var controller = new EtiquetaController();

            // Busca la etiqueta existente para editar
            int idEtiqueta = 1;
            var etiquetaExistente = controller.Detalles(idEtiqueta) as ViewResult;
            var etiqueta = etiquetaExistente?.Model as Etiqueta;
            if (etiqueta == null) Assert.Inconclusive("No existe la etiqueta a editar para la prueba.");

            etiqueta.nombre_etiqueta = null; // Campo requerido omitido
            controller.ModelState.AddModelError("nombre_etiqueta", "El nombre de la etiqueta es obligatorio");

            var result = controller.Editar(etiqueta) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que Eliminar elimina la etiqueta y redirige a Index.
        /// </summary>
        [TestMethod]
        public void Eliminar_EtiquetaExistente_RedireccionaAIndex()
        {
            var controller = new EtiquetaController();
            int id = 1;

            var result = controller.Eliminar(id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }



        //
    }
}
