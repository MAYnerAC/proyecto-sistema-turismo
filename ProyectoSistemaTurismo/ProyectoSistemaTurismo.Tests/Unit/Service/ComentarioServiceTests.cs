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
    /// Pruebas unitarias para <see cref="ComentarioService"/>.
    /// Valida operaciones CRUD sobre comentarios turísticos.
    /// </summary>
    [TestClass]
    public class ComentarioServiceTests
    {

        /// <summary>
        /// Prueba que ObtenerTodos retorna todos los comentarios con relaciones.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodosLosComentarios()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que ObtenerTodosActivos retorna solo los comentarios activos.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarComentariosActivos()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que ObtenerPorId retorna el comentario correcto por su ID.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarComentarioPorId()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que Agregar añade un comentario con estado activo y fecha.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarComentarioConEstadoActivoYFecha()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Comentario>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Comentario).Returns(mockSet.Object);

            var service = new ComentarioService(mockContext.Object);
            var nuevoComentario = new Comentario { contenido = "Muy bueno" };

            // Act
            service.Agregar(nuevoComentario);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Comentario>(c =>
                c.contenido == "Muy bueno" &&
                c.estado == "A" &&
                c.fecha_comentario.HasValue &&
                c.fecha_comentario.Value.Date == DateTime.Now.Date
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que Actualizar guarda los cambios del comentario.
        /// No testeable como unit test por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Comentario> en EF6. Test sólo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que Eliminar cambia el estado del comentario a inactivo.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarComentarioComoInactivo()
        {
            // Arrange
            var comentario = new Comentario { id_comentario = 1, contenido = "Genial", estado = "A" };
            var mockSet = new Mock<DbSet<Comentario>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(comentario);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Comentario).Returns(mockSet.Object);

            var service = new ComentarioService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", comentario.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que ObtenerPorOferta retorna comentarios activos de una oferta.
        /// No testeable con unit test por uso de Include. Solo integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorOferta_DebeRetornarComentariosDeOferta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        //
    }
}
