namespace MedicDate.CapaPresentacion
{
    partial class frmAgendaMedico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Panel superior - Información
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombreDoctor = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();

            // Panel de navegación
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblSeleccionarFecha = new System.Windows.Forms.Label();

            // Panel de acciones
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnVerPaciente = new System.Windows.Forms.Button();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();

            // DataGridView
            this.dgvCitas = new System.Windows.Forms.DataGridView();

            // Panel de resumen
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();

            this.pnlInfo.SuspendLayout();
            this.pnlNavegacion.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // pnlInfo
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(166, 202, 236);
            this.pnlInfo.Controls.Add(this.lblTitulo);
            this.pnlInfo.Controls.Add(this.lblNombreDoctor);
            this.pnlInfo.Controls.Add(this.lblFecha);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height = 80;
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(240, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agenda Médica";

            // lblNombreDoctor
            this.lblNombreDoctor.AutoSize = true;
            this.lblNombreDoctor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNombreDoctor.ForeColor = System.Drawing.Color.FromArgb(26, 61, 82);
            this.lblNombreDoctor.Location = new System.Drawing.Point(270, 28);
            this.lblNombreDoctor.Name = "lblNombreDoctor";
            this.lblNombreDoctor.Size = new System.Drawing.Size(150, 25);
            this.lblNombreDoctor.TabIndex = 1;
            this.lblNombreDoctor.Text = "Doctor: Nombre";

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(26, 61, 82);
            this.lblFecha.Location = new System.Drawing.Point(800, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(150, 21);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha de hoy";

            // pnlNavegacion
            this.pnlNavegacion.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.pnlNavegacion.Controls.Add(this.btnHoy);
            this.pnlNavegacion.Controls.Add(this.btnAnterior);
            this.pnlNavegacion.Controls.Add(this.btnSiguiente);
            this.pnlNavegacion.Controls.Add(this.dtpFecha);
            this.pnlNavegacion.Controls.Add(this.btnRefrescar);
            this.pnlNavegacion.Controls.Add(this.lblSeleccionarFecha);
            this.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavegacion.Height = 60;
            this.pnlNavegacion.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblSeleccionarFecha
            this.lblSeleccionarFecha.AutoSize = true;
            this.lblSeleccionarFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSeleccionarFecha.Location = new System.Drawing.Point(20, 15);
            this.lblSeleccionarFecha.Name = "lblSeleccionarFecha";
            this.lblSeleccionarFecha.Size = new System.Drawing.Size(52, 21);
            this.lblSeleccionarFecha.TabIndex = 0;
            this.lblSeleccionarFecha.Text = "Fecha:";

            // dtpFecha
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(80, 10);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(140, 29);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            // btnAnterior
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(166, 202, 236);
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAnterior.ForeColor = System.Drawing.Color.FromArgb(26, 61, 82);
            this.btnAnterior.Location = new System.Drawing.Point(230, 8);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(80, 35);
            this.btnAnterior.TabIndex = 2;
            this.btnAnterior.Text = "◄";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);

            // btnHoy
            this.btnHoy.BackColor = System.Drawing.Color.FromArgb(166, 202, 236);
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHoy.ForeColor = System.Drawing.Color.FromArgb(26, 61, 82);
            this.btnHoy.Location = new System.Drawing.Point(320, 8);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(60, 35);
            this.btnHoy.TabIndex = 3;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);

            // btnSiguiente
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(166, 202, 236);
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.FromArgb(26, 61, 82);
            this.btnSiguiente.Location = new System.Drawing.Point(390, 8);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(80, 35);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "►";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

            // btnRefrescar
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(490, 8);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(100, 35);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // pnlAcciones
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.pnlAcciones.Controls.Add(this.btnCambiarEstado);
            this.pnlAcciones.Controls.Add(this.btnVerPaciente);
            this.pnlAcciones.Controls.Add(this.btnCancelarCita);
            this.pnlAcciones.Controls.Add(this.btnCerrarSesion);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Height = 60;
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // btnCambiarEstado
            this.btnCambiarEstado.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCambiarEstado.ForeColor = System.Drawing.Color.FromArgb(44, 44, 44);
            this.btnCambiarEstado.Location = new System.Drawing.Point(20, 8);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(140, 35);
            this.btnCambiarEstado.TabIndex = 0;
            this.btnCambiarEstado.Text = "📝 Cambiar Estado";
            this.btnCambiarEstado.UseVisualStyleBackColor = false;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            // btnVerPaciente
            this.btnVerPaciente.BackColor = System.Drawing.Color.FromArgb(166, 202, 236);
            this.btnVerPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPaciente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVerPaciente.ForeColor = System.Drawing.Color.FromArgb(26, 61, 82);
            this.btnVerPaciente.Location = new System.Drawing.Point(180, 8);
            this.btnVerPaciente.Name = "btnVerPaciente";
            this.btnVerPaciente.Size = new System.Drawing.Size(140, 35);
            this.btnVerPaciente.TabIndex = 1;
            this.btnVerPaciente.Text = "👤 Ver Paciente";
            this.btnVerPaciente.UseVisualStyleBackColor = false;
            this.btnVerPaciente.Click += new System.EventHandler(this.btnVerPaciente_Click);

            // btnCancelarCita
            this.btnCancelarCita.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnCancelarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCita.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelarCita.ForeColor = System.Drawing.Color.White;
            this.btnCancelarCita.Location = new System.Drawing.Point(340, 8);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(140, 35);
            this.btnCancelarCita.TabIndex = 2;
            this.btnCancelarCita.Text = "❌ Cancelar Cita";
            this.btnCancelarCita.UseVisualStyleBackColor = false;
            this.btnCancelarCita.Click += new System.EventHandler(this.btnCancelarCita_Click);

            // btnCerrarSesion
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(860, 8);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 35);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // dgvCitas
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.Location = new System.Drawing.Point(0, 140);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.Size = new System.Drawing.Size(1024, 440);
            this.dgvCitas.TabIndex = 3;

            // pnlResumen
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblResumen);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height = 35;
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);

            // lblResumen
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(44, 44, 44);
            this.lblResumen.Location = new System.Drawing.Point(20, 5);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(200, 20);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "Total: 0 | Pendientes: 0 | Confirmadas: 0";

            // frmAgendaMedico
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlNavegacion);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlAcciones);
            this.Name = "frmAgendaMedico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicDate - Agenda Médica";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlNavegacion.ResumeLayout(false);
            this.pnlNavegacion.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        // Controles del formulario
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreDoctor;
        private System.Windows.Forms.Label lblFecha;

        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblSeleccionarFecha;

        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnVerPaciente;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Button btnCerrarSesion;

        private System.Windows.Forms.DataGridView dgvCitas;

        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblResumen;
    }
}