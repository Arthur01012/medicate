using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;

namespace MedicDate.CapaDatos
{
    public class clsPacienteDAL
    {
        public static int Insertar(clsPaciente paciente, MySqlTransaction? transaccion = null)
        {
            string consulta = @"INSERT INTO paciente 
                               (nombre, apellido_paterno, apellido_materno, fecha_nacimiento, 
                                telefono_principal, telefono_secundario, email, calle, colonia, 
                                numero, localidad, id_municipio, alergias, notas_medicas)
                               VALUES 
                               (@nombre, @apellido_paterno, @apellido_materno, @fecha_nacimiento,
                                @telefono_principal, @telefono_secundario, @email, @calle, @colonia,
                                @numero, @localidad, @id_municipio, @alergias, @notas_medicas);
                               SELECT LAST_INSERT_ID();";  // ← CAMBIADO para MySQL

            MySqlParameter[] parametros = {  // ← CAMBIADO
                new MySqlParameter("@nombre", paciente.nombre),
                new MySqlParameter("@apellido_paterno", paciente.apellido_paterno),
                new MySqlParameter("@apellido_materno", (object)paciente.apellido_materno ?? DBNull.Value),
                new MySqlParameter("@fecha_nacimiento", paciente.fecha_nacimiento),
                new MySqlParameter("@telefono_principal", (object)paciente.telefono_principal ?? DBNull.Value),
                new MySqlParameter("@telefono_secundario", (object)paciente.telefono_secundario ?? DBNull.Value),
                new MySqlParameter("@email", (object)paciente.email ?? DBNull.Value),
                new MySqlParameter("@calle", (object)paciente.calle ?? DBNull.Value),
                new MySqlParameter("@colonia", (object)paciente.colonia ?? DBNull.Value),
                new MySqlParameter("@numero", (object)paciente.numero ?? DBNull.Value),
                new MySqlParameter("@localidad", (object)paciente.localidad ?? DBNull.Value),
                new MySqlParameter("@id_municipio", (object)paciente.id_municipio ?? DBNull.Value),
                new MySqlParameter("@alergias", (object)paciente.alergias ?? DBNull.Value),
                new MySqlParameter("@notas_medicas", (object)paciente.notas_medicas ?? DBNull.Value)
            };

            object resultado = clsConexion.EjecutarScalar(consulta, parametros, transaccion);
            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }
    }
}