namespace MedicDate.CapaNegocio
{
    public class clsMunicipio
    {
        public int id_municipio { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string codigo_postal { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}