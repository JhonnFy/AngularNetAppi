using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                        while (runReadSql.Read())
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

        public bool CreateEstudiante(ModeloEstudiante nuevoEstudiante)
        {
            try
            {
                using var db = conexion.ObtenerConexion();
                db.Open();

                using (var checkSql = new SqlCommand("SELECT 1 FROM Estudiante WHERE id = @id", db))
                {
                    checkSql.Parameters.AddWithValue("@id", nuevoEstudiante.id);
                    if (checkSql.ExecuteScalar() != null)
                    {
                        Debug.WriteLine("[****].[INFO].[CapaDatos].[CreateEstudiante].[Estudiante ya registrado]");
                        return false;
                    }

                }

                string @create =
                    "INSERT INTO Estudiante " +
                    "(id, nombre) " +
                    "VALUES " +
                    "(@id,@nombre)";

                using (SqlCommand createSql = new SqlCommand(create, db))
                {
                    createSql.Parameters.AddWithValue("@id", nuevoEstudiante.id);
                    createSql.Parameters.AddWithValue("@nombre", nuevoEstudiante.nombre ?? (object)DBNull.Value);

                    int filasAfectadas = createSql.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[CreateEstudiante]");
                throw new Exception("[ERROR].[CapaDatos].[CreateEstudiante] " + e.Message);
            }
        }

        public bool CreateProfesor(ModeloProfesor nuevoProfesor)
        {
            try
            {
                using var db = conexion.ObtenerConexion();
                db.Open();

                using (var checkSql = new SqlCommand("SELECT 1 FROM Profesor WHERE id = @id", db))
                {
                    checkSql.Parameters.AddWithValue("@id", nuevoProfesor.id);
                    if (checkSql.ExecuteScalar() != null)
                    {
                        Debug.WriteLine("[****].[INFO].[CapaDatos].[CreateProfesor].[Profesor ya registrado]");
                        return false;
                    }
                }

                string @create =
                     "INSERT INTO Profesor " +
                     "(id, nombre) " +
                     "VALUES " +
                    "(@id,@nombre)";

                using (SqlCommand createSql = new SqlCommand(create, db))
                {
                    createSql.Parameters.AddWithValue("@id", nuevoProfesor.id);
                    createSql.Parameters.AddWithValue("@nombre", nuevoProfesor.nombre ?? (object)DBNull.Value);

                    int filasAfectadas = createSql.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[CreateProfesor]");
                throw new Exception("[ERROR].[CapaDatos].[CreateProfesor] " + e.Message);
            }
        }

        public bool CreateNota(ModeloNota nuevaNota)
        {
            try
            {
                using var db = conexion.ObtenerConexion();
                db.Open();

                using (var checkSql = new SqlCommand("SELECT 1 FROM Nota WHERE id = @id", db))
                {
                    checkSql.Parameters.AddWithValue("@id", nuevaNota.id);
                    if (checkSql.ExecuteScalar() != null)
                    {
                        Debug.WriteLine("[****].[INFO].[CapaDatos].[CreateNota].[Nota ya registrada]");
                        return false;
                    }
                }

                string @create =
                    "INSERT INTO  Nota " +
                    "(id,nombre,idProfesor,idEstudiante,valor) " +
                    "VALUES " +
                    "(@id,@nombre,@idProfesor,@idEstudiante,@valor)";


                using (SqlCommand createSql = new SqlCommand(create, db))
                {
                    createSql.Parameters.AddWithValue("@id", nuevaNota.id);
                    createSql.Parameters.AddWithValue("@nombre", nuevaNota.nombre);
                    createSql.Parameters.AddWithValue("@idProfesor", nuevaNota.idProfesor);
                    createSql.Parameters.AddWithValue("@idEstudiante", nuevaNota.idEstudiante);
                    createSql.Parameters.AddWithValue("@valor", nuevaNota.valor);

                    int filasAfectadas = createSql.ExecuteNonQuery();
                    return filasAfectadas > 0;

                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[CreateNota]");
                throw new Exception("[ERROR].[CapaDatos].[CreateNota] " + e.Message);
            }
        }

        public bool UpdateEstudiante(ModeloEstudiante updateEstudiante)
        {
            try
            {
                using var db = conexion.ObtenerConexion();
                db.Open();

                string @update =
                    "UPDATE Estudiante " +
                    "SET " +
                    "nombre = @nombre " +
                    "WHERE id = @id ";

                using (SqlCommand updateSql = new SqlCommand(update, db))
                {
                    updateSql.Parameters.AddWithValue("@nombre", updateEstudiante.nombre);
                    updateSql.Parameters.AddWithValue("@id", updateEstudiante.id);

                    int filasAfectadas = updateSql.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[Update Estudinate] " + e.Message);
                throw new Exception("ERROR [CapaDatos].[Update Estudinate] " + e.Message);
            }
        }

        public bool UpdateProfesor(ModeloProfesor updateProfesor)
        {
            try
            {
                using var db = conexion.ObtenerConexion();
                db.Open();

                string @update =
                    "UPDATE Profesor " +
                    "SET " +
                    "nombre = @nombre " +
                    "WHERE id = @id ";

                using (SqlCommand updateSql = new SqlCommand(update, db))
                {
                    updateSql.Parameters.AddWithValue("@nombre", updateProfesor.nombre);
                    updateSql.Parameters.AddWithValue("@id", updateProfesor.id);

                    int filasAfectadas = updateSql.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[Update Profesor] " + e.Message);
                throw new Exception("ERROR [CapaDatos].[Update Profesor] " + e.Message);
            }
        }

        public bool UpdateNotas(ModeloNota updNotas)
        {
            try
            {
                using var db = conexion.ObtenerConexion();
                db.Open();

                string @update =
                    "UPDATE Nota " +
                    "SET " +
                    "nombre = @nombre, " +
                    "valor = @valor " +
                    "WHERE id = @id ";

                using (SqlCommand updateSql = new SqlCommand(update, db))
                {
                    updateSql.Parameters.AddWithValue("@nombre", updNotas.nombre);
                    updateSql.Parameters.AddWithValue("@id", updNotas.id);
                    updateSql.Parameters.AddWithValue("@valor", updNotas.valor);

                    int filasAfectadas = updateSql.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[Update Notas] " + e.Message);
                throw new Exception("ERROR [CapaDatos].[Update Notas] " + e.Message);
            }
        }

    }
}
