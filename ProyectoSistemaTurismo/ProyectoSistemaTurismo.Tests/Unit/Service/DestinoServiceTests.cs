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
    /// Pruebas unitarias para <see cref="DestinoService"/>.
    /// Valida operaciones CRUD y filtrado de destinos turísticos.
    /// </summary>
    [TestClass]
    public class DestinoServiceTests
    {
        /// <summary>
        /// Prueba que ObtenerTodos retorna todos los destinos registrados.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodosLosDestinos()
        {
            // Arrange
            var data = new List<Destino>
            {
                new Destino { id_destino = 1, nombre_destino = "Tacna", estado = "A" },
                new Destino { id_destino = 2, nombre_destino = "Tarata", estado = "I" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Destino>>();
            mockSet.As<IQueryable<Destino>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Destino).Returns(mockSet.Object);

            var service = new DestinoService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("Tacna", resultado[0].nombre_destino);
            Assert.AreEqual("Tarata", resultado[1].nombre_destino);
        }

        /// <summary>
        /// Prueba que ObtenerTodosActivos retorna solo los destinos activos.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloDestinosActivos()
        {
            // Arrange
            var data = new List<Destino>
            {
                new Destino { id_destino = 1, nombre_destino = "Tacna", estado = "A" },
                new Destino { id_destino = 2, nombre_destino = "Tarata", estado = "I" },
                new Destino { id_destino = 3, nombre_destino = "Locumba", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Destino>>();
            mockSet.As<IQueryable<Destino>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Destino).Returns(mockSet.Object);

            var service = new DestinoService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodosActivos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.IsTrue(resultado.All(d => d.estado == "A"));
        }

        /// <summary>
        /// Prueba que ObtenerPorId retorna el destino correcto por su ID.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarDestinoPorId()
        {
            // Arrange
            var data = new List<Destino>
            {
                new Destino { id_destino = 1, nombre_destino = "Tacna", estado = "A" },
                new Destino { id_destino = 2, nombre_destino = "Tarata", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Destino>>();
            mockSet.As<IQueryable<Destino>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Destino>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Destino).Returns(mockSet.Object);

            var service = new DestinoService(mockContext.Object);

            // Act
            var resultado = service.ObtenerPorId(2);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.id_destino);
            Assert.AreEqual("Tarata", resultado.nombre_destino);
        }

        /// <summary>
        /// Prueba que Agregar añade un destino con estado activo.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarDestinoConEstadoActivo()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Destino>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Destino).Returns(mockSet.Object);

            var service = new DestinoService(mockContext.Object);
            var nuevoDestino = new Destino { nombre_destino = "Palca" };

            // Act
            service.Agregar(nuevoDestino);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Destino>(d =>
                d.nombre_destino == "Palca" && d.estado == "A"
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que Actualizar guarda los cambios del destino.
        /// No testeable como unit test por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Destino> en EF6. Test sólo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que Eliminar cambia el estado del destino a inactivo.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarDestinoComoInactivo()
        {
            // Arrange
            var destino = new Destino { id_destino = 1, nombre_destino = "Tacna", estado = "A" };
            var mockSet = new Mock<DbSet<Destino>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(destino);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Destino).Returns(mockSet.Object);

            var service = new DestinoService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", destino.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        //
    }
}
