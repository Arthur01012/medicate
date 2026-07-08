using System;
using System.Windows.Forms;

namespace MedicDate.CapaPresentacion
{
    public partial class frmNuevaCita : Form
    {
        public frmNuevaCita()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad en desarrollo.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}