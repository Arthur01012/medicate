using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MedicDate.CapaDatos
{
    public class clsConexion
    {
        private static readonly string cadenaConexion = ObtenerCadenaConexion();

        private static string ObtenerCadenaConexion()
        {
            try
            {
                string? fromConfig = ConfigurationManager.ConnectionStrings["MedicDateDB"]?.ConnectionString;
                if (!string.IsNullOrWhiteSpace(fromConfig))
                {
                    return fromConfig;
                }

                string? fromEnvironment = Environment.GetEnvironmentVariable("MEDICDATE_DB_CONNECTION");
                if (!string.IsNullOrWhiteSpace(fromEnvironment))
                {
                    return fromEnvironment;
                }
            }
            catch
            {
            }

            return "Server=localhost;Database=medicdate_db;Uid=root;Pwd=";
        }

        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        public static DataTable EjecutarConsulta(string consulta, MySqlParameter[] parametros = null, MySqlTransaction? transaccion = null)
        {
            MySqlConnection conexion = transaccion?.Connection ?? ObtenerConexion();
            bool cerrarConexion = transaccion == null;
            try
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
            finally
            {
                if (cerrarConexion)
                {
                    conexion.Dispose();
                }
            }
        }

        public static int EjecutarNonQuery(string consulta, MySqlParameter[] parametros = null, MySqlTransaction? transaccion = null)
        {
            MySqlConnection conexion = transaccion?.Connection ?? ObtenerConexion();
            bool cerrarConexion = transaccion == null;
            try
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    return comando.ExecuteNonQuery();
                }
            }
            finally
            {
                if (cerrarConexion)
                {
                    conexion.Dispose();
                }
            }
        }

        public static object EjecutarScalar(string consulta, MySqlParameter[] parametros = null, MySqlTransaction? transaccion = null)
        {
            MySqlConnection conexion = transaccion?.Connection ?? ObtenerConexion();
            bool cerrarConexion = transaccion == null;
            try
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    return comando.ExecuteScalar();
                }
            }
            finally
            {
                if (cerrarConexion)
                {
                    conexion.Dispose();
                }
            }
        }
    }
}