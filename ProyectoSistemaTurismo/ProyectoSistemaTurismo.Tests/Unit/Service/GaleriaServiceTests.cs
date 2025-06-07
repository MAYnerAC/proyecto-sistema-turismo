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
    /// Pruebas unitarias para la clase <see cref="GaleriaService"/>.
    /// Valida operaciones CRUD sobre la galería de imágenes.
    /// Métodos con Include requieren integración.
    /// </summary>
    [TestClass]
    public class GaleriaServiceTests
    {
        /// <summary>
        /// Prueba que <see cref="GaleriaService.ObtenerTodos"/> retorna todas las imágenes con su oferta.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodasLasImagenes()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.ObtenerTodosActivos"/> retorna solo imágenes activas.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloImagenesActivas()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.ObtenerPorId"/> retorna la imagen correcta por ID.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarImagenPorId()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.Agregar"/> agregue una imagen con estado y fecha.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarImagenConEstadoYFecha()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Galeria>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Galeria).Returns(mockSet.Object);

            var service = new GaleriaService(mockContext.Object);
            var nueva = new Galeria { url_imagen = "foto1.png" };

            // Act
            service.Agregar(nueva);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Galeria>(g =>
                g.url_imagen == "foto1.png" &&
                g.estado == "A" &&
                g.fecha_subida.HasValue
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.Actualizar"/> guarde los cambios de la imagen.
        /// No testeable con unit test estándar por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Galeria> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.Eliminar"/> marque la imagen como inactiva.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarImagenComoInactiva()
        {
            // Arrange
            var galeria = new Galeria { id_imagen = 1, url_imagen = "foto1.png", estado = "A" };
            var mockSet = new Mock<DbSet<Galeria>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(galeria);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Galeria).Returns(mockSet.Object);

            var service = new GaleriaService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", galeria.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.ObtenerPorUsuario"/> retorna imágenes por usuario.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorUsuario_DebeRetornarImagenesPorUsuario()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="GaleriaService.ObtenerPorOferta"/> retorna imágenes por oferta.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorOferta_DebeRetornarImagenesPorOferta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }


        //
    }
}
