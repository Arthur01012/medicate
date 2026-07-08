using System;
using System.Windows.Forms;

namespace MedicDate.CapaPresentacion
{
    public partial class frmRegistroPaciente : Form
    {
        public frmRegistroPaciente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad en desarrollo.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}