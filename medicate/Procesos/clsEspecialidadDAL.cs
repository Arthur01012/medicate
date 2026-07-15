using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;

namespace MedicDate.CapaDatos
{
    public class clsEspecialidadDAL
    {
        public static DataTable ObtenerTodos()
        {
            string consulta = "SELECT id_especialidad, nombre_especialidad FROM especialidad ORDER BY nombre_especialidad";
            return clsConexion.EjecutarConsulta(consulta);
        }

        public static clsEspecialidad ObtenerPorId(int id)
        {
            string consulta = "SELECT * FROM especialidad WHERE id_especialidad = @id";
            MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];
                return new clsEspecialidad
                {
                    id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                    nombre_especialidad = row["nombre_especialidad"].ToString(),
                    descripcion = row["descripcion"] == DBNull.Value ? null : row["descripcion"].ToString()
                };
            }
            return null;
        }
    }
}