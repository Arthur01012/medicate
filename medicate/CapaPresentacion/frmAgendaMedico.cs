using MedicDate.CapaDatos;
using MedicDate.CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MedicDate.CapaPresentacion
{
    public partial class frmAgendaMedico : Form
    {
        private int idDoctorActual;

        public frmAgendaMedico()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configurar el DataGridView
            ConfigurarDataGridView();

            // Obtener el ID del doctor basado en el usuario logueado
            CargarIdDoctor();

            // Cargar la agenda del día actual
            CargarAgenda(DateTime.Today);

            // Mostrar información del médico
            MostrarInformacionMedico();
        }

        private void ConfigurarDataGridView()
        {
            // Estilo del DataGridView
            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.MultiSelect = false;
            dgvCitas.ReadOnly = true;
            dgvCitas.RowHeadersVisible = false;
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.AllowUserToDeleteRows = false;

            // Colores según la guía de estilos
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvCitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(166, 202, 236);
            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(26, 61, 82);
            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgvCitas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(166, 202, 236);
            dgvCitas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 44, 44);

            // Agregar evento para colorear filas según estado
            dgvCitas.RowPrePaint += DgvCitas_RowPrePaint;
        }

        private void CargarIdDoctor()
        {
            try
            {
                // Buscar el empleado que corresponde al usuario actual
                // Aquí deberías obtener el ID del empleado desde la sesión o consultar la BD
                // Por ahora, usamos un valor de ejemplo o lo obtenemos de la sesión
                if (Sesion.IdEmpleadoActual > 0)
                {
                    idDoctorActual = Sesion.IdEmpleadoActual;
                }
                else
                {
                    // Si no está en sesión, buscar por usuario
                    DataTable doctores = clsDoctorDAL.ObtenerTodos();
                    if (doctores.Rows.Count > 0)
                    {
                        // Suponiendo que el primer doctor es el logueado
                        idDoctorActual = Convert.ToInt32(doctores.Rows[0]["id_empleado"]);
                        Sesion.IdEmpleadoActual = idDoctorActual;
                    }
                }

                // Mostrar nombre del doctor
                DataTable doctorInfo = clsDoctorDAL.ObtenerTodos();
                foreach (DataRow row in doctorInfo.Rows)
                {
                    if (Convert.ToInt32(row["id_empleado"]) == idDoctorActual)
                    {
                        lblNombreDoctor.Text = row["nombre_completo"].ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Si no se puede obtener el ID, mostrar mensaje pero permitir continuar
                lblNombreDoctor.Text = "Doctor (ID no encontrado)";
                System.Diagnostics.Debug.WriteLine("Error al cargar ID del doctor: " + ex.Message);
            }
        }

        private void MostrarInformacionMedico()
        {
            // Configurar el panel de información
            pnlInfo.BackColor = Color.FromArgb(166, 202, 236);
            pnlInfo.Height = 80;
            pnlInfo.Dock = DockStyle.Top;

            // Actualizar título
            lblTitulo.Text = "Agenda Médica";

            // Fecha actual
            lblFecha.Text = DateTime.Today.ToString("dddd, d 'de' MMMM 'de' yyyy");
        }

        private void CargarAgenda(DateTime fecha)
        {
            try
            {
                if (idDoctorActual > 0)
                {
                    DataTable citas = clsCitaDAL.ObtenerCitasPorDoctor(idDoctorActual, fecha);
                    dgvCitas.DataSource = citas;

                    // Formatear columnas
                    if (dgvCitas.Columns.Count > 0)
                    {
                        // Renombrar columnas
                        if (dgvCitas.Columns.Contains("id_cita"))
                            dgvCitas.Columns["id_cita"].HeaderText = "ID";
                        if (dgvCitas.Columns.Contains("paciente"))
                            dgvCitas.Columns["paciente"].HeaderText = "Paciente";
                        if (dgvCitas.Columns.Contains("hora"))
                            dgvCitas.Columns["hora"].HeaderText = "Hora";
                        if (dgvCitas.Columns.Contains("motivo"))
                            dgvCitas.Columns["motivo"].HeaderText = "Motivo";
                        if (dgvCitas.Columns.Contains("estado"))
                            dgvCitas.Columns["estado"].HeaderText = "Estado";
                        if (dgvCitas.Columns.Contains("telefono_principal"))
                            dgvCitas.Columns["telefono_principal"].HeaderText = "Teléfono";

                        // Ocultar columnas innecesarias
                        if (dgvCitas.Columns.Contains("id_paciente"))
                            dgvCitas.Columns["id_paciente"].Visible = false;
                        if (dgvCitas.Columns.Contains("id_doctor"))
                            dgvCitas.Columns["id_doctor"].Visible = false;
                        if (dgvCitas.Columns.Contains("duracion"))
                            dgvCitas.Columns["duracion"].Visible = false;
                        if (dgvCitas.Columns.Contains("costo"))
                            dgvCitas.Columns["costo"].Visible = false;
                        if (dgvCitas.Columns.Contains("notas_internas"))
                            dgvCitas.Columns["notas_internas"].Visible = false;
                        if (dgvCitas.Columns.Contains("id_registrado_por"))
                            dgvCitas.Columns["id_registrado_por"].Visible = false;
                        if (dgvCitas.Columns.Contains("fecha_registro"))
                            dgvCitas.Columns["fecha_registro"].Visible = false;
                        if (dgvCitas.Columns.Contains("fecha_actualizacion"))
                            dgvCitas.Columns["fecha_actualizacion"].Visible = false;
                    }

                    // Contar citas
                    int totalCitas = citas.Rows.Count;
                    int pendientes = 0;
                    int confirmadas = 0;
                    int completadas = 0;

                    foreach (DataRow row in citas.Rows)
                    {
                        string estado = row["estado"].ToString();
                        if (estado == "Pendiente") pendientes++;
                        else if (estado == "Confirmada") confirmadas++;
                        else if (estado == "Completada") completadas++;
                    }

                    lblResumen.Text = $"Total: {totalCitas} | Pendientes: {pendientes} | Confirmadas: {confirmadas} | Completadas: {completadas}";
                }
                else
                {
                    dgvCitas.DataSource = null;
                    lblResumen.Text = "No se pudo cargar la agenda del médico";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la agenda: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCitas_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCitas.Rows.Count)
            {
                DataGridViewRow row = dgvCitas.Rows[e.RowIndex];
                if (row.Cells["estado"].Value != null)
                {
                    string estado = row.Cells["estado"].Value.ToString();
                    switch (estado)
                    {
                        case "Pendiente":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 59); // Amarillo
                            break;
                        case "Confirmada":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94); // Verde
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "Completada":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94); // Verde
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "Cancelada":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(239, 68, 68); // Rojo
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "En Progreso":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 165, 0); // Naranja
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFecha.Value;
            lblFecha.Text = fechaSeleccionada.ToString("dddd, d 'de' MMMM 'de' yyyy");
            CargarAgenda(fechaSeleccionada);
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = dtpFecha.Value.AddDays(-1);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = dtpFecha.Value.AddDays(1);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarAgenda(dtpFecha.Value);
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una cita para cambiar su estado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idCita = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["id_cita"].Value);
            string estadoActual = dgvCitas.SelectedRows[0].Cells["estado"].Value.ToString();

            using (Form frmEstado = new Form())
            {
                frmEstado.Text = "Cambiar Estado de Cita";
                frmEstado.Size = new Size(300, 200);
                frmEstado.StartPosition = FormStartPosition.CenterParent;
                frmEstado.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmEstado.MaximizeBox = false;
                frmEstado.MinimizeBox = false;

                Label lblEstado = new Label();
                lblEstado.Text = "Seleccione el nuevo estado:";
                lblEstado.Location = new Point(20, 20);
                lblEstado.Size = new Size(250, 25);
                lblEstado.Font = new Font("Segoe UI", 11F);

                ComboBox cmbEstados = new ComboBox();
                cmbEstados.Location = new Point(20, 55);
                cmbEstados.Size = new Size(240, 25);
                cmbEstados.Font = new Font("Segoe UI", 11F);
                cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbEstados.Items.AddRange(new object[] { "Pendiente", "Confirmada", "En Progreso", "Completada", "Cancelada" });
                cmbEstados.SelectedItem = estadoActual;

                Button btnAceptar = new Button();
                btnAceptar.Text = "Aceptar";
                btnAceptar.Location = new Point(80, 110);
                btnAceptar.Size = new Size(100, 35);
                btnAceptar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnAceptar.BackColor = Color.FromArgb(34, 197, 94);
                btnAceptar.ForeColor = Color.White;
                btnAceptar.FlatStyle = FlatStyle.Flat;

                btnAceptar.Click += (s, e2) =>
                {
                    string nuevoEstado = cmbEstados.SelectedItem.ToString();
                    if (nuevoEstado != estadoActual)
                    {
                        try
                        {
                            if (clsCitaDAL.CambiarEstado(idCita, nuevoEstado))
                            {
                                MessageBox.Show("Estado de la cita actualizado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarAgenda(dtpFecha.Value);
                                frmEstado.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar el estado.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estado seleccionado es el mismo que el actual.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmEstado.Close();
                    }
                };

                Button btnCancelarEstado = new Button();
                btnCancelarEstado.Text = "Cancelar";
                btnCancelarEstado.Location = new Point(190, 110);
                btnCancelarEstado.Size = new Size(80, 35);
                btnCancelarEstado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnCancelarEstado.BackColor = Color.FromArgb(239, 68, 68);
                btnCancelarEstado.ForeColor = Color.White;
                btnCancelarEstado.FlatStyle = FlatStyle.Flat;
                btnCancelarEstado.Click += (s, e2) => frmEstado.Close();

                frmEstado.Controls.Add(lblEstado);
                frmEstado.Controls.Add(cmbEstados);
                frmEstado.Controls.Add(btnAceptar);
                frmEstado.Controls.Add(btnCancelarEstado);

                frmEstado.ShowDialog();
            }
        }

        private void btnVerPaciente_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una cita para ver los datos del paciente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener el nombre del paciente de la fila seleccionada
            string nombrePaciente = dgvCitas.SelectedRows[0].Cells["paciente"].Value.ToString();

            // Buscar el paciente por nombre (o por ID si está disponible)
            int idPaciente = 0;
            if (dgvCitas.SelectedRows[0].Cells["id_paciente"] != null)
            {
                idPaciente = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["id_paciente"].Value);
            }

            MessageBox.Show($"Datos del paciente:\n\nNombre: {nombrePaciente}\nID: {idPaciente}\n\n" +
                "Para ver más detalles, use el módulo de gestión de pacientes.", "Información del Paciente",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una cita para cancelar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idCita = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["id_cita"].Value);
            string paciente = dgvCitas.SelectedRows[0].Cells["paciente"].Value.ToString();

            DialogResult result = MessageBox.Show($"¿Está seguro de cancelar la cita de {paciente}?",
                "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (clsCitaDAL.Cancelar(idCita))
                    {
                        MessageBox.Show("Cita cancelada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAgenda(dtpFecha.Value);
                    }
                    else
                    {
                        MessageBox.Show("Error al cancelar la cita.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cerrar sesión?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }
    }
}