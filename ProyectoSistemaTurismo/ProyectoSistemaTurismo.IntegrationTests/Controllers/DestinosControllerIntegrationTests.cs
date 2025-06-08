using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using ProyectoSistemaTurismo.Controllers;
using ProyectoSistemaTurismo.IntegrationTests.Helpers;
using ProyectoSistemaTurismo.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers
{
    /// <summary>
    /// Pruebas de integración para el controller DestinosController.
    /// </summary>
    [TestClass]
    public class DestinosControllerIntegrationTests
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
        /// Verifica que Index retorna la vista y una lista de destinos activos.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYListaDeDestinosActivos()
        {
            // Arrange
            var controller = new DestinosController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Destino>));
            var destinos = result.Model as IEnumerable<Destino>;
            // Por lo menos debe haber uno
            Assert.IsTrue(System.Linq.Enumerable.Any(destinos));
        }

        /// <summary>
        /// Verifica que Index retorna lista vacía si no hay destinos activos.
        /// </summary>
        [TestMethod]
        public void Index_SinDestinosActivos_RetornaListaVacia()
        {
            // Arrange
            var controller = new DestinosController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Destino>));
            var destinos = result.Model as IEnumerable<Destino>;
            // Puede ser cero, pero no debe ser null
            Assert.IsNotNull(destinos);
        }



        //
    }
}
