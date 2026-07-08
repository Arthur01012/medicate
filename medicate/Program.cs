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
            if (!TestConnection())
            {
                DialogResult result = MessageBox.Show(
                    "No se pudo conectar a la base de datos.\n\n" +
                    "¿Deseas continuar de todos modos?",
                    "Error de Conexión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        static bool TestConnection()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["MedicDateDB"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    // Solo verificar que la conexión funciona
                    using (MySqlCommand cmd = new MySqlCommand("SELECT 1", conn))
                    {
                        cmd.ExecuteScalar();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error de conexión a MySQL:\n\n{ex.Message}\n\n" +
                    "Verifica que:\n" +
                    "1. MySQL está corriendo (XAMPP)\n" +
                    "2. La contraseña en App.config es correcta\n" +
                    "3. La base de datos 'medicdate_db' existe",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}