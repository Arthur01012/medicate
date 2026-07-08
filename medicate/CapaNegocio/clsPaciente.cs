using System;

namespace MedicDate.CapaNegocio
{
    public class clsPaciente
    {
        public int id_paciente { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string telefono_principal { get; set; }
        public string telefono_secundario { get; set; }
        public string email { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string numero { get; set; }
        public string localidad { get; set; }
        public int? id_municipio { get; set; }
        public string nombre_municipio { get; set; } // Para mostrar en la interfaz
        public DateTime fecha_registro { get; set; }
        public string alergias { get; set; }
        public string notas_medicas { get; set; }

        public string NombreCompleto
        {
            get { return $"{nombre} {apellido_paterno} {apellido_materno}".Trim(); }
        }

        public int Edad
        {
            get
            {
                int edad = DateTime.Today.Year - fecha_nacimiento.Year;
                if (fecha_nacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
                return edad;
            }
        }
    }
}