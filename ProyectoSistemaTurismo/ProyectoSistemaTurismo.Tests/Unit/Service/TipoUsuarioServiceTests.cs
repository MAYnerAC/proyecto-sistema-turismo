using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
//
using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ProyectoSistemaTurismo.Tests.Unit.Service
{
    /// <summary>
    /// Pruebas unitarias para la clase <see cref="Tipo_UsuarioService"/>.
    /// Valida la obtención de tipos de usuario desde un contexto simulado.
    /// </summary>
    [TestClass]
    public class TipoUsuarioServiceTests
    {
        /// <summary>
        /// Prueba que <see cref="Tipo_UsuarioService.ObtenerTodos"/> retorne la lista completa de tipos de usuario.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodosLosTiposUsuario()
        {
            // Arrange

            // Simulamos una lista de tipos de usuario.
            var data = new List<Tipo_Usuario>
            {
                new Tipo_Usuario { id_tipo_usuario = 1, nombre_tipo = "Admin", estado = "A" },
                new Tipo_Usuario { id_tipo_usuario = 2, nombre_tipo = "Proveedor", estado = "A" }
            }.AsQueryable();

            // Mock de DbSet<Tipo_Usuario>
            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();

            mockContext.Setup(c => c.Tipo_Usuario).Returns(mockSet.Object);

            var service = new Tipo_UsuarioService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("Admin", resultado[0].nombre_tipo);
            Assert.AreEqual("Proveedor", resultado[1].nombre_tipo);
        }

        /// <summary>
        /// Prueba que ObtenerTodosActivos retorne solo los tipos de usuario activos.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloTiposUsuarioActivos()
        {
            // Arrange
            var data = new List<Tipo_Usuario>
            {
                new Tipo_Usuario { id_tipo_usuario = 1, nombre_tipo = "Admin", estado = "A" },
                new Tipo_Usuario { id_tipo_usuario = 2, nombre_tipo = "Proveedor", estado = "A" },
                new Tipo_Usuario { id_tipo_usuario = 3, nombre_tipo = "Inactivo", estado = "I" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Usuario).Returns(mockSet.Object);

            var service = new Tipo_UsuarioService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodosActivos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.IsTrue(resultado.All(tu => tu.estado == "A"));
        }

        /// <summary>
        /// Prueba que ObtenerPorId retorne el tipo de usuario correcto cuando existe.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarTipoUsuarioPorId()
        {
            // Arrange
            var data = new List<Tipo_Usuario>
    {
        new Tipo_Usuario { id_tipo_usuario = 1, nombre_tipo = "Admin", estado = "A" },
        new Tipo_Usuario { id_tipo_usuario = 2, nombre_tipo = "Proveedor", estado = "A" }
    }.AsQueryable();

            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tipo_Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Usuario).Returns(mockSet.Object);

            var service = new Tipo_UsuarioService(mockContext.Object);

            // Act
            var resultado = service.ObtenerPorId(2);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.id_tipo_usuario);
            Assert.AreEqual("Proveedor", resultado.nombre_tipo);
        }

        /// <summary>
        /// Prueba que Agregar añada un nuevo tipo de usuario y establezca el estado en "A".
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarTipoUsuarioConEstadoActivo()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            var mockContext = new Mock<IModeloSistema>();

            mockContext.Setup(c => c.Tipo_Usuario).Returns(mockSet.Object);

            var service = new Tipo_UsuarioService(mockContext.Object);
            var nuevoTipo = new Tipo_Usuario { nombre_tipo = "Turista" };

            // Act
            service.Agregar(nuevoTipo);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Tipo_Usuario>(tu => tu.nombre_tipo == "Turista" && tu.estado == "A")), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que Actualizar cambie el estado de la entidad y guarde los cambios.
        /// Este método no puede ser probado completamente con mocks,
        /// ya que DbEntityEntry&lt;T&gt; no es mockeable.
        /// La línea 'Entry(...).State = Modified' solo se puede cubrir con pruebas de integración.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            /*
            // Arrange
            var tipoUsuario = new Tipo_Usuario { id_tipo_usuario = 1, nombre_tipo = "Admin", estado = "A" };
            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            var mockContext = new Mock<IModeloSistema>();

            // Mock de DbEntityEntry<Tipo_Usuario>
            var mockEntry = new Mock<DbEntityEntry<Tipo_Usuario>>();
            mockContext.Setup(c => c.Tipo_Usuario).Returns(mockSet.Object);

            // ¡Este setup es CLAVE para que no lance NullReferenceException!
            mockContext.Setup(c => c.Entry(tipoUsuario)).Returns(mockEntry.Object);

            var service = new Tipo_UsuarioService(mockContext.Object);

            // Act
            service.Actualizar(tipoUsuario);

            // Assert
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
            */

            // Arrange
            var tipoUsuario = new Tipo_Usuario { id_tipo_usuario = 1, nombre_tipo = "Admin", estado = "A" };
            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            var mockContext = new Mock<IModeloSistema>();
            var service = new Tipo_UsuarioService(mockContext.Object);

            // Act & Assert
            // No se puede testear correctamente en unit test con Moq.
            // Este test debe implementarse como test de integración.
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Tipo_Usuario> en Entity Framework 6. Test sólo posible como prueba de integración.");

        }



        /// <summary>
        /// Prueba que Eliminar marque el tipo de usuario como inactivo y guarde los cambios.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarTipoUsuarioComoInactivo()
        {
            // Arrange
            var tipoUsuario = new Tipo_Usuario { id_tipo_usuario = 1, nombre_tipo = "Admin", estado = "A" };

            var mockSet = new Mock<DbSet<Tipo_Usuario>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(tipoUsuario);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Tipo_Usuario).Returns(mockSet.Object);

            var service = new Tipo_UsuarioService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", tipoUsuario.estado, "El estado debería ser 'I' (Inactivo)");
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }






        //
    }
}
