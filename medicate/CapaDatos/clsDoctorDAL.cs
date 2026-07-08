using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;

namespace MedicDate.CapaDatos
{
    public class clsDoctorDAL
    {
        public static bool Insertar(clsDoctor doctor)
        {
            string consulta = @"INSERT INTO DOCTOR (id_empleado, cedula_profesional, especialidad_principal, consultorio)
                               VALUES (@id_empleado, @cedula, @especialidad, @consultorio)";

            MySqlParameter[] parametros = {
                new MySqlParameter("@id_empleado", doctor.id_empleado),
                new MySqlParameter("@cedula", doctor.cedula_profesional),
                new MySqlParameter("@especialidad", doctor.especialidad_principal.HasValue ? (object)doctor.especialidad_principal.Value : DBNull.Value),
                new MySqlParameter("@consultorio", string.IsNullOrEmpty(doctor.consultorio) ? DBNull.Value : (object)doctor.consultorio)
            };

            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }

        public static clsDoctor ObtenerPorId(int id)
        {
            string consulta = @"SELECT e.*, d.cedula_profesional, d.especialidad_principal, d.consultorio,
                               esp.nombre_especialidad
                               FROM EMPLEADO e
                               INNER JOIN DOCTOR d ON e.id_empleado = d.id_empleado
                               LEFT JOIN ESPECIALIDAD esp ON d.especialidad_principal = esp.id_especialidad
                               WHERE e.id_empleado = @id";

            MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];
                return new clsDoctor
                {
                    id_empleado = Convert.ToInt32(row["id_empleado"]),
                    nombre = row["nombre"].ToString(),
                    apellido_paterno = row["apellido_paterno"].ToString(),
                    apellido_materno = row["apellido_materno"] == DBNull.Value ? null : row["apellido_materno"].ToString(),
                    fecha_nacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                    email = row["email"].ToString(),
                    telefono_principal = row["telefono_principal"] == DBNull.Value ? null : row["telefono_principal"].ToString(),
                    telefono_secundario = row["telefono_secundario"] == DBNull.Value ? null : row["telefono_secundario"].ToString(),
                    tipo_empleado = row["tipo_empleado"].ToString(),
                    fecha_contratacion = Convert.ToDateTime(row["fecha_contratacion"]),
                    estado = Convert.ToBoolean(row["estado"]),
                    id_usuario = row["id_usuario"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["id_usuario"]),
                    cedula_profesional = row["cedula_profesional"].ToString(),
                    especialidad_principal = row["especialidad_principal"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["especialidad_principal"]),
                    nombre_especialidad = row["nombre_especialidad"] == DBNull.Value ? null : row["nombre_especialidad"].ToString(),
                    consultorio = row["consultorio"] == DBNull.Value ? null : row["consultorio"].ToString()
                };
            }
            return null;
        }

        public static DataTable ObtenerTodos()
        {
            string consulta = @"SELECT e.id_empleado, 
                               CONCAT(e.nombre, ' ', e.apellido_paterno, ' ', IFNULL(e.apellido_materno, '')) as nombre_completo,
                               e.email, e.telefono_principal, d.cedula_profesional, d.consultorio,
                               esp.nombre_especialidad
                               FROM EMPLEADO e
                               INNER JOIN DOCTOR d ON e.id_empleado = d.id_empleado
                               LEFT JOIN ESPECIALIDAD esp ON d.especialidad_principal = esp.id_especialidad
                               WHERE e.estado = 1
                               ORDER BY e.apellido_paterno, e.nombre";
            return clsConexion.EjecutarConsulta(consulta);
        }
    }
}