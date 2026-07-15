using System;

namespace MedicDate.CapaNegocio
{
    public class clsEmpleado
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string curp { get; set; }
        public string email { get; set; }
        public string telefono_principal { get; set; }
        public string telefono_secundario { get; set; }
        public string tipo_empleado { get; set; } // 'administrador', 'asistente', 'doctor'
        public DateTime fecha_contratacion { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool estado { get; set; } = true;
        public int? id_usuario { get; set; }

        public string NombreCompleto
        {
            get { return $"{nombre} {apellido_paterno} {apellido_materno}".Trim(); }
        }
    }
}