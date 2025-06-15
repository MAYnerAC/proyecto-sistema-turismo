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
            //var cloudinaryUrl = Env.GetString("CLOUDINARY_URL");
            //var account = new Account(cloudinaryUrl);
            string cloudName = Env.GetString("CLOUD_NAME");
            string apiKey = Env.GetString("API_KEY");
            string apiSecret = Env.GetString("API_SECRET");
            var account = new Account(cloudName, apiKey, apiSecret);

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

                // Subir el archivo a Cloudinary
                //var uploadResult = await Task.Run(() => _cloudinary.Upload(uploadParams));
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.SecureUrl.ToString();

            }
            catch (Exception)
            {
                //Debug.WriteLine($"Error: {ex.Message}");

                // Retornar una URL falsa (simulación)
                string nombreArchivo = Path.GetFileName(archivo.FileName);
                return "https://res.cloudinary.com/dugkds0b7/image/upload/v1/turismo_images/" + Uri.EscapeDataString(nombreArchivo);
            }
        }



        //
    }
}