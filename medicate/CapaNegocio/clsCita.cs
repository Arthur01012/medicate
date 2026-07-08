using System;

namespace MedicDate.CapaNegocio
{
    public class clsCita
    {
        public int id_cita { get; set; }
        public int id_paciente { get; set; }
        public string nombre_paciente { get; set; } // Para mostrar
        public int id_doctor { get; set; }
        public string nombre_doctor { get; set; } // Para mostrar
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public int duracion { get; set; } = 30;
        public string motivo { get; set; }
        public string estado { get; set; } = "Pendiente";
        public decimal? costo { get; set; }
        public string notas_internas { get; set; }
        public int? id_registrado_por { get; set; }
        public string nombre_registrado_por { get; set; } // Para mostrar
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_actualizacion { get; set; }

        // Enum de estados de cita
        public enum EstadosCita
        {
            Pendiente,
            Confirmada,
            EnProgreso,
            Completada,
            Cancelada
        }
    }
}