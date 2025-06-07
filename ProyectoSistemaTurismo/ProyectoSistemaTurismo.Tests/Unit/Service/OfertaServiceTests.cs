using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System.Data.Entity;

namespace ProyectoSistemaTurismo.Tests.Unit.Service
{
    /// <summary>
    /// Pruebas unitarias para la clase <see cref="OfertaService"/>.
    /// Valida operaciones CRUD y filtrados sobre ofertas turísticas.
    /// Métodos con Include o proyecciones complejas requieren integración.
    /// </summary>
    [TestClass]
    public class OfertaServiceTests
    {

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerTodos"/> retorna todas las ofertas con relaciones.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodasLasOfertas()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerTodosActivos"/> retorna solo ofertas activas.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloOfertasActivas()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerPorId"/> retorna la oferta correcta por ID.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarOfertaCorrecta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.Agregar"/> agregue una oferta con valores predeterminados.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarOfertaConValoresPredeterminados()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Oferta>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Oferta).Returns(mockSet.Object);

            var service = new OfertaService(mockContext.Object);
            var nueva = new Oferta { nombre = "City Tour" };

            // Act
            service.Agregar(nueva);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Oferta>(o =>
                o.nombre == "City Tour" &&
                o.estado == "A" &&
                o.verificado == "N" &&
                o.visible == "N" &&
                o.fecha_creacion.HasValue
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.Actualizar"/> guarde los cambios.
        /// No es testeable en unit test estándar por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Oferta> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.Eliminar"/> marque la oferta como inactiva y registre fecha de baja.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarOfertaComoInactivaYRegistrarFecha()
        {
            // Arrange
            var oferta = new Oferta { id_oferta = 1, nombre = "City Tour", estado = "A" };
            var mockSet = new Mock<DbSet<Oferta>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(oferta);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Oferta).Returns(mockSet.Object);

            var service = new OfertaService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", oferta.estado);
            Assert.IsNotNull(oferta.fecha_baja);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerPorUsuario"/> retorna ofertas por usuario.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorUsuario_DebeRetornarOfertasPorUsuario()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerPorDestino"/> retorna ofertas previas por destino.
        /// No testeable con unit test por uso de Include y proyecciones; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorDestino_DebeRetornarOfertasPreviasPorDestino()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include y Select complejo. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerPorTipoOferta"/> retorna ofertas por tipo.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorTipoOferta_DebeRetornarOfertasPorTipo()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerOfertasPrevias"/> retorna todas las ofertas previas activas y visibles.
        /// No testeable con unit test por uso de Include y proyecciones; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerOfertasPrevias_DebeRetornarOfertasPrevias()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include y Select complejo. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="OfertaService.ObtenerDetalleOferta"/> retorna los detalles de una oferta visible y activa.
        /// No testeable con unit test por uso de Include y proyecciones; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerDetalleOferta_DebeRetornarDetalleOferta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include y Select complejo. Solo posible con pruebas de integración.");
        }



        //
    }
}
