using MedicDate.CapaPresentacion;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace MedicDate
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Probar conexión antes de abrir la aplicación
            TestConnection();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        static void TestConnection()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["MedicDateDB"].ConnectionString;
                Console.WriteLine("🔍 Probando conexión a MySQL...");
                Console.WriteLine($"📌 Cadena: {connString}");

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    Console.WriteLine("✅ ¡Conexión exitosa!");

                    // Contar usuarios
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM USUARIO", conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        Console.WriteLine($"📊 Usuarios registrados: {count}");
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.WriteLine("\n⚠️ La aplicación continuará, pero podría tener problemas de conexión.");
                MessageBox.Show($"Error de conexión a MySQL:\n\n{ex.Message}\n\n" +
                                "Verifica que:\n" +
                                "1. MySQL está corriendo\n" +
                                "2. La contraseña en App.config es correcta\n" +
                                "3. La base de datos 'medicdate_db' existe",
                                "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}