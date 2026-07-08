namespace MedicDate.CapaPresentacion
{
    partial class frmRegistroDoctor
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
            // Título
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDatosPersonales = new System.Windows.Forms.Label();

            // Datos personales
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellidoPaterno = new System.Windows.Forms.Label();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.lblApellidoMaterno = new System.Windows.Forms.Label();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono2 = new System.Windows.Forms.Label();
            this.txtTelefono2 = new System.Windows.Forms.TextBox();
            this.lblFechaContratacion = new System.Windows.Forms.Label();
            this.dtpFechaContratacion = new System.Windows.Forms.DateTimePicker();
            this.chkActivo = new System.Windows.Forms.CheckBox();

            // Datos del doctor
            this.lblDatosDoctor = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblConsultorio = new System.Windows.Forms.Label();
            this.txtConsultorio = new System.Windows.Forms.TextBox();

            // Credenciales
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblConfirmarContrasena = new System.Windows.Forms.Label();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();

            // Botones
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro del Doctor";

            // lblDatosPersonales
            this.lblDatosPersonales.AutoSize = true;
            this.lblDatosPersonales.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.lblDatosPersonales.Location = new System.Drawing.Point(30, 70);
            this.lblDatosPersonales.Name = "lblDatosPersonales";
            this.lblDatosPersonales.Size = new System.Drawing.Size(155, 25);
            this.lblDatosPersonales.TabIndex = 1;
            this.lblDatosPersonales.Text = "Datos Personales";

            // Nombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNombre.Location = new System.Drawing.Point(30, 110);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(74, 21);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre(s)";
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombre.Location = new System.Drawing.Point(30, 135);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 29);
            this.txtNombre.TabIndex = 3;

            // Apellido Paterno
            this.lblApellidoPaterno.AutoSize = true;
            this.lblApellidoPaterno.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblApellidoPaterno.Location = new System.Drawing.Point(300, 110);
            this.lblApellidoPaterno.Name = "lblApellidoPaterno";
            this.lblApellidoPaterno.Size = new System.Drawing.Size(120, 21);
            this.lblApellidoPaterno.TabIndex = 4;
            this.lblApellidoPaterno.Text = "Apellido Paterno";
            this.txtApellidoPaterno.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtApellidoPaterno.Location = new System.Drawing.Point(300, 135);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(250, 29);
            this.txtApellidoPaterno.TabIndex = 5;

            // Apellido Materno
            this.lblApellidoMaterno.AutoSize = true;
            this.lblApellidoMaterno.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblApellidoMaterno.Location = new System.Drawing.Point(570, 110);
            this.lblApellidoMaterno.Name = "lblApellidoMaterno";
            this.lblApellidoMaterno.Size = new System.Drawing.Size(125, 21);
            this.lblApellidoMaterno.TabIndex = 6;
            this.lblApellidoMaterno.Text = "Apellido Materno";
            this.txtApellidoMaterno.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtApellidoMaterno.Location = new System.Drawing.Point(570, 135);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(250, 29);
            this.txtApellidoMaterno.TabIndex = 7;

            // Fecha Nacimiento
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaNacimiento.Location = new System.Drawing.Point(30, 185);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(142, 21);
            this.lblFechaNacimiento.TabIndex = 8;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento";
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(30, 210);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaNacimiento.TabIndex = 9;

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmail.Location = new System.Drawing.Point(300, 185);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.Location = new System.Drawing.Point(300, 210);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 29);
            this.txtEmail.TabIndex = 11;

            // Teléfono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTelefono.Location = new System.Drawing.Point(570, 185);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(68, 21);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Teléfono";
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefono.Location = new System.Drawing.Point(570, 210);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(120, 29);
            this.txtTelefono.TabIndex = 13;

            // Teléfono 2
            this.lblTelefono2.AutoSize = true;
            this.lblTelefono2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTelefono2.Location = new System.Drawing.Point(700, 185);
            this.lblTelefono2.Name = "lblTelefono2";
            this.lblTelefono2.Size = new System.Drawing.Size(83, 21);
            this.lblTelefono2.TabIndex = 14;
            this.lblTelefono2.Text = "Teléfono 2";
            this.txtTelefono2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefono2.Location = new System.Drawing.Point(700, 210);
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(120, 29);
            this.txtTelefono2.TabIndex = 15;

            // Fecha Contratacion
            this.lblFechaContratacion.AutoSize = true;
            this.lblFechaContratacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaContratacion.Location = new System.Drawing.Point(30, 260);
            this.lblFechaContratacion.Name = "lblFechaContratacion";
            this.lblFechaContratacion.Size = new System.Drawing.Size(134, 21);
            this.lblFechaContratacion.TabIndex = 16;
            this.lblFechaContratacion.Text = "Fecha Contratación";
            this.dtpFechaContratacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaContratacion.Location = new System.Drawing.Point(30, 285);
            this.dtpFechaContratacion.Name = "dtpFechaContratacion";
            this.dtpFechaContratacion.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaContratacion.TabIndex = 17;

            // Activo
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkActivo.Location = new System.Drawing.Point(300, 285);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(74, 25);
            this.chkActivo.TabIndex = 18;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;

            // lblDatosDoctor
            this.lblDatosDoctor.AutoSize = true;
            this.lblDatosDoctor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDatosDoctor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.lblDatosDoctor.Location = new System.Drawing.Point(30, 340);
            this.lblDatosDoctor.Name = "lblDatosDoctor";
            this.lblDatosDoctor.Size = new System.Drawing.Size(141, 25);
            this.lblDatosDoctor.TabIndex = 19;
            this.lblDatosDoctor.Text = "Datos del Doctor";

            // Cédula
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCedula.Location = new System.Drawing.Point(30, 380);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(123, 21);
            this.lblCedula.TabIndex = 20;
            this.lblCedula.Text = "Cédula Profesional";
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCedula.Location = new System.Drawing.Point(30, 405);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(250, 29);
            this.txtCedula.TabIndex = 21;

            // Especialidad
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEspecialidad.Location = new System.Drawing.Point(300, 380);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(100, 21);
            this.lblEspecialidad.TabIndex = 22;
            this.lblEspecialidad.Text = "Especialidad";
            this.cmbEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.Location = new System.Drawing.Point(300, 405);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(250, 29);
            this.cmbEspecialidad.TabIndex = 23;

            // Consultorio
            this.lblConsultorio.AutoSize = true;
            this.lblConsultorio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblConsultorio.Location = new System.Drawing.Point(570, 380);
            this.lblConsultorio.Name = "lblConsultorio";
            this.lblConsultorio.Size = new System.Drawing.Size(84, 21);
            this.lblConsultorio.TabIndex = 24;
            this.lblConsultorio.Text = "Consultorio";
            this.txtConsultorio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConsultorio.Location = new System.Drawing.Point(570, 405);
            this.txtConsultorio.Name = "txtConsultorio";
            this.txtConsultorio.Size = new System.Drawing.Size(150, 29);
            this.txtConsultorio.TabIndex = 25;

            // Credenciales
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.Location = new System.Drawing.Point(30, 460);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 21);
            this.lblUsuario.TabIndex = 26;
            this.lblUsuario.Text = "Usuario";
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(30, 485);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(250, 29);
            this.txtUsuario.TabIndex = 27;

            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblContrasena.Location = new System.Drawing.Point(300, 460);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(81, 21);
            this.lblContrasena.TabIndex = 28;
            this.lblContrasena.Text = "Contraseña";
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContrasena.Location = new System.Drawing.Point(300, 485);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(250, 29);
            this.txtContrasena.TabIndex = 29;

            this.lblConfirmarContrasena.AutoSize = true;
            this.lblConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblConfirmarContrasena.Location = new System.Drawing.Point(570, 460);
            this.lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            this.lblConfirmarContrasena.Size = new System.Drawing.Size(144, 21);
            this.lblConfirmarContrasena.TabIndex = 30;
            this.lblConfirmarContrasena.Text = "Confirmar Contraseña";
            this.txtConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(570, 485);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '*';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(250, 29);
            this.txtConfirmarContrasena.TabIndex = 31;

            // Botones
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(680, 550);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 45);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(520, 550);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 45);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // frmRegistroDoctor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtConfirmarContrasena);
            this.Controls.Add(this.lblConfirmarContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtConsultorio);
            this.Controls.Add(this.lblConsultorio);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.lblDatosDoctor);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.dtpFechaContratacion);
            this.Controls.Add(this.lblFechaContratacion);
            this.Controls.Add(this.txtTelefono2);
            this.Controls.Add(this.lblTelefono2);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.lblApellidoMaterno);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.lblApellidoPaterno);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDatosPersonales);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmRegistroDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicDate - Registrar Doctor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDatosPersonales;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellidoPaterno;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.Label lblApellidoMaterno;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono2;
        private System.Windows.Forms.TextBox txtTelefono2;
        private System.Windows.Forms.Label lblFechaContratacion;
        private System.Windows.Forms.DateTimePicker dtpFechaContratacion;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblDatosDoctor;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label lblConsultorio;
        private System.Windows.Forms.TextBox txtConsultorio;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblConfirmarContrasena;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}