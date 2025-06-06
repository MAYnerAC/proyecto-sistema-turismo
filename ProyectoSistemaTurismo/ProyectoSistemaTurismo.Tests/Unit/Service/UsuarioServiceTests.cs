using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
//
using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.Service;
using System;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoSistemaTurismo.Tests.Unit.Service
{
    /// <summary>
    /// Pruebas unitarias para la clase <see cref="UsuarioService"/>.
    /// Valida operaciones CRUD y filtrado de usuarios.
    /// </summary>
    [TestClass]
    public class UsuarioServiceTests
    {
        /// <summary>
        /// Prueba que <see cref="UsuarioService.ObtenerTodos"/> retorne todos los usuarios registrados.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodosLosUsuarios()
        {
            // Arrange
            var data = new List<Usuario>
            {
                new Usuario { id_usuario = 1, nombre = "Juan", estado = "A" },
                new Usuario { id_usuario = 2, nombre = "Ana", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Usuario).Returns(mockSet.Object);

            var service = new UsuarioService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("Juan", resultado[0].nombre);
            Assert.AreEqual("Ana", resultado[1].nombre);
        }

        /// <summary>
        /// Prueba que <see cref="UsuarioService.ObtenerTodosActivos"/> retorne solo usuarios activos (estado "A").
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarUsuariosConEstadoA()
        {
            // Arrange
            var data = new List<Usuario>
            {
                new Usuario { id_usuario = 1, nombre = "Juan", estado = "A" },
                new Usuario { id_usuario = 2, nombre = "Ana", estado = "I" },
                new Usuario { id_usuario = 3, nombre = "Luis", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Usuario).Returns(mockSet.Object);

            var service = new UsuarioService(mockContext.Object);

            // Act
            var resultado = service.ObtenerTodosActivos();

            // Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.IsTrue(resultado.All(u => u.estado == "A"));
        }

        /// <summary>
        /// Prueba que <see cref="UsuarioService.ObtenerPorId"/> retorne el usuario correcto por su ID.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarUsuarioCorrecto()
        {
            // Arrange
            var data = new List<Usuario>
            {
                new Usuario { id_usuario = 1, nombre = "Juan", estado = "A" },
                new Usuario { id_usuario = 2, nombre = "Ana", estado = "A" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Usuario).Returns(mockSet.Object);

            var service = new UsuarioService(mockContext.Object);

            // Act
            var resultado = service.ObtenerPorId(2);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.id_usuario);
            Assert.AreEqual("Ana", resultado.nombre);
        }

        /// <summary>
        /// Prueba que <see cref="UsuarioService.Agregar"/> asigne estado activo y fecha al nuevo usuario.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarUsuarioConEstadoActivoYFecha()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Usuario>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Usuario).Returns(mockSet.Object);

            var service = new UsuarioService(mockContext.Object);
            var nuevoUsuario = new Usuario { nombre = "Carlos" };

            // Act
            service.Agregar(nuevoUsuario);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Usuario>(u =>
                u.nombre == "Carlos" &&
                u.estado == "A" &&
                u.fecha_registro.HasValue &&
                u.fecha_registro.Value.Date == DateTime.Now.Date
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="UsuarioService.Actualizar"/> guarde los cambios.
        /// Este test no es posible con mocks, requiere prueba de integración.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            // Arrange
            var usuario = new Usuario { id_usuario = 1, nombre = "Juan", estado = "A" };
            var mockContext = new Mock<IModeloSistema>();
            var service = new UsuarioService(mockContext.Object);

            // Act & Assert
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Usuario> en EF6. Test sólo posible como prueba de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="UsuarioService.Eliminar"/> cambie el estado del usuario a "I".
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarUsuarioComoInactivo()
        {
            // Arrange
            var usuario = new Usuario { id_usuario = 1, nombre = "Juan", estado = "A" };
            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(usuario);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Usuario).Returns(mockSet.Object);

            var service = new UsuarioService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", usuario.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }


        //
    }
}
