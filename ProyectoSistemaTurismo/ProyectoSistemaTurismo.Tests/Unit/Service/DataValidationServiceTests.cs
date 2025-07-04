﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using Moq;
using ProyectoSistemaTurismo.Service;
using System.Web;

namespace ProyectoSistemaTurismo.Tests.Unit.Service
{
    /// <summary>
    /// Pruebas unitarias para la clase <see cref="DataValidationServiceTests"/>.
    /// Valida la lógica de validación de archivos para subida al Storage.
    /// </summary>
    [TestClass]
    public class DataValidationServiceTests
    {

        /// <summary>
        /// Prueba que el validador rechaza archivos no permitidos.
        /// </summary>
        [TestMethod]
        public void ValidarArchivoImagen_DebeRechazarTipoNoPermitido()
        {
            // Arrange
            var fileMock = new Mock<HttpPostedFileBase>();
            fileMock.Setup(f => f.ContentType).Returns("application/pdf");
            fileMock.Setup(f => f.ContentLength).Returns(1000);

            var service = new DataValidationService();

            // Act
            var result = service.ValidarArchivoImagen(fileMock.Object);

            // Assert
            Assert.AreEqual("El archivo debe ser una imagen en formato JPG o PNG.", result);
        }

        /// <summary>
        /// Prueba que el validador rechaza archivos demasiado grandes.
        /// </summary>
        [TestMethod]
        public void ValidarArchivoImagen_DebeRechazarArchivoDemasiadoGrande()
        {
            var fileMock = new Mock<HttpPostedFileBase>();
            fileMock.Setup(f => f.ContentType).Returns("image/jpeg");
            fileMock.Setup(f => f.ContentLength).Returns(6 * 1024 * 1024); // 6 MB

            var service = new DataValidationService();

            var result = service.ValidarArchivoImagen(fileMock.Object);

            Assert.AreEqual("El archivo es demasiado grande. El tamaño máximo permitido es 5 MB.", result);
        }

        /// <summary>
        /// Prueba que el validador acepta archivos válidos.
        /// </summary>
        [TestMethod]
        public void ValidarArchivoImagen_DebeAceptarArchivoValido()
        {
            var fileMock = new Mock<HttpPostedFileBase>();
            fileMock.Setup(f => f.ContentType).Returns("image/png");
            fileMock.Setup(f => f.ContentLength).Returns(1024 * 1024); // 1 MB

            var service = new DataValidationService();

            var result = service.ValidarArchivoImagen(fileMock.Object);

            Assert.IsNull(result); // null = válido
        }


        //

    }
}
