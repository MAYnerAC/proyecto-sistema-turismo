using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.IO;
using DotNetEnv;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para gestionar la subida y validación de archivos en Cloudinary.
    /// </summary>
    public class CloudinaryStorageService
    {

        private readonly Cloudinary _cloudinary;

        // Constructor del objeto Cloudinary con las credenciales
        public CloudinaryStorageService()
        {
            //Env.Load();
            //Env.TraversePath().Load();
            //Env.Load(@"C:\Users\OVALTECH\Downloads\envdata\.env");
            Env.Load(@"C:\WorkSpace\proyecto-sistema-turismo\ProyectoSistemaTurismo\ProyectoSistemaTurismo\.env");

            var cloudinaryUrl = Env.GetString("CLOUDINARY_URL");
            var account = new Account(cloudinaryUrl);
            Debug.WriteLine($"Cloudinary URL: {cloudinaryUrl}");
            Debug.WriteLine($"Cloudinary URL: {cloudinaryUrl}");
            Debug.WriteLine($"Cloudinary URL: {account}");

            var texto1 = Env.GetString("MY_TEXT_VARIABLE");
            Debug.WriteLine($"Texto: {texto1}");

            _cloudinary = new Cloudinary(account);
        }

        /// <summary>
        /// Sube un archivo al directorio "turismo_images" en Cloudinary.
        /// </summary>
        /// <param name="archivo">Archivo recibido desde el formulario web</param>
        /// <returns>URL del archivo subido o URL simulada en caso de error</returns>
        public virtual async Task<string> SubirArchivo(HttpPostedFileBase archivo)
        {
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(archivo.FileName, archivo.InputStream), // El archivo a subir
                    Folder = "turismo_images", // Directorio en Cloudinary
                };

                Debug.WriteLine($"Upload Params: Folder={uploadParams.Folder}, File={uploadParams.File.FileName}");//


                // Subir el archivo a Cloudinary
                //var uploadResult = await Task.Run(() => _cloudinary.Upload(uploadParams));
                var uploadResult = _cloudinary.Upload(uploadParams);//////////

                //var uploadResult = await _cloudinary.Upload(uploadParams);/////////////////////

                if (uploadResult != null)
                {
                    return uploadResult.SecureUrl.ToString();
                }
                else
                {
                    throw new Exception("Upload failed. The result is null.");
                }

                // Retornar la URL segura del archivo subido
                return uploadResult.SecureUrl.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during file upload: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Retornar una URL falsa (simulación)
                string nombreArchivo = Path.GetFileName(archivo.FileName);
                return "https://res.cloudinary.com/dugkds0b7/image/upload/v1/turismo_images/" + Uri.EscapeDataString(nombreArchivo);
            }
        }



        //
    }
}