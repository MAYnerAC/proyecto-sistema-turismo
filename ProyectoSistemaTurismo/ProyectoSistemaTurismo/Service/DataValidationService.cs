using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class DataValidationService
    {

        /// <summary>
        /// Valida si el archivo recibido es una imagen permitida y no supera el tamaño máximo.
        /// </summary>
        /// <param name="archivoImagen">Archivo recibido desde el formulario</param>
        /// <returns>Mensaje de error si no es válido, o null si es válido</returns>
        public virtual string ValidarArchivoImagen(HttpPostedFileBase archivoImagen)
        {
            string[] tiposPermitidos = { "image/jpeg", "image/png" };//, "image/gif", "image/webp"
            int tamañoMaximoMB = 5;  // Tamaño máximo 5MB // Es 4 por defecto en "<system.web>"

            // Tipo de archivo
            if (!tiposPermitidos.Contains(archivoImagen.ContentType))
            {
                return "El archivo debe ser una imagen en formato JPG o PNG.";
            }

            // Tamaño
            if (archivoImagen.ContentLength > tamañoMaximoMB * 1024 * 1024)
            {
                return $"El archivo es demasiado grande. El tamaño máximo permitido es {tamañoMaximoMB} MB.";
            }

            // Correcto
            return null;
        }



        //
    }
}