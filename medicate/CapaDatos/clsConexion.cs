using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MedicDate.CapaDatos
{
    public class clsConexion
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["MedicDateDB"].ConnectionString;

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

        public static DataTable EjecutarConsulta(string consulta, MySqlParameter[] parametros = null)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
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
        }

        public static int EjecutarNonQuery(string consulta, MySqlParameter[] parametros = null)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    return comando.ExecuteNonQuery();
                }
            }
        }

        public static object EjecutarScalar(string consulta, MySqlParameter[] parametros = null)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    return comando.ExecuteScalar();
                }
            }
        }
    }
}