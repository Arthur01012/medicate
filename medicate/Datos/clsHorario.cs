using System;

namespace MedicDate.CapaNegocio
{
    public class clsHorario
    {
        public int id_horario { get; set; }
        public int id_doctor { get; set; }
        public string dia_semana { get; set; }
        public TimeSpan hora_inicio { get; set; }
        public TimeSpan hora_fin { get; set; }
        public int intervalo_atencion { get; set; } = 30;
        public bool activo { get; set; } = true;

        public string RangoHorario
        {
            get { return $"{hora_inicio:hh\\:mm} - {hora_fin:hh\\:mm}"; }
        }
    }
}