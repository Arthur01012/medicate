namespace MedicDate.CapaPresentacion
{
    partial class frmNuevaCita
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(175, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Cita";

            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblInfo.Location = new System.Drawing.Point(30, 80);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(245, 21);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Formulario en desarrollo próximamente";

            this.btnAgendar.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnAgendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgendar.ForeColor = System.Drawing.Color.White;
            this.btnAgendar.Location = new System.Drawing.Point(680, 550);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(140, 45);
            this.btnAgendar.TabIndex = 2;
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.UseVisualStyleBackColor = false;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(520, 550);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 45);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmNuevaCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicDate - Nueva Cita";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnCancelar;
    }
}