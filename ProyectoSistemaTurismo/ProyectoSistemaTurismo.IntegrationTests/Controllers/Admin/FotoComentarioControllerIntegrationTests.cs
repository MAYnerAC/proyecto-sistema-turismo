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
