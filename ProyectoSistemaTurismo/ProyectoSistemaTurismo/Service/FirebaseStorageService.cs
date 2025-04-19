using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//
using Firebase.Storage;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para gestionar la subida y validación de archivos en Firebase Storage.
    /// </summary>
    public class FirebaseStorageService
    {
        // Nombre del bucket de Firebase Storage
        private readonly string _firebaseStorageBucket = "proyecto-moviles-ae540.appspot.com"; // Nombre bucket

        /// <summary>
        /// Sube un archivo al directorio "turismo_images" en Firebase Storage.
        /// </summary>
        /// <param name="archivo">Archivo recibido desde el formulario web</param>
        /// <returns>URL del archivo subido o URL simulada en caso de error</returns>
        public async Task<string> SubirArchivo(HttpPostedFileBase archivo)
        {
            try
            {
                var firebaseStorage = new FirebaseStorage(_firebaseStorageBucket);
                var stream = archivo.InputStream;
                var nombreArchivo = Path.GetFileName(archivo.FileName);

                // Subir el archivo a Firebase Storage
                var task = await firebaseStorage
                    .Child("turismo_images") // Directorio en Firebase
                    .Child(nombreArchivo)    // Nombre del archivo
                    .PutAsync(stream);       // Subida del archivo como stream

                // Retornar la URL del archivo subido
                return task;


            }
            catch (Exception)
            {
                // Retornar una URL falsa (simulacion)
                string nombreArchivo = Path.GetFileName(archivo.FileName);
                return "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);
            }
        }

        /// <summary>
        /// Valida si el archivo recibido es una imagen permitida y no supera el tamaño máximo.
        /// </summary>
        /// <param name="archivoImagen">Archivo recibido desde el formulario</param>
        /// <returns>Mensaje de error si no es válido, o null si es válido</returns>
        public string ValidarArchivoImagen(HttpPostedFileBase archivoImagen)
        {
            string[] tiposPermitidos = { "image/jpeg", "image/png" };
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