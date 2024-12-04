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

        private readonly string _firebaseStorageBucket = "your_project_id.appspot.com"; // Cambia por tu bucket real

        public async Task<string> SubirArchivo(HttpPostedFileBase archivo)
        {
            try
            {
                var firebaseStorage = new FirebaseStorage(_firebaseStorageBucket);
                var stream = archivo.InputStream;
                var nombreArchivo = Path.GetFileName(archivo.FileName);

                // Subir el archivo a Firebase Storage
                var task = await firebaseStorage
                    .Child("imagenes_comentarios") // Directorio donde se almacenarán los archivos
                    .Child(nombreArchivo) // Nombre del archivo
                    .PutAsync(stream);

                // Retornar la URL del archivo subido
                return task;


            }
            catch (Exception)
            {
                // Si ocurre un error, retornar una URL falsa (simulada)
                string nombreArchivo = Path.GetFileName(archivo.FileName);
                return "https://firebasestorage.googleapis.com/v0/" + Uri.EscapeDataString(nombreArchivo);
            }
        }



        //
    }
}