using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ProyectoSistemaTurismo.IntegrationTests.Helpers
{
    /// <summary>
    /// Proporciona métodos auxiliares para inicializar y limpiar la base de datos de pruebas.
    /// </summary>
    public static class PruebaDbHelper
    {

        /// <summary>
        /// Inicializa la base de datos de pruebas ejecutando los scripts DDL y DML.
        /// Borra las tablas existentes y recrea la estructura y datos requeridos para las pruebas de integración.
        /// </summary>
        public static void InicializarBD()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ModeloSistema"].ConnectionString;

            // Calcula la ruta absoluta de los scripts para evitar errores de ubicación
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string scriptsDir = Path.Combine(baseDir, "Scripts");
            string ddlPath = Path.Combine(scriptsDir, "DDL-dbSistemaTurismo-Tablas.sql");
            string dmlPath = Path.Combine(scriptsDir, "DML-dbSistemaTurismo-Registros.sql");

            // Si los archivos no existen, lanza una excepción descriptiva
            if (!File.Exists(ddlPath))
                throw new FileNotFoundException($"No se encuentra el script DDL en: {ddlPath}");
            if (!File.Exists(dmlPath))
                throw new FileNotFoundException($"No se encuentra el script DML en: {dmlPath}");

            // Lee los scripts DDL (estructura) y DML (datos)
            string ddl = File.ReadAllText(ddlPath);
            string dml = File.ReadAllText(dmlPath);

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Ejecuta script DDL
                using (var cmd = new SqlCommand(ddl, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Ejecuta script DML
                using (var cmd = new SqlCommand(dml, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //
    }
}
