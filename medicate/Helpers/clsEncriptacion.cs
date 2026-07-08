using System;
using System.Security.Cryptography;
using System.Text;

namespace MedicDate.Helpers
{
    public static class clsEncriptacion
    {
        public static string EncriptarSHA256(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static string EncriptarMD5(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}