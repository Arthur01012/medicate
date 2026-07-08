using System;
using System.Text.RegularExpressions;

namespace MedicDate.Helpers
{
    public static class clsValidaciones
    {
        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool EsTelefonoValido(string telefono)
        {
            if (string.IsNullOrEmpty(telefono)) return false;
            return Regex.IsMatch(telefono, @"^[0-9]{10}$");
        }

        public static bool EsCURPValido(string curp)
        {
            if (string.IsNullOrEmpty(curp)) return false;
            return Regex.IsMatch(curp, @"^[A-Z]{4}[0-9]{6}[A-Z]{6}[0-9]{2}$");
        }

        public static bool EsFechaValida(DateTime fecha)
        {
            return fecha <= DateTime.Today;
        }

        public static bool EsEdadValida(DateTime fechaNacimiento)
        {
            int edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
            return edad >= 0 && edad <= 120;
        }
    }
}