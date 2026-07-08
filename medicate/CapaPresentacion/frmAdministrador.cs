using System;
using System.Windows.Forms;
using MedicDate.CapaDatos;

namespace MedicDate.CapaPresentacion
{
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "MedicDate - Panel de Administración";
            this.WindowState = FormWindowState.Maximized;

            // Mostrar información del usuario
            lblUsuario.Text = $"Bienvenido, {Sesion.UsuarioActual.usuario}";
            lblRol.Text = $"Rol: {Sesion.UsuarioActual.nombre_rol}";
        }

        private void AbrirFormulario(Form formulario)
        {
            pnlContenido.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.Parent = pnlContenido;
            formulario.Show();
        }

        private void btnRegistrarDoctor_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistroDoctor());
        }

        private void btnRegistrarAsistente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistroAsistente());
        }

        private void btnRegistrarPaciente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistroPaciente());
        }

        private void btnHorarioDoctor_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmHorarioDoctor());
        }

        private void btnVerAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAgendaAsistente());
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmNuevaCita());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmLogin().Show();
        }
    }
}