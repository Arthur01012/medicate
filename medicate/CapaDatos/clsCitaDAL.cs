using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;

namespace MedicDate.CapaDatos
{
    public class clsCitaDAL
    {
        public static int Insertar(clsCita cita, MySqlTransaction? transaccion = null)
        {
            string consulta = @"INSERT INTO CITA 
                               (id_paciente, id_doctor, fecha, hora, duracion, motivo, estado, 
                                costo, notas_internas, id_registrado_por)
                               VALUES 
                               (@id_paciente, @id_doctor, @fecha, @hora, @duracion, @motivo, @estado,
                                @costo, @notas_internas, @id_registrado_por);
                               SELECT LAST_INSERT_ID();";

            MySqlParameter[] parametros = {
                new MySqlParameter("@id_paciente", cita.id_paciente),
                new MySqlParameter("@id_doctor", cita.id_doctor),
                new MySqlParameter("@fecha", cita.fecha),
                new MySqlParameter("@hora", cita.hora),
                new MySqlParameter("@duracion", cita.duracion),
                new MySqlParameter("@motivo", (object)cita.motivo ?? DBNull.Value),
                new MySqlParameter("@estado", cita.estado),
                new MySqlParameter("@costo", (object)cita.costo ?? DBNull.Value),
                new MySqlParameter("@notas_internas", (object)cita.notas_internas ?? DBNull.Value),
                new MySqlParameter("@id_registrado_por", (object)cita.id_registrado_por ?? DBNull.Value)
            };

            object resultado = clsConexion.EjecutarScalar(consulta, parametros, transaccion);
            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }

        public static bool Actualizar(clsCita cita)
        {
            string consulta = @"UPDATE CITA 
                               SET id_paciente = @id_paciente, id_doctor = @id_doctor,
                                   fecha = @fecha, hora = @hora, duracion = @duracion,
                                   motivo = @motivo, estado = @estado, costo = @costo,
                                   notas_internas = @notas_internas
                               WHERE id_cita = @id_cita";

            MySqlParameter[] parametros = {
                new MySqlParameter("@id_paciente", cita.id_paciente),
                new MySqlParameter("@id_doctor", cita.id_doctor),
                new MySqlParameter("@fecha", cita.fecha),
                new MySqlParameter("@hora", cita.hora),
                new MySqlParameter("@duracion", cita.duracion),
                new MySqlParameter("@motivo", (object)cita.motivo ?? DBNull.Value),
                new MySqlParameter("@estado", cita.estado),
                new MySqlParameter("@costo", (object)cita.costo ?? DBNull.Value),
                new MySqlParameter("@notas_internas", (object)cita.notas_internas ?? DBNull.Value),
                new MySqlParameter("@id_cita", cita.id_cita)
            };

            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }

        public static bool Cancelar(int id_cita)
        {
            string consulta = "UPDATE CITA SET estado = 'Cancelada' WHERE id_cita = @id";
            MySqlParameter[] parametros = { new MySqlParameter("@id", id_cita) };
            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }

        public static bool CambiarEstado(int id_cita, string nuevoEstado)
        {
            string consulta = "UPDATE CITA SET estado = @estado WHERE id_cita = @id";
            MySqlParameter[] parametros = {
                new MySqlParameter("@estado", nuevoEstado),
                new MySqlParameter("@id", id_cita)
            };
            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }

        public static clsCita ObtenerPorId(int id_cita)
        {
            string consulta = @"SELECT c.*, 
                               p.nombre + ' ' + p.apellido_paterno + ' ' + IFNULL(p.apellido_materno, '') as nombre_paciente,
                               e.nombre + ' ' + e.apellido_paterno + ' ' + IFNULL(e.apellido_materno, '') as nombre_doctor
                               FROM CITA c
                               INNER JOIN PACIENTE p ON c.id_paciente = p.id_paciente
                               INNER JOIN EMPLEADO e ON c.id_doctor = e.id_empleado
                               WHERE c.id_cita = @id";

            MySqlParameter[] parametros = { new MySqlParameter("@id", id_cita) };
            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];
                return new clsCita
                {
                    id_cita = Convert.ToInt32(row["id_cita"]),
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    nombre_paciente = row["nombre_paciente"].ToString(),
                    id_doctor = Convert.ToInt32(row["id_doctor"]),
                    nombre_doctor = row["nombre_doctor"].ToString(),
                    fecha = Convert.ToDateTime(row["fecha"]),
                    hora = TimeSpan.Parse(row["hora"].ToString()),
                    duracion = Convert.ToInt32(row["duracion"]),
                    motivo = row["motivo"]?.ToString(),
                    estado = row["estado"].ToString(),
                    costo = row["costo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["costo"]),
                    notas_internas = row["notas_internas"]?.ToString(),
                    id_registrado_por = row["id_registrado_por"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["id_registrado_por"]),
                };
            }
            return null;
        }

