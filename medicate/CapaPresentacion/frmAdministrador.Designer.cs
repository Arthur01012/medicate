namespace MedicDate.CapaPresentacion
{
    partial class frmAdministrador
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
            // Panel superior
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();

            // Panel lateral
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.btnRegistrarDoctor = new System.Windows.Forms.Button();
            this.btnRegistrarAsistente = new System.Windows.Forms.Button();
            this.btnRegistrarPaciente = new System.Windows.Forms.Button();
            this.btnHorarioDoctor = new System.Windows.Forms.Button();
            this.btnVerAgenda = new System.Windows.Forms.Button();
            this.btnNuevaCita = new System.Windows.Forms.Button();

            // Panel contenido
            this.pnlContenido = new System.Windows.Forms.Panel();

            // pnlSuperior
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(202)))), ((int)(((byte)(236)))));
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Height = 60;
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Controls.Add(this.lblUsuario);
            this.pnlSuperior.Controls.Add(this.lblRol);
            this.pnlSuperior.Controls.Add(this.btnCerrarSesion);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(185, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MedicDate - Admin";

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(700, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 21);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";

            // lblRol
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRol.ForeColor = System.Drawing.Color.White;
            this.lblRol.Location = new System.Drawing.Point(700, 35);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(30, 19);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Rol";

            // btnCerrarSesion
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(900, 10);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 40);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // pnlLateral
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(202)))), ((int)(((byte)(236)))));
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Width = 220;
            this.pnlLateral.Padding = new System.Windows.Forms.Padding(10);

            // btnRegistrarDoctor
            this.btnRegistrarDoctor.BackColor = System.Drawing.Color.White;
            this.btnRegistrarDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarDoctor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRegistrarDoctor.Location = new System.Drawing.Point(10, 20);
            this.btnRegistrarDoctor.Name = "btnRegistrarDoctor";
            this.btnRegistrarDoctor.Size = new System.Drawing.Size(200, 45);
            this.btnRegistrarDoctor.TabIndex = 0;
            this.btnRegistrarDoctor.Text = "👨‍⚕️ Registrar Doctor";
            this.btnRegistrarDoctor.UseVisualStyleBackColor = false;
            this.btnRegistrarDoctor.Click += new System.EventHandler(this.btnRegistrarDoctor_Click);

            // btnRegistrarAsistente
            this.btnRegistrarAsistente.BackColor = System.Drawing.Color.White;
            this.btnRegistrarAsistente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarAsistente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRegistrarAsistente.Location = new System.Drawing.Point(10, 80);
            this.btnRegistrarAsistente.Name = "btnRegistrarAsistente";
            this.btnRegistrarAsistente.Size = new System.Drawing.Size(200, 45);
            this.btnRegistrarAsistente.TabIndex = 1;
            this.btnRegistrarAsistente.Text = "👤 Registrar Asistente";
            this.btnRegistrarAsistente.UseVisualStyleBackColor = false;
            this.btnRegistrarAsistente.Click += new System.EventHandler(this.btnRegistrarAsistente_Click);

            // btnRegistrarPaciente
            this.btnRegistrarPaciente.BackColor = System.Drawing.Color.White;
            this.btnRegistrarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPaciente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRegistrarPaciente.Location = new System.Drawing.Point(10, 140);
            this.btnRegistrarPaciente.Name = "btnRegistrarPaciente";
            this.btnRegistrarPaciente.Size = new System.Drawing.Size(200, 45);
            this.btnRegistrarPaciente.TabIndex = 2;
            this.btnRegistrarPaciente.Text = "🧑‍⚕️ Registrar Paciente";
            this.btnRegistrarPaciente.UseVisualStyleBackColor = false;
            this.btnRegistrarPaciente.Click += new System.EventHandler(this.btnRegistrarPaciente_Click);

            // btnHorarioDoctor
            this.btnHorarioDoctor.BackColor = System.Drawing.Color.White;
            this.btnHorarioDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorarioDoctor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnHorarioDoctor.Location = new System.Drawing.Point(10, 200);
            this.btnHorarioDoctor.Name = "btnHorarioDoctor";
            this.btnHorarioDoctor.Size = new System.Drawing.Size(200, 45);
            this.btnHorarioDoctor.TabIndex = 3;
            this.btnHorarioDoctor.Text = "📅 Horario Doctor";
            this.btnHorarioDoctor.UseVisualStyleBackColor = false;
            this.btnHorarioDoctor.Click += new System.EventHandler(this.btnHorarioDoctor_Click);

            // btnVerAgenda
            this.btnVerAgenda.BackColor = System.Drawing.Color.White;
            this.btnVerAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerAgenda.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVerAgenda.Location = new System.Drawing.Point(10, 260);
            this.btnVerAgenda.Name = "btnVerAgenda";
            this.btnVerAgenda.Size = new System.Drawing.Size(200, 45);
            this.btnVerAgenda.TabIndex = 4;
            this.btnVerAgenda.Text = "📋 Ver Agenda";
            this.btnVerAgenda.UseVisualStyleBackColor = false;
            this.btnVerAgenda.Click += new System.EventHandler(this.btnVerAgenda_Click);

            // btnNuevaCita
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCita.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Location = new System.Drawing.Point(10, 320);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(200, 45);
            this.btnNuevaCita.TabIndex = 5;
            this.btnNuevaCita.Text = "➕ Nueva Cita";
            this.btnNuevaCita.UseVisualStyleBackColor = false;
            this.btnNuevaCita.Click += new System.EventHandler(this.btnNuevaCita_Click);

            // pnlContenido
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;

            // frmAdministrador
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "frmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicDate - Administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        // Controles
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnCerrarSesion;

        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Button btnRegistrarDoctor;
        private System.Windows.Forms.Button btnRegistrarAsistente;
        private System.Windows.Forms.Button btnRegistrarPaciente;
        private System.Windows.Forms.Button btnHorarioDoctor;
        private System.Windows.Forms.Button btnVerAgenda;
        private System.Windows.Forms.Button btnNuevaCita;

        private System.Windows.Forms.Panel pnlContenido;
    }
}