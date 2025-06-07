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
    /// Pruebas unitarias para <see cref="Foto_ComentarioService"/>.
    /// Valida operaciones CRUD sobre fotos de comentarios.
    /// Métodos con Include requieren pruebas de integración.
    /// </summary>
    [TestClass]
    public class FotoComentarioServiceTests
    {
        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.ObtenerTodos"/> retorna todas las fotos con su comentario.
        /// No testeable con unit test por uso de Include.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodasLasFotos()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.ObtenerTodosActivos"/> retorna solo fotos activas.
        /// No testeable con unit test por uso de Include.
        /// </summary>
        [TestMethod]
        public void ObtenerTodosActivos_DebeRetornarSoloFotosActivas()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.ObtenerPorId"/> retorna la foto por ID.
        /// No testeable con unit test por uso de Include.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarFotoPorId()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.Agregar"/> agrega una foto con estado y fecha.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarFotoConEstadoYFecha()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Foto_Comentario>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Foto_Comentario).Returns(mockSet.Object);

            var service = new Foto_ComentarioService(mockContext.Object);
            var nueva = new Foto_Comentario { url_foto = "img001.png" };

            // Act
            service.Agregar(nueva);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Foto_Comentario>(f =>
                f.url_foto == "img001.png" &&
                f.estado == "A" &&
                f.fecha_subida.HasValue
            )), Times.Once());

            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.Actualizar"/> guarde los cambios de la foto.
        /// No testeable con unit test estándar por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Foto_Comentario> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.Eliminar"/> marca la foto como inactiva.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeMarcarFotoComoInactiva()
        {
            // Arrange
            var foto = new Foto_Comentario { id_foto = 1, url_foto = "img001.png", estado = "A" };
            var mockSet = new Mock<DbSet<Foto_Comentario>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(foto);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Foto_Comentario).Returns(mockSet.Object);

            var service = new Foto_ComentarioService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            Assert.AreEqual("I", foto.estado);
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Foto_ComentarioService.ObtenerPorComentario"/> retorna fotos por comentario.
        /// No testeable con unit test por uso de Include.
        /// </summary>
        [TestMethod]
        public void ObtenerPorComentario_DebeRetornarFotosPorComentario()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }


        //
    }
}
