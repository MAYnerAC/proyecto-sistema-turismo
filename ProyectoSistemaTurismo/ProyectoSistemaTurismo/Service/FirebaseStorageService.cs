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
        public virtual async Task<string> SubirArchivo(HttpPostedFileBase archivo)
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



        //
    }
}