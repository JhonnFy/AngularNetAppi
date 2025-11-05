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
                                id = runReadSql.GetInt32(1),
                                nombre = runReadSql.GetString(2),
                            };
                         listaReadEstudiante.Add(modelo);       
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudAngularNetAppi].[ReadEstudiante]");
                throw new Exception("ERROR [Capa CrudAngularNetAppi].[ReadEstudiante] " + ex.Message);
            }
            return listaReadEstudiante;
        }
               
        public List<ModeloEstudiante> ReadEstudianteId(int id)
        {
            var listaReadEstudiante = new List<ModeloEstudiante>();
            try
            {
                using (var db = conexion.ObtenerConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM Estudiante " +
                        "WHERE id = @id";

                    using (SqlCommand readSql = new SqlCommand(read, db))
                    {
                        readSql.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader runReasSql = readSql.ExecuteReader())
                        {

                            if (runReasSql.Read())
                            {
                                var modelo = new ModeloEstudiante
                                {
                                    idIdentity = runReasSql.GetInt32(0),
                                    id = runReasSql.GetInt32(1),
                                    nombre = runReasSql.GetString(2),
                                };
                                listaReadEstudiante.Add(modelo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudAngularNetAppi].[ReadEstudianteId]");
                throw new Exception("ERROR [Capa CrudAngularNetAppi].[ReadEstudianteId] " + ex.Message);
            }
            return listaReadEstudiante;
        }

        public List<ModeloProfesor> ReadProfesor()
        {
            var listaReadProfesor = new List<ModeloProfesor>();
            try
            {
                using (var db = conexion.ObtenerConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM Profesor";

                    using (SqlCommand readSql = new SqlCommand(read, db))
                    using (SqlDataReader runReadSql = readSql.ExecuteReader())
                    {
                        while (runReadSql.Read())
                        {
                            var modelo = new ModeloProfesor
                            {
                                idIdentity = runReadSql.GetInt32(0),
                                id = runReadSql.GetInt32(1),
                                nombre = runReadSql.GetString(2),
                            };
                            listaReadProfesor.Add(modelo);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudAngularNetAppi].[ReadProfesor]");
                throw new Exception("ERROR [Capa CrudAngularNetAppi].[ReadProfesor] " + ex.Message);
            }
            return listaReadProfesor;
        }

        public List<ModeloProfesor> ReadProfesorId(int id)
        {
            var listaReadProfesor = new List<ModeloProfesor>();
            try
            {
                using (var db = conexion.ObtenerConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM Profesor " +
                        "WHERE id = @id";

                    using (SqlCommand readSql = new SqlCommand(read, db))
                    {
                        readSql.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader runReasSql = readSql.ExecuteReader())
                        {

                            if (runReasSql.Read())
                            {
                                var modelo = new ModeloProfesor
                                {
                                    idIdentity = runReasSql.GetInt32(0),
                                    id = runReasSql.GetInt32(1),
                                    nombre = runReasSql.GetString(2),
                                };
                                listaReadProfesor.Add(modelo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudAngularNetAppi].[ReadProfesorId]");
                throw new Exception("ERROR [Capa CrudAngularNetAppi].[ReadProfesorId] " + ex.Message);
            }
            return listaReadProfesor;
        }

        public List<ModeloNota> ReadNota()
        {
            var listaReadNotas = new List<ModeloNota>();
            try
            {
                using (var db = conexion.ObtenerConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM Nota";

                    using (SqlCommand readSql = new SqlCommand(read, db))
                    using (SqlDataReader runReadSql = readSql.ExecuteReader())
                    {
                        while (runReadSql.Read())
                        {
                            var modelo = new ModeloNota
                            {
                                idIdentity = runReadSql.GetInt32(0),
                                id = runReadSql.GetInt32(1),
                                nombre = runReadSql.GetString(2),
                                idProfesor = runReadSql.GetInt32(3),
                                idEstudiante = runReadSql.GetInt32(4),
                                valor = runReadSql.GetDecimal(5)
                            };
                            listaReadNotas.Add(modelo);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudAngularNetAppi].[ReadNota]");
                throw new Exception("ERROR [Capa CrudAngularNetAppi].[ReadNota] " + ex.Message);
            }
            return listaReadNotas;
        }

        public List<ModeloNota> ReadNotaId(int id)
        {
            var listaReadNotas = new List<ModeloNota>();
            try
            {
                using (var db = conexion.ObtenerConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM Nota " +
                        "WHERE id = @id";

                    using (SqlCommand readSql = new SqlCommand(read, db))
                    {
                        readSql.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader runReasSql = readSql.ExecuteReader())
                        {

                            if (runReasSql.Read())
                            {
                                var modelo = new ModeloNota
                                {
                                    idIdentity = runReasSql.GetInt32(0),
                                    id = runReasSql.GetInt32(1),
                                    nombre = runReasSql.GetString(2),
                                    idProfesor = runReasSql.GetInt32(3),
                                    idEstudiante = runReasSql.GetInt32(4),
                                    valor = runReasSql.GetDecimal(5)
                                };
                                listaReadNotas.Add(modelo);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[Capa CrudAngularNetAppi].[ReadNotaId]");
                throw new Exception("ERROR [Capa CrudAngularNetAppi].[ReadNotaId] " + ex.Message);
            }
            return listaReadNotas;
        }

    }
}
