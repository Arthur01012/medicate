using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;
using MedicDate.Helpers;

namespace MedicDate.CapaDatos
{
    public class clsUsuarioDAL
    {
        public static clsUsuario Autenticar(string usuario, string contrasena)
        {
            string contrasenaEncriptada = clsEncriptacion.EncriptarSHA256(contrasena);
            string consulta = @"SELECT u.*, r.nombre as nombre_rol 
                               FROM USUARIO u
                               INNER JOIN ROL r ON u.id_rol = r.id_rol
                               WHERE u.usuario = @usuario AND u.contrasena = @contrasena AND u.activo = 1";

            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario),
                new MySqlParameter("@contrasena", contrasenaEncriptada)
            };

            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);

            if (resultado.Rows.Count > 0)
            {
                clsUsuario user = new clsUsuario
                {
                    id_usuario = Convert.ToInt32(resultado.Rows[0]["id_usuario"]),
                    usuario = resultado.Rows[0]["usuario"].ToString(),
                    id_rol = Convert.ToInt32(resultado.Rows[0]["id_rol"]),
                    nombre_rol = resultado.Rows[0]["nombre_rol"].ToString(),
                    activo = Convert.ToBoolean(resultado.Rows[0]["activo"])
                };

                // Actualizar último acceso
                ActualizarUltimoAcceso(user.id_usuario);
                return user;
            }
            return null;
        }

        public static void ActualizarUltimoAcceso(int id_usuario)
        {
            string consulta = "UPDATE USUARIO SET ultimo_acceso = @fecha WHERE id_usuario = @id";
            MySqlParameter[] parametros = {
                new MySqlParameter("@fecha", DateTime.Now),
                new MySqlParameter("@id", id_usuario)
            };
            clsConexion.EjecutarNonQuery(consulta, parametros);
        }

        public static bool CrearUsuario(clsUsuario usuario)
        {
            string contrasenaEncriptada = clsEncriptacion.EncriptarSHA256(usuario.contrasena);
            string consulta = @"INSERT INTO USUARIO (usuario, contrasena, id_rol, activo) 
                               VALUES (@usuario, @contrasena, @id_rol, @activo);
                               SELECT LAST_INSERT_ID();";

            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario.usuario),
                new MySqlParameter("@contrasena", contrasenaEncriptada),
                new MySqlParameter("@id_rol", usuario.id_rol),
                new MySqlParameter("@activo", usuario.activo)
            };

            object resultado = clsConexion.EjecutarScalar(consulta, parametros);
            if (resultado != null)
            {
                usuario.id_usuario = Convert.ToInt32(resultado);
                return true;
            }
            return false;
        }

        public static bool ActualizarUsuario(clsUsuario usuario)
        {
            string consulta = @"UPDATE USUARIO 
                               SET usuario = @usuario, id_rol = @id_rol, activo = @activo
                               WHERE id_usuario = @id";

            if (!string.IsNullOrEmpty(usuario.contrasena))
            {
                consulta = @"UPDATE USUARIO 
                            SET usuario = @usuario, contrasena = @contrasena, id_rol = @id_rol, activo = @activo
                            WHERE id_usuario = @id";
            }

            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario.usuario),
                new MySqlParameter("@id_rol", usuario.id_rol),
                new MySqlParameter("@activo", usuario.activo),
                new MySqlParameter("@id", usuario.id_usuario)
            };

            if (!string.IsNullOrEmpty(usuario.contrasena))
            {
                string contrasenaEncriptada = clsEncriptacion.EncriptarSHA256(usuario.contrasena);
                Array.Resize(ref parametros, 5);
                parametros[4] = new MySqlParameter("@contrasena", contrasenaEncriptada);
            }

            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }

        public static bool EliminarUsuario(int id_usuario)
        {
            string consulta = "DELETE FROM USUARIO WHERE id_usuario = @id";
            MySqlParameter[] parametros = { new MySqlParameter("@id", id_usuario) };
            return clsConexion.EjecutarNonQuery(consulta, parametros) > 0;
        }

        public static DataTable ObtenerTodos()
        {
            string consulta = @"SELECT u.id_usuario, u.usuario, u.activo, r.nombre as rol, u.ultimo_acceso 
                               FROM USUARIO u
                               INNER JOIN ROL r ON u.id_rol = r.id_rol
                               ORDER BY u.id_usuario";
            return clsConexion.EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerRoles()
        {
            string consulta = "SELECT id_rol, nombre FROM ROL ORDER BY nombre";
            return clsConexion.EjecutarConsulta(consulta);
        }
    }
}