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
    /// Pruebas unitarias para <see cref="EtiquetaService"/>.
    /// Valida operaciones CRUD sobre etiquetas.
    /// </summary>
    [TestClass]
    public class EtiquetaServiceTests
    {
        /// <summary>
        /// Prueba que <see cref="EtiquetaService.ObtenerTodos"/> retorne todas las etiquetas.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodasLasEtiquetas()
        {
            // Arrange
            var data = new List<Etiqueta>
            {
                new Etiqueta { id_etiqueta = 1, nombre_etiqueta = "Turismo", estado = "A" },
                new Etiqueta { id_etiqueta = 2, nombre_etiqueta = "Aventura", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Etiqueta>>();
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta).Returns(mockSet.Object);

            var service = new EtiquetaService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("Turismo", resultado[0].nombre_etiqueta);
            Assert.AreEqual("Aventura", resultado[1].nombre_etiqueta);
        }

        /// <summary>
        /// Prueba que <see cref="EtiquetaService.ObtenerTodosActivos"/> retorne solo etiquetas activas.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloEtiquetasActivas()
        {
            // Arrange
            var data = new List<Etiqueta>
            {
                new Etiqueta { id_etiqueta = 1, nombre_etiqueta = "Turismo", estado = "A" },
                new Etiqueta { id_etiqueta = 2, nombre_etiqueta = "Aventura", estado = "I" },
                new Etiqueta { id_etiqueta = 3, nombre_etiqueta = "Gastronomía", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Etiqueta>>();
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta).Returns(mockSet.Object);

            var service = new EtiquetaService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodosActivos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.IsTrue(resultado.All(e => e.estado == "A"));
        }

        /// <summary>
        /// Prueba que <see cref="EtiquetaService.ObtenerPorId"/> retorne la etiqueta correcta por ID.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarEtiquetaCorrecta()
        {
            // Arrange
            var data = new List<Etiqueta>
            {
                new Etiqueta { id_etiqueta = 1, nombre_etiqueta = "Turismo", estado = "A" },
                new Etiqueta { id_etiqueta = 2, nombre_etiqueta = "Aventura", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Etiqueta>>();
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Etiqueta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta).Returns(mockSet.Object);

            var service = new EtiquetaService(mockContext.Object);

            // Act
            var resultado = service.ObtenerPorId(2);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.id_etiqueta);
            Assert.AreEqual("Aventura", resultado.nombre_etiqueta);
        }

        /// <summary>
        /// Prueba que <see cref="EtiquetaService.Agregar"/> agregue la etiqueta como activa.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarEtiquetaComoActiva()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Etiqueta>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta).Returns(mockSet.Object);

            var service = new EtiquetaService(mockContext.Object);
            var nuevaEtiqueta = new Etiqueta { nombre_etiqueta = "Nueva" };

            // Act
            service.Agregar(nuevaEtiqueta);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Etiqueta>(e =>
                e.nombre_etiqueta == "Nueva" &&
                e.estado == "A"
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="EtiquetaService.Actualizar"/> guarde los cambios de la etiqueta.
        /// No testeable con unit test estándar por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Etiqueta> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="EtiquetaService.Eliminar"/> cambie el estado de la etiqueta a "I".
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarEtiquetaComoInactiva()
        {
            // Arrange
            var etiqueta = new Etiqueta { id_etiqueta = 1, nombre_etiqueta = "Turismo", estado = "A" };
            var mockSet = new Mock<DbSet<Etiqueta>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(etiqueta);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Etiqueta).Returns(mockSet.Object);

            var service = new EtiquetaService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", etiqueta.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        //

    }
}
