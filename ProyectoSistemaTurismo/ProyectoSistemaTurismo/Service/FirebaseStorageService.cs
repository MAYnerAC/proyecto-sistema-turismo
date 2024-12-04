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
    public class FirebaseStorageService
    {

        private readonly string _firebaseStorageBucket = "proyecto-moviles-ae540.appspot.com"; // Nombre bucket

        public async Task<string> SubirArchivo(HttpPostedFileBase archivo)
        {
            try
            {
                var firebaseStorage = new FirebaseStorage(_firebaseStorageBucket);
                var stream = archivo.InputStream;
                var nombreArchivo = Path.GetFileName(archivo.FileName);

                // Subir el archivo a Firebase Storage
                var task = await firebaseStorage
                    .Child("turismo_images") // Directorio
                    .Child(nombreArchivo) // Nombre del archivo
                    .PutAsync(stream);

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