namespace MedicDate.CapaPresentacion
{
    partial class frmAgendaAsistente
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.btnNuevaCita = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(242, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agenda - Asistente";

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFecha.Location = new System.Drawing.Point(30, 75);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(52, 21);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";

            // dtpFecha
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(88, 70);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 29);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            // dgvCitas
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(30, 120);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.Size = new System.Drawing.Size(900, 450);
            this.dgvCitas.TabIndex = 3;

            // btnNuevaCita
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCita.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Location = new System.Drawing.Point(750, 600);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(180, 45);
            this.btnNuevaCita.TabIndex = 4;
            this.btnNuevaCita.Text = "➕ Nueva Cita";
            this.btnNuevaCita.UseVisualStyleBackColor = false;
            this.btnNuevaCita.Click += new System.EventHandler(this.btnNuevaCita_Click);

            // btnCerrarSesion
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(30, 600);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 45);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // frmAgendaAsistente
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(950, 670);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnNuevaCita);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmAgendaAsistente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicDate - Agenda Asistente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Button btnNuevaCita;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}