        public static DataTable ObtenerCitasPorDoctor(int id_doctor, DateTime fecha)
        {
            string consulta = @"SELECT c.*, 
                               p.nombre + ' ' + p.apellido_paterno + ' ' + IFNULL(p.apellido_materno, '') as paciente,
                               p.telefono_principal
                               FROM CITA c
                               INNER JOIN PACIENTE p ON c.id_paciente = p.id_paciente
                               WHERE c.id_doctor = @id_doctor AND c.fecha = @fecha
                               AND c.estado != 'Cancelada'
                               ORDER BY c.hora";

            MySqlParameter[] parametros = {
                new MySqlParameter("@id_doctor", id_doctor),
                new MySqlParameter("@fecha", fecha)
            };
            return clsConexion.EjecutarConsulta(consulta, parametros);
        }

        public static DataTable ObtenerCitasPorFecha(DateTime fecha)
        {
            string consulta = @"SELECT c.*, 
                               p.nombre + ' ' + p.apellido_paterno + ' ' + IFNULL(p.apellido_materno, '') as paciente,
                               e.nombre + ' ' + e.apellido_paterno + ' ' + IFNULL(e.apellido_materno, '') as doctor,
                               p.telefono_principal
                               FROM CITA c
                               INNER JOIN PACIENTE p ON c.id_paciente = p.id_paciente
                               INNER JOIN EMPLEADO e ON c.id_doctor = e.id_empleado
                               WHERE c.fecha = @fecha
                               AND c.estado != 'Cancelada'
                               ORDER BY c.hora";

            MySqlParameter[] parametros = { new MySqlParameter("@fecha", fecha) };
            return clsConexion.EjecutarConsulta(consulta, parametros);
        }

        public static DataTable ObtenerCitasPorPaciente(int id_paciente)
        {
            string consulta = @"SELECT c.*, 
                               e.nombre + ' ' + e.apellido_paterno + ' ' + IFNULL(e.apellido_materno, '') as doctor
                               FROM CITA c
                               INNER JOIN EMPLEADO e ON c.id_doctor = e.id_empleado
                               WHERE c.id_paciente = @id_paciente
                               ORDER BY c.fecha DESC, c.hora DESC";

            MySqlParameter[] parametros = { new MySqlParameter("@id_paciente", id_paciente) };
            return clsConexion.EjecutarConsulta(consulta, parametros);
        }

        public static bool VerificarDisponibilidad(int id_doctor, DateTime fecha, TimeSpan hora, int duracion)
        {
            string consulta = @"SELECT COUNT(*) FROM CITA 
                               WHERE id_doctor = @id_doctor 
                               AND fecha = @fecha 
                               AND estado != 'Cancelada'
                               AND (
                                   (hora <= @hora AND DATE_ADD(hora, INTERVAL duracion MINUTE) > @hora)
                                   OR
                                   (@hora <= hora AND DATE_ADD(@hora, INTERVAL @duracion MINUTE) > hora)
                               )";

            MySqlParameter[] parametros = {
                new MySqlParameter("@id_doctor", id_doctor),
                new MySqlParameter("@fecha", fecha),
                new MySqlParameter("@hora", hora),
                new MySqlParameter("@duracion", duracion)
            };

            int count = Convert.ToInt32(clsConexion.EjecutarScalar(consulta, parametros));
            return count == 0;
        }
    }
}