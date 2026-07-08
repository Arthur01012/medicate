namespace MedicDate.CapaNegocio
{
    public class clsAsistente : clsEmpleado
    {
        public string turno { get; set; }

        public clsAsistente()
        {
            tipo_empleado = "asistente";
        }
    }
}