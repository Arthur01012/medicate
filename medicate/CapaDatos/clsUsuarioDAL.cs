using System;
using System.Data;
using MySql.Data.MySqlClient;
using MedicDate.CapaNegocio;
using MedicDate.Helpers;
using medicate.CapaDatos;

namespace MedicDate.CapaDatos
{
    public class clsUsuarioDAL
    {
        public static bool UsuarioExiste(string usuario)
        {
            string consulta = "SELECT COUNT(*) FROM USUARIO WHERE usuario = @usuario";
            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario)
            };

            object resultado = clsConexion.EjecutarScalar(consulta, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        public static bool UsuarioActivo(string usuario)
        {
            string consulta = "SELECT activo FROM USUARIO WHERE usuario = @usuario";
            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario)
            };

            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);
            if (resultado.Rows.Count > 0)
            {
                return Convert.ToBoolean(resultado.Rows[0]["activo"]);
            }
            return false;
        }

        public static clsUsuario Autenticar(string usuario, string contrasena)
        {
            string contrasenaEncriptada = clsEncriptacion.EncriptarSHA256(contrasena);
            string consulta = @"SELECT u.*, r.nombre as nombre_rol 
                               FROM USUARIO u
                               INNER JOIN ROL r ON u.id_rol = r.id_rol
                               WHERE u.usuario = @usuario AND u.activo = 1";

            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario)
            };

            DataTable resultado = clsConexion.EjecutarConsulta(consulta, parametros);

            if (resultado.Rows.Count == 0)
            {
                return null;
            }

            DataRow fila = resultado.Rows[0];
            string contrasenaAlmacenada = fila["contrasena"].ToString();
            bool passwordValido = string.Equals(contrasenaAlmacenada, contrasenaEncriptada, StringComparison.OrdinalIgnoreCase)
                                   || string.Equals(contrasenaAlmacenada, contrasena, StringComparison.Ordinal);

            if (!passwordValido)
            {
                return null;
            }

            clsUsuario user = new clsUsuario
            {
                id_usuario = Convert.ToInt32(fila["id_usuario"]),
                usuario = fila["usuario"].ToString(),
                id_rol = Convert.ToInt32(fila["id_rol"]),
                nombre_rol = fila["nombre_rol"].ToString(),
                activo = Convert.ToBoolean(fila["activo"])
            };

            if (!string.Equals(contrasenaAlmacenada, contrasenaEncriptada, StringComparison.OrdinalIgnoreCase))
            {
                // Actualizar contraseña almacenada en texto plano a su hash SHA256
                string actualizacion = "UPDATE USUARIO SET contrasena = @contrasena WHERE id_usuario = @id";
                MySqlParameter[] parametrosActualizacion = {
                    new MySqlParameter("@contrasena", contrasenaEncriptada),
                    new MySqlParameter("@id", user.id_usuario)
                };
                clsConexion.EjecutarNonQuery(actualizacion, parametrosActualizacion);
            }

            ActualizarUltimoAcceso(user.id_usuario);
            return user;
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
            if (resultado != null && resultado != DBNull.Value)
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

            MySqlParameter[] parametros = {
                new MySqlParameter("@usuario", usuario.usuario),
                new MySqlParameter("@id_rol", usuario.id_rol),
                new MySqlParameter("@activo", usuario.activo),
                new MySqlParameter("@id", usuario.id_usuario)
            };

            if (!string.IsNullOrEmpty(usuario.contrasena))
            {
                string contrasenaEncriptada = clsEncriptacion.EncriptarSHA256(usuario.contrasena);
                consulta = @"UPDATE USUARIO 
                            SET usuario = @usuario, contrasena = @contrasena, id_rol = @id_rol, activo = @activo
                            WHERE id_usuario = @id";
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