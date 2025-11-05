using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Diagnostics;
namespace CapaDatos
{
    public class Conexion
    {
        private readonly string cadenaConexion;

        public Conexion()
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["CadenaSQL"];
                if (cs == null || string.IsNullOrEmpty(cs.ConnectionString))
                {
                    throw new Exception("No se encontró la cadena de conexión 'CadenaSQL' o está vacía.");
                    Debug.WriteLine("[****].[ERROR] [Capa Datos Conexion].[No se encontró la cadena de conexión 'CadenaSQL' o está vacía.]");

                    cadenaConexion = cs.ConnectionString;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("[****].[ERROR] [Capa Datos Conexion].[Cadenda Conexion] " + e.Message);
                throw new Exception("ERROR [Capa Datos Conexion].[Cadenda Conexion] " + e.Message);
            }
        }

        // Devuelve el estado y mensaje
        public (bool estado, string mensaje) ProbarConexion()
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {

                    conn.Open();
                    Debug.WriteLine("[****].[OK].[CapaDatos].[Conexion Exitosa]");
                    return (true, "Conexión exitosa a la base de datos.");
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("[****].[ERROR] [Capa Datos Conexion].[Cadenda Conexion]");
                return (false, $"ERROR [Capa Datos Conexion].[SQL] {ex.Number}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR] [Capa Datos Conexion].[Cadenda Conexion]");
                return (false, $"ERROR [Capa Datos Conexion].[SQL] {ex.Message}");
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
