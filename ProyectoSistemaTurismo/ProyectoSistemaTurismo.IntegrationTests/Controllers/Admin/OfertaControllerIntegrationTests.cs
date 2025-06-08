using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using System.Collections.Generic;
using System.Web.Mvc;
using ProyectoSistemaTurismo.Areas.Admin.Controllers;
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.IntegrationTests.Controllers.Admin
{
    /// <summary>
    /// Pruebas de integración para el controlador OfertaController.
    /// Valida el flujo real entre controller, servicios y la base de datos.
    /// </summary>
    [TestClass]
    public class OfertaControllerIntegrationTests
    {
        /// <summary>
        /// Prueba que Index devuelve una vista y un modelo de tipo List<Oferta>.
        /// Escenario: La base de datos puede tener o no registros.
        /// </summary>
        [TestMethod]
        public void Index_RetornaVistaYModeloCorrecto()
        {
            // Arrange: Crea instancia real del controller
            var controller = new OfertaController();

            // Act: Llama a la acción Index
            var result = controller.Index() as ViewResult;

            // Assert: Verifica resultado y tipo de modelo
            Assert.IsNotNull(result, "Debe retornar una ViewResult");
            Assert.IsNotNull(result.Model, "El modelo de la vista no debe ser null");
            Assert.IsInstanceOfType(result.Model, typeof(List<Oferta>), "El modelo debe ser una lista de ofertas");
            var ofertas = result.Model as List<Oferta>;
            Assert.IsTrue(ofertas.Count >= 0, "La lista puede estar vacía pero debe existir.");
        }


        /// <summary>
        /// Prueba que Detalles devuelve la vista con el modelo correcto si la oferta existe.
        /// Escenario: Se asume que existe una oferta con ID 1 (ajusta el ID según tu BD de prueba).
        /// </summary>
        [TestMethod]
        public void Detalles_OfertaExistente_RetornaVistaYModelo()
        {
            // Arrange
            var controller = new OfertaController();
            int ofertaExistenteId = 1; // ID válido de la BD de pruebas.

            // Act
            var result = controller.Detalles(ofertaExistenteId) as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Debe devolver una vista.");
            Assert.IsInstanceOfType(result.Model, typeof(Oferta), "El modelo debe ser de tipo Oferta.");
        }

        /// <summary>
        /// Prueba que Detalles redirecciona si la oferta no existe.
        /// Escenario: Se asume que el ID -1 no existe.
        /// </summary>
        [TestMethod]
        public void Detalles_OfertaNoExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new OfertaController();
            int idInexistente = -1;

            // Act
            var result = controller.Detalles(idInexistente) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "Debe redireccionar si la oferta no existe.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Crear GET retorna la vista correctamente (con los ViewBag de datos auxiliares).
        /// </summary>
        [TestMethod]
        public void Crear_Get_RetornaVistaConDatos()
        {
            // Arrange
            var controller = new OfertaController();

            // Act
            var result = controller.Crear() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Debe devolver la vista de creación.");
            Assert.IsNotNull(result.ViewBag.Destinos, "Debe cargar destinos.");
            Assert.IsNotNull(result.ViewBag.TiposOferta, "Debe cargar tipos de oferta.");
            Assert.IsNotNull(result.ViewBag.Usuarios, "Debe cargar usuarios.");
        }

        /// <summary>
        /// Prueba que Crear POST con modelo válido redirecciona a Index y agrega la oferta.
        /// Requiere una base de datos preparada y puede dejar datos de prueba.
        /// </summary>
        [TestMethod]
        public void Crear_Post_OfertaValida_RedireccionaAIndex()
        {
            // Arrange
            var controller = new OfertaController();
            var oferta = new Oferta
            {
                nombre = "Oferta Completa Prueba",
                descripcion = "Descripción de oferta de integración",
                direccion = "Av. Integración 123",
                ubicacion_lat = -16.4090m,
                ubicacion_lon = -71.5375m,
                telefono = "123456789",
                email_contacto = "oferta@prueba.com",
                sitio_web = "http://www.ofertaprueba.com",
                vinculo_con_oferta = "Ninguno",
                id_usuario = 1,
                id_tipo_oferta = 1,
                id_destino = 1,
                fecha_creacion = DateTime.Now,
                estado = "A",
                verificado = "N",
                visible = "N",
                motivo_baja = null
            };

            // Act
            var result = controller.Crear(oferta) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "Debe redireccionar al crear una oferta válida y completa.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Editar GET retorna la vista con la oferta correcta si existe.
        /// </summary>
        [TestMethod]
        public void Editar_Get_OfertaExistente_RetornaVista()
        {
            // Arrange
            var controller = new OfertaController();
            int ofertaExistenteId = 1;

            // Act
            var result = controller.Editar(ofertaExistenteId) as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Debe devolver la vista de edición.");
            Assert.IsInstanceOfType(result.Model, typeof(Oferta), "El modelo debe ser una oferta.");
        }

        /// <summary>
        /// Prueba que Editar POST con datos válidos redirecciona a Index.
        /// Debe existir la oferta a editar.
        /// </summary>
        [TestMethod]
        public void Editar_Post_OfertaValida_RedireccionaAIndex()
        {
            // Arrange
            var controller = new OfertaController();
            // Busca la oferta existente para editar del ID válido "1"
            int ofertaId = 1;
            var ofertaExistente = controller.Detalles(ofertaId) as ViewResult;
            var oferta = ofertaExistente?.Model as Oferta;
            if (oferta == null) Assert.Inconclusive("No existe la oferta a editar para la prueba.");

            oferta.descripcion = "Descripción actualizada de prueba";

            // Act
            var result = controller.Editar(oferta) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "Debe redireccionar después de editar.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Prueba que Eliminar POST elimina la oferta (lógico) y redirecciona.
        /// </summary>
        [TestMethod]
        public void Eliminar_Post_OfertaExistente_RedireccionaAIndex()
        {
            // Arrange
            var controller = new OfertaController();
            int ofertaId = 1; // ID de la BD de prueba

            // Act
            var result = controller.Eliminar(ofertaId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "Debe redireccionar después de eliminar.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }




        //
    }
}
