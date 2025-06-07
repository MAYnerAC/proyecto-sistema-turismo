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
    /// Pruebas unitarias para la clase <see cref="Tipo_OfertaService"/>.
    /// Valida operaciones CRUD y filtrado de tipos de oferta.
    /// </summary>
    [TestClass]
    public class TipoOfertaServiceTests
    {

        /// <summary>
        /// Prueba que <see cref="Tipo_OfertaService.ObtenerTodos"/> retorna todos los tipos de oferta registrados.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodosLosTiposOferta()
        {
            // Arrange
            var data = new List<Tipo_Oferta>
            {
                new Tipo_Oferta { id_tipo_oferta = 1, nombre_tipo = "Hospedaje", estado = "A" },
                new Tipo_Oferta { id_tipo_oferta = 2, nombre_tipo = "Tours", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tipo_Oferta>>();
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Oferta).Returns(mockSet.Object);

            var service = new Tipo_OfertaService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("Hospedaje", resultado[0].nombre_tipo);
            Assert.AreEqual("Tours", resultado[1].nombre_tipo);
        }

        /// <summary>
        /// Prueba que <see cref="Tipo_OfertaService.ObtenerTodosActivos"/> retorna solo los tipos de oferta activos.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloTiposOfertaActivos()
        {
            // Arrange
            var data = new List<Tipo_Oferta>
            {
                new Tipo_Oferta { id_tipo_oferta = 1, nombre_tipo = "Hospedaje", estado = "A" },
                new Tipo_Oferta { id_tipo_oferta = 2, nombre_tipo = "Tours", estado = "I" },
                new Tipo_Oferta { id_tipo_oferta = 3, nombre_tipo = "Aventura", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tipo_Oferta>>();
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Oferta).Returns(mockSet.Object);

            var service = new Tipo_OfertaService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodosActivos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.IsTrue(resultado.All(to => to.estado == "A"));
        }

        /// <summary>
        /// Prueba que <see cref="Tipo_OfertaService.ObtenerPorId"/> retorna el tipo de oferta correcto por ID.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarTipoOfertaCorrecto()
        {
            // Arrange
            var data = new List<Tipo_Oferta>
            {
                new Tipo_Oferta { id_tipo_oferta = 1, nombre_tipo = "Hospedaje", estado = "A" },
                new Tipo_Oferta { id_tipo_oferta = 2, nombre_tipo = "Tours", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tipo_Oferta>>();
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tipo_Oferta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Oferta).Returns(mockSet.Object);

            var service = new Tipo_OfertaService(mockContext.Object);

            // Act
            var resultado = service.ObtenerPorId(2);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.id_tipo_oferta);
            Assert.AreEqual("Tours", resultado.nombre_tipo);
        }

        /// <summary>
        /// Prueba que <see cref="Tipo_OfertaService.Agregar"/> agregue un tipo de oferta con estado activo.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarTipoOfertaConEstadoActivo()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Tipo_Oferta>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Oferta).Returns(mockSet.Object);

            var service = new Tipo_OfertaService(mockContext.Object);
            var nueva = new Tipo_Oferta { nombre_tipo = "Gastronomía" };

            // Act
            service.Agregar(nueva);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Tipo_Oferta>(to => to.nombre_tipo == "Gastronomía" && to.estado == "A")), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Tipo_OfertaService.Actualizar"/> guarde los cambios.
        /// No es testeable en unit test estándar por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Tipo_Oferta> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Tipo_OfertaService.Eliminar"/> cambie el estado del tipo de oferta a inactivo.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarTipoOfertaComoInactiva()
        {
            // Arrange
            var tipoOferta = new Tipo_Oferta { id_tipo_oferta = 1, nombre_tipo = "Hospedaje", estado = "A" };
            var mockSet = new Mock<DbSet<Tipo_Oferta>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(tipoOferta);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Oferta).Returns(mockSet.Object);

            var service = new Tipo_OfertaService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", tipoOferta.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

    }
}
