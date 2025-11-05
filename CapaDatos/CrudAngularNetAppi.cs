using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class CrudAngularNetAppi
    {
        private Conexion conexion = new Conexion();

        public List<ModeloEstudiante> ReadEstudiante()
        {
            var listaReadEstudiante = new List<ModeloEstudiante>();
            try
            {
                using (var db = conexion.ObtenerConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM Estudiante";

                    using (SqlCommand readSql = new SqlCommand(read, db))
                    using (SqlDataReader runReadSql = readSql.ExecuteReader())
                    {
                        while(runReadSql.Read())
                        {
                            var modelo = new ModeloEstudiante
                            {
                                idIdentity = runReadSql.GetInt32(0),
                                id = runReadSql.GetInt64(1),
                                nombre = runReadSql.GetString(2),
                            };
                         listaReadEstudiante.Add(modelo);       
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudCodigoDeBarrasOrigen].[ReadEstudiante]");
                throw new Exception("ERROR [Capa CrudCodigoDeBarrasOrigen].[ReadEstudiante] " + ex.Message);
            }
            return listaReadEstudiante;
        }


    }
}
