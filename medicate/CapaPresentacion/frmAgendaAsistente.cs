using System;
using System.Windows.Forms;
using MedicDate.CapaDatos;

namespace MedicDate.CapaPresentacion
{
    public partial class frmAgendaAsistente : Form
    {
        public frmAgendaAsistente()
        {
            InitializeComponent();
            CargarAgenda();
        }

        private void CargarAgenda()
        {
            try
            {
                dtpFecha.Value = DateTime.Today;
                dgvCitas.DataSource = clsCitaDAL.ObtenerCitasPorFecha(DateTime.Today);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar agenda: " + ex.Message);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dgvCitas.DataSource = clsCitaDAL.ObtenerCitasPorFecha(dtpFecha.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar agenda: " + ex.Message);
            }
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            frmNuevaCita frm = new frmNuevaCita();
            frm.ShowDialog();
            CargarAgenda();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmLogin().Show();
        }
    }
}