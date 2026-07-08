using System.Data;
using MySql.Data.MySqlClient;

namespace MedicDate.CapaDatos
{
    public class clsMunicipioDAL
    {
        public static DataTable ObtenerTodos()
        {
            string consulta = "SELECT id_municipio, nombre, estado, codigo_postal FROM MUNICIPIO ORDER BY nombre";
            return clsConexion.EjecutarConsulta(consulta);
        }
    }
}
