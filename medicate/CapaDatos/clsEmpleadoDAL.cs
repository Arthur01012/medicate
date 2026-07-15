using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;

namespace MedicDate.CapaDatos
{
    public class clsEmpleadoDAL
    {
        public static int Insertar(clsEmpleado empleado, MySqlTransaction? transaccion = null)
        {
            string consulta = @"INSERT INTO empleado 
                               (nombre, apellido_paterno, apellido_materno, fecha_nacimiento, 
                                curp, email, telefono_principal, telefono_secundario, 
                                tipo_empleado, fecha_contratacion, estado, id_usuario)
                               VALUES 
                               (@nombre, @apellido_paterno, @apellido_materno, @fecha_nacimiento,
                                @curp, @email, @telefono_principal, @telefono_secundario,
                                @tipo_empleado, @fecha_contratacion, @estado, @id_usuario);
                               SELECT LAST_INSERT_ID();";

            MySqlParameter[] parametros = {
                new MySqlParameter("@nombre", empleado.nombre),
                new MySqlParameter("@apellido_paterno", empleado.apellido_paterno),
                new MySqlParameter("@apellido_materno", string.IsNullOrEmpty(empleado.apellido_materno) ? DBNull.Value : (object)empleado.apellido_materno),
                new MySqlParameter("@fecha_nacimiento", empleado.fecha_nacimiento),
                new MySqlParameter("@curp", string.IsNullOrEmpty(empleado.curp) ? DBNull.Value : (object)empleado.curp),
                new MySqlParameter("@email", empleado.email),
                new MySqlParameter("@telefono_principal", string.IsNullOrEmpty(empleado.telefono_principal) ? DBNull.Value : (object)empleado.telefono_principal),
                new MySqlParameter("@telefono_secundario", string.IsNullOrEmpty(empleado.telefono_secundario) ? DBNull.Value : (object)empleado.telefono_secundario),
                new MySqlParameter("@tipo_empleado", empleado.tipo_empleado),
                new MySqlParameter("@fecha_contratacion", empleado.fecha_contratacion),
                new MySqlParameter("@estado", empleado.estado ? 1 : 0),
                new MySqlParameter("@id_usuario", empleado.id_usuario.HasValue ? (object)empleado.id_usuario.Value : DBNull.Value)
            };

            object resultado = clsConexion.EjecutarScalar(consulta, parametros, transaccion);
            return resultado == DBNull.Value ? 0 : Convert.ToInt32(resultado);
        }

        public static clsEmpleado ObtenerPorId(int id)
        {
            string consulta = "SELECT * FROM empleado WHERE id_empleado = @id";
            MySqlParameter[] parametros = { new MySqlParameter("@id", id) };
            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];
                return new clsEmpleado
                {
                    id_empleado = Convert.ToInt32(row["id_empleado"]),
                    nombre = row["nombre"].ToString(),
                    apellido_paterno = row["apellido_paterno"].ToString(),
                    apellido_materno = row["apellido_materno"] == DBNull.Value ? null : row["apellido_materno"].ToString(),
                    fecha_nacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                    curp = row["curp"] == DBNull.Value ? null : row["curp"].ToString(),
                    email = row["email"].ToString(),
                    telefono_principal = row["telefono_principal"] == DBNull.Value ? null : row["telefono_principal"].ToString(),
                    telefono_secundario = row["telefono_secundario"] == DBNull.Value ? null : row["telefono_secundario"].ToString(),
                    tipo_empleado = row["tipo_empleado"].ToString(),
                    fecha_contratacion = Convert.ToDateTime(row["fecha_contratacion"]),
                    estado = Convert.ToBoolean(row["estado"]),
                    id_usuario = row["id_usuario"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["id_usuario"])
                };
            }
            return null;
        }
    }
}