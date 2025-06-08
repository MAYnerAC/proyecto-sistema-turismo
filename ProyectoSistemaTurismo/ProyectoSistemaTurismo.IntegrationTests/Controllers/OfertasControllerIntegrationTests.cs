using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using ProyectoSistemaTurismo.Controllers;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using ProyectoSistemaTurismo.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers
{
    /// <summary>
    /// Pruebas de integración para el controller OfertasController (público).
    /// </summary>
    [TestClass]
    public class OfertasControllerIntegrationTests
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
        /// Verifica que Detalles retorna la vista y el modelo correcto cuando existe la oferta.
        /// </summary>
        [TestMethod]
        public void Detalles_OfertaExistente_RetornaVistaYModeloYDatosCompletos()
        {
            // Arrange
            var controller = new OfertasController();

            // Oferta con ID 1
            int idOferta = 1;

            // Act
            var result = controller.Detalles(idOferta) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Oferta));

            // También comprueba ViewBag
            Assert.IsNotNull(result.ViewBag.Comentarios);
            Assert.IsNotNull(result.ViewBag.Galeria);
            Assert.IsNotNull(result.ViewBag.Etiquetas);
        }

        /// <summary>
        /// Verifica que Detalles redirecciona a Index cuando la oferta no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_OfertaNoExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new OfertasController();

            // ID que no existe
            int idOfertaInexistente = 9999;

            // Act
            var result = controller.Detalles(idOfertaInexistente);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirect = result as RedirectToRouteResult;
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["Error"]);
        }

        /// <summary>
        /// Verifica que PorDestino retorna la vista y lista de ofertas del destino existente.
        /// </summary>
        [TestMethod]
        public void PorDestino_DestinoExistenteConOfertas_RetornaVistaYOfertas()
        {
            var controller = new OfertasController();
            int idDestino = 1;

            var result = controller.PorDestino(idDestino) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<ProyectoSistemaTurismo.ViewModels.OfertaPrevia>));
            Assert.IsNotNull(result.ViewBag.DestinoNombre);
        }

        /// <summary>
        /// Verifica que PorDestino redirecciona a Index si el destino no tiene ofertas.
        /// </summary>
        [TestMethod]
        public void PorDestino_DestinoSinOfertas_RetornaVistaVacia()
        {
            var controller = new OfertasController();
            int idDestinoSinOfertas = 3; // Debe existir, pero no tener ofertas

            var result = controller.PorDestino(idDestinoSinOfertas) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<ProyectoSistemaTurismo.ViewModels.OfertaPrevia>));
            var ofertas = result.Model as IEnumerable<ProyectoSistemaTurismo.ViewModels.OfertaPrevia>;
            Assert.AreEqual(0, ofertas.Count());
            Assert.IsNotNull(result.ViewBag.DestinoNombre);
        }



        //
    }
}
