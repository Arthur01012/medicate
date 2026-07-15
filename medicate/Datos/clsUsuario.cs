using System;

namespace MedicDate.CapaNegocio
{
    public class clsUsuario
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int id_rol { get; set; }
        public string nombre_rol { get; set; } // Para mostrar en la interfaz
        public DateTime? ultimo_acceso { get; set; }
        public bool activo { get; set; } = true;

        // Enum para los roles del sistema
        public enum Roles
        {
            Administrador = 1,
            Asistente = 2,
            Doctor = 3
        }

        public clsUsuario()
        {
            activo = true;
        }
    }
}