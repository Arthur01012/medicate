using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;

namespace MedicDate.CapaDatos
{
    public class clsAsistenteDAL
    {
        public static bool Insertar(clsAsistente asistente)
        {
            string consulta = @"INSERT INTO ASISTENTE (id_empleado, turno)
                               VALUES (@id_empleado, @turno)";

            MySqlParameter[] parametros = {
                new MySqlParameter("@id_empleado", asistente.id_empleado),
                new MySqlParameter("@turno", string.IsNullOrEmpty(asistente.turno) ? DBNull.Value : (object)asistente.turno)
            };

            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }
    }
}
