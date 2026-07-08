using System;
using System.Windows.Forms;
using MedicDate.CapaNegocio;
using MedicDate.CapaDatos;

namespace MedicDate.CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Configurar el formulario al cargar
            this.Text = "MedicDate - Iniciar Sesión";
            this.StartPosition = FormStartPosition.CenterScreen;
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasena.Text))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                clsUsuario usuario = clsUsuarioDAL.Autenticar(txtUsuario.Text, txtContrasena.Text);

                if (usuario != null)
                {
                    // Almacenar usuario en sesión global
                    Sesion.UsuarioActual = usuario;

                    // Abrir ventana según rol
                    Form formPrincipal = null;
                    switch (usuario.id_rol)
                    {
                        case (int)clsUsuario.Roles.Administrador:
                            formPrincipal = new frmAdministrador();
                            break;
                        case (int)clsUsuario.Roles.Asistente:
                            formPrincipal = new frmAgendaAsistente();
                            break;
                        case (int)clsUsuario.Roles.Doctor:
                            formPrincipal = new frmAgendaMedico();
                            break;
                        default:
                            MessageBox.Show("Rol no reconocido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    this.Hide();
                    formPrincipal.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // Clase estática para mantener la sesión del usuario
    public static class Sesion
    {
        public static clsUsuario UsuarioActual { get; set; }
        public static int IdEmpleadoActual { get; set; }
        public static string NombreEmpleadoActual { get; set; }
    }
}