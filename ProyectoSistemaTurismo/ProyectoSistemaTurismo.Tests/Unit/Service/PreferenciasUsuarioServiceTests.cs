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
    /// Pruebas unitarias para la clase <see cref="Preferencias_UsuarioService"/>.
    /// Valida operaciones CRUD para preferencias de usuario.
    /// Métodos con Include requieren integración.
    /// </summary>
    [TestClass]
    public class PreferenciasUsuarioServiceTests
    {

        /// <summary>
        /// Prueba que <see cref="Preferencias_UsuarioService.ObtenerTodos"/> retorna todas las preferencias.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerTodos_DebeRetornarTodasLasPreferencias()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Preferencias_UsuarioService.ObtenerPorId"/> retorna la preferencia correcta.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_DebeRetornarPreferenciaCorrecta()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Preferencias_UsuarioService.Agregar"/> agregue una preferencia.
        /// </summary>
        [TestMethod]
        public void Agregar_DebeAgregarPreferencia()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Preferencias_Usuario>>();
            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Preferencias_Usuario).Returns(mockSet.Object);

            var service = new Preferencias_UsuarioService(mockContext.Object);
            var nueva = new Preferencias_Usuario { id_usuario = 1, id_etiqueta = 2 };

            // Act
            service.Agregar(nueva);

            // Assert
            mockSet.Verify(m => m.Add(It.Is<Preferencias_Usuario>(p => p.id_usuario == 1 && p.id_etiqueta == 2)), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Preferencias_UsuarioService.Actualizar"/> guarde los cambios.
        /// No es testeable en unit test estándar por uso de Entry/DbEntityEntry.
        /// </summary>
        [TestMethod]
        public void Actualizar_DebeGuardarCambios()
        {
            Assert.Inconclusive("No se puede mockear DbEntityEntry<Preferencias_Usuario> en EF6. Solo posible con pruebas de integración.");
        }

        /// <summary>
        /// Prueba que <see cref="Preferencias_UsuarioService.Eliminar"/> elimine la preferencia del contexto.
        /// </summary>
        [TestMethod]
        public void Eliminar_DebeEliminarPreferencia()
        {
            // Arrange
            var preferencia = new Preferencias_Usuario { id_preferencia = 1, id_usuario = 1, id_etiqueta = 2 };
            var mockSet = new Mock<DbSet<Preferencias_Usuario>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(preferencia);

            var mockContext = new Mock<IModeloSistema>();
            mockContext.Setup(c => c.Preferencias_Usuario).Returns(mockSet.Object);

            var service = new Preferencias_UsuarioService(mockContext.Object);

            // Act
            service.Eliminar(1);

            // Assert
            mockSet.Verify(m => m.Remove(It.Is<Preferencias_Usuario>(p => p == preferencia)), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Prueba que <see cref="Preferencias_UsuarioService.ObtenerPorUsuario"/> retorna las preferencias por usuario.
        /// No testeable con unit test por uso de Include; requiere integración.
        /// </summary>
        [TestMethod]
        public void ObtenerPorUsuario_DebeRetornarPreferenciasPorUsuario()
        {
            Assert.Inconclusive("No se puede probar este método con mocks porque utiliza Include. Solo posible con pruebas de integración.");
        }


        //
    }
}
