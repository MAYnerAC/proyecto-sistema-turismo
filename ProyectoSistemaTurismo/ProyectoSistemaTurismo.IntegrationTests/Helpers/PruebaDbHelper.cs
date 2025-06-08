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

            // Lee los scripts DDL (estructura) y DML (datos)
            string ddl = File.ReadAllText(@"Scripts\DDL-dbSistemaTurismo-Tablas.sql");
            string dml = File.ReadAllText(@"Scripts\DML-dbSistemaTurismo-Registros.sql");

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
