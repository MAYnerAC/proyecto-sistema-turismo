using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using Moq;
using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoSistemaTurismo.Tests.Unit.Service
{
    /// <summary>
    /// Pruebas unitarias para <see cref="Etiqueta_OfertaService"/>.
    /// Valida operaciones CRUD sobre la relación Etiqueta-Oferta.
    /// </summary>
    [TestClass]
    public class EtiquetaOfertaServiceTests
    {

        /// <summary>
        /// Prueba que <see cref="Etiqueta_OfertaService.ObtenerTodos"/> retorne todas las relaciones registradas.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodasLasRelaciones()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Etiqueta_OfertaService.ObtenerPorId"/> retorne la relación correcta.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarRelacionCorrecta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Etiqueta_OfertaService.Agregar"/> agregue una nueva relación.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarNuevaRelacion()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Etiqueta_Oferta>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta_Oferta).Returns(mockSet.Object);

            var service = new Etiqueta_OfertaService(mockContext.Object);
            var nuevaRelacion = new Etiqueta_Oferta { id_etiqueta_oferta = 1, id_oferta = 10, id_etiqueta = 20 };

            // Act
            service.Agregar(nuevaRelacion);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Etiqueta_Oferta>(eo =>
                eo.id_oferta == 10 && eo.id_etiqueta == 20
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Etiqueta_OfertaService.Actualizar"/> guarde los cambios.
        /// No testeable con unit test por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Etiqueta_Oferta> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Etiqueta_OfertaService.Eliminar"/> elimine una relación existente.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeEliminarRelacion()
        {
            // Arrange
            var relacion = new Etiqueta_Oferta { id_etiqueta_oferta = 1, id_oferta = 10, id_etiqueta = 20 };
            var mockSet = new Mock<DbSet<Etiqueta_Oferta>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(relacion);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta_Oferta).Returns(mockSet.Object);

            var service = new Etiqueta_OfertaService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            mockSet.Verify(m => m.Remove(It.Is<Etiqueta_Oferta>(eo => eo == relacion)), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Etiqueta_OfertaService.ObtenerPorOferta"/> retorne relaciones asociadas a una oferta.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorOferta_DebeRetornarRelacionesPorOferta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        //

    }
}
