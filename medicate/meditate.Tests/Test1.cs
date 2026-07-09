using System.Data;
using MedicDate.CapaDatos;
using MedicDate.CapaNegocio;
using MySql.Data.MySqlClient;

namespace meditate.Tests;

[TestClass]
public class DalIntegrationTests
{
    [TestMethod]
    public void Paciente_InsertarYConfirmarCommit()
    {
        var paciente = new clsPaciente
        {
            nombre = "Prueba",
            apellido_paterno = "Paciente",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1990, 1, 1),
            telefono_principal = "555000111",
            telefono_secundario = "555000112",
            email = $"paciente_{Guid.NewGuid():N}@test.com",
            calle = "Calle Test",
            colonia = "Colonia Test",
            numero = "123",
            localidad = "Localidad Test",
            id_municipio = 1,
            alergias = "Ninguna",
            notas_medicas = "Prueba de integración"
        };

        int idInsertado;
        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            idInsertado = clsPacienteDAL.Insertar(paciente, transaccion);
            Assert.IsTrue(idInsertado > 0, "El paciente no fue insertado.");
            transaccion.Commit();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM PACIENTE WHERE id_paciente = @id", new[] { new MySqlParameter("@id", idInsertado) });
        Assert.AreEqual(1, tabla.Rows.Count, "El paciente insertado no quedó persistido.");

        clsConexion.EjecutarNonQuery("DELETE FROM PACIENTE WHERE id_paciente = @id", new[] { new MySqlParameter("@id", idInsertado) });
    }

    [TestMethod]
    public void Paciente_InsertarYRollback()
    {
        var paciente = new clsPaciente
        {
            nombre = "Rollback",
            apellido_paterno = "Paciente",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1992, 2, 2),
            telefono_principal = "555000221",
            telefono_secundario = "555000222",
            email = $"rollback_{Guid.NewGuid():N}@test.com",
            calle = "Calle Rollback",
            colonia = "Colonia Rollback",
            numero = "321",
            localidad = "Localidad Rollback",
            id_municipio = 1,
            alergias = "Ninguna",
            notas_medicas = "Rollback de integración"
        };

        int idInsertado;
        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            idInsertado = clsPacienteDAL.Insertar(paciente, transaccion);
            Assert.IsTrue(idInsertado > 0, "El paciente no fue insertado en la transacción.");
            transaccion.Rollback();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM PACIENTE WHERE id_paciente = @id", new[] { new MySqlParameter("@id", idInsertado) });
        Assert.AreEqual(0, tabla.Rows.Count, "El rollback no eliminó el paciente insertado.");
    }

    [TestMethod]
    public void Usuario_CrearYConfirmarCommit()
    {
        var usuario = new clsUsuario
        {
            usuario = $"usr_{Guid.NewGuid():N}".Substring(0, 12),
            contrasena = "123456",
            id_rol = ObtenerPrimerRolId(),
            activo = true
        };

        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            var creado = clsUsuarioDAL.CrearUsuario(usuario, transaccion);
            Assert.IsTrue(creado, "No se pudo crear el usuario.");
            Assert.IsTrue(usuario.id_usuario > 0, "No se asignó el id del usuario.");
            transaccion.Commit();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM USUARIO WHERE id_usuario = @id", new[] { new MySqlParameter("@id", usuario.id_usuario) });
        Assert.AreEqual(1, tabla.Rows.Count, "El usuario no quedó persistido.");
        clsConexion.EjecutarNonQuery("DELETE FROM USUARIO WHERE id_usuario = @id", new[] { new MySqlParameter("@id", usuario.id_usuario) });
    }

    [TestMethod]
    public void Empleado_InsertarYConfirmarCommit()
    {
        var empleado = new clsEmpleado
        {
            nombre = "Prueba",
            apellido_paterno = "Empleado",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1985, 5, 5),
            curp = $"CURP{Guid.NewGuid():N}".Substring(0, 18),
            email = $"empleado_{Guid.NewGuid():N}@test.com",
            telefono_principal = "555000333",
            telefono_secundario = "555000334",
            tipo_empleado = "doctor",
            fecha_contratacion = DateTime.Today,
            estado = true,
            id_usuario = null
        };

        int idInsertado;
        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            idInsertado = clsEmpleadoDAL.Insertar(empleado, transaccion);
            Assert.IsTrue(idInsertado > 0, "El empleado no fue insertado.");
            transaccion.Commit();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM EMPLEADO WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idInsertado) });
        Assert.AreEqual(1, tabla.Rows.Count, "El empleado insertado no quedó persistido.");
        clsConexion.EjecutarNonQuery("DELETE FROM EMPLEADO WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idInsertado) });
    }

    [TestMethod]
    public void Doctor_InsertarYConfirmarCommit()
    {
        var empleado = new clsEmpleado
        {
            nombre = "Prueba",
            apellido_paterno = "Doctor",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1978, 7, 8),
            curp = $"CURP{Guid.NewGuid():N}".Substring(0, 18),
            email = $"doctor_{Guid.NewGuid():N}@test.com",
            telefono_principal = "555000444",
            telefono_secundario = "555000445",
            tipo_empleado = "doctor",
            fecha_contratacion = DateTime.Today,
            estado = true,
            id_usuario = null
        };

        var doctor = new clsDoctor
        {
            nombre = empleado.nombre,
            apellido_paterno = empleado.apellido_paterno,
            apellido_materno = empleado.apellido_materno,
            fecha_nacimiento = empleado.fecha_nacimiento,
            curp = empleado.curp,
            email = empleado.email,
            telefono_principal = empleado.telefono_principal,
            telefono_secundario = empleado.telefono_secundario,
            tipo_empleado = empleado.tipo_empleado,
            fecha_contratacion = empleado.fecha_contratacion,
            estado = empleado.estado,
            id_usuario = empleado.id_usuario,
            cedula_profesional = $"CED{Guid.NewGuid():N}".Substring(0, 12),
            especialidad_principal = ObtenerPrimeraEspecialidadId(),
            consultorio = "Consultorio 1"
        };

        int idEmpleado;
        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            idEmpleado = clsEmpleadoDAL.Insertar(empleado, transaccion);
            doctor.id_empleado = idEmpleado;
            var creado = clsDoctorDAL.Insertar(doctor, transaccion);
            Assert.IsTrue(creado, "El doctor no fue insertado.");
            transaccion.Commit();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM DOCTOR WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
        Assert.AreEqual(1, tabla.Rows.Count, "El doctor no quedó persistido.");
        clsConexion.EjecutarNonQuery("DELETE FROM DOCTOR WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
        clsConexion.EjecutarNonQuery("DELETE FROM EMPLEADO WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
    }

    [TestMethod]
    public void Asistente_InsertarYConfirmarCommit()
    {
        var empleado = new clsEmpleado
        {
            nombre = "Prueba",
            apellido_paterno = "Asistente",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1988, 8, 8),
            curp = $"CURP{Guid.NewGuid():N}".Substring(0, 18),
            email = $"asistente_{Guid.NewGuid():N}@test.com",
            telefono_principal = "555000555",
            telefono_secundario = "555000556",
            tipo_empleado = "asistente",
            fecha_contratacion = DateTime.Today,
            estado = true,
            id_usuario = null
        };

        var asistente = new clsAsistente
        {
            nombre = empleado.nombre,
            apellido_paterno = empleado.apellido_paterno,
            apellido_materno = empleado.apellido_materno,
            fecha_nacimiento = empleado.fecha_nacimiento,
            curp = empleado.curp,
            email = empleado.email,
            telefono_principal = empleado.telefono_principal,
            telefono_secundario = empleado.telefono_secundario,
            tipo_empleado = empleado.tipo_empleado,
            fecha_contratacion = empleado.fecha_contratacion,
            estado = empleado.estado,
            id_usuario = empleado.id_usuario,
            turno = "Mañana"
        };

        int idEmpleado;
        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            idEmpleado = clsEmpleadoDAL.Insertar(empleado, transaccion);
            asistente.id_empleado = idEmpleado;
            var creado = clsAsistenteDAL.Insertar(asistente, transaccion);
            Assert.IsTrue(creado, "El asistente no fue insertado.");
            transaccion.Commit();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM ASISTENTE WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
        Assert.AreEqual(1, tabla.Rows.Count, "El asistente no quedó persistido.");
        clsConexion.EjecutarNonQuery("DELETE FROM ASISTENTE WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
        clsConexion.EjecutarNonQuery("DELETE FROM EMPLEADO WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
    }

    [TestMethod]
    public void Cita_InsertarYConfirmarCommit()
    {
        var paciente = CrearPacientePrueba();
        var doctor = CrearDoctorPrueba();

        int idPaciente = paciente.id_paciente;
        int idDoctor = doctor.id_empleado;

        var cita = new clsCita
        {
            id_paciente = idPaciente,
            id_doctor = idDoctor,
            fecha = DateTime.Today.AddDays(1),
            hora = new TimeSpan(10, 0, 0),
            duracion = 30,
            motivo = "Prueba de integración",
            estado = "Pendiente",
            costo = 150m,
            notas_internas = "Prueba",
            id_registrado_por = null
        };

        int idCita;
        using (var conexion = clsConexion.ObtenerConexion())
        using (var transaccion = conexion.BeginTransaction())
        {
            idCita = clsCitaDAL.Insertar(cita, transaccion);
            Assert.IsTrue(idCita > 0, "La cita no fue insertada.");
            transaccion.Commit();
        }

        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM CITA WHERE id_cita = @id", new[] { new MySqlParameter("@id", idCita) });
        Assert.AreEqual(1, tabla.Rows.Count, "La cita no quedó persistida.");
        clsConexion.EjecutarNonQuery("DELETE FROM CITA WHERE id_cita = @id", new[] { new MySqlParameter("@id", idCita) });
        LimpiarDoctorYPaciente(idDoctor, idPaciente);
    }

    private static int ObtenerPrimerRolId()
    {
        var resultado = clsConexion.EjecutarConsulta("SELECT id_rol FROM ROL ORDER BY id_rol LIMIT 1");
        Assert.IsTrue(resultado.Rows.Count > 0, "No hay roles registrados para usar en las pruebas.");
        return Convert.ToInt32(resultado.Rows[0]["id_rol"]);
    }

    private static int? ObtenerPrimeraEspecialidadId()
    {
        var resultado = clsConexion.EjecutarConsulta("SELECT id_especialidad FROM ESPECIALIDAD ORDER BY id_especialidad LIMIT 1");
        return resultado.Rows.Count > 0 ? Convert.ToInt32(resultado.Rows[0]["id_especialidad"]) : null;
    }

    private static clsPaciente CrearPacientePrueba()
    {
        var paciente = new clsPaciente
        {
            nombre = "Paciente",
            apellido_paterno = "Prueba",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1990, 1, 1),
            telefono_principal = "555000777",
            telefono_secundario = "555000778",
            email = $"paciente_cita_{Guid.NewGuid():N}@test.com",
            calle = "Calle Cita",
            colonia = "Colonia Cita",
            numero = "777",
            localidad = "Localidad Cita",
            id_municipio = 1,
            alergias = "Ninguna",
            notas_medicas = "Prueba cita"
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        paciente.id_paciente = clsPacienteDAL.Insertar(paciente, transaccion);
        transaccion.Commit();
        return paciente;
    }

    private static clsEmpleado CrearDoctorPrueba()
    {
        var empleado = new clsEmpleado
        {
            nombre = "Doctor",
            apellido_paterno = "Prueba",
            apellido_materno = "DAL",
            fecha_nacimiento = new DateTime(1975, 6, 6),
            curp = $"CURP{Guid.NewGuid():N}".Substring(0, 18),
            email = $"doctor_cita_{Guid.NewGuid():N}@test.com",
            telefono_principal = "555000888",
            telefono_secundario = "555000889",
            tipo_empleado = "doctor",
            fecha_contratacion = DateTime.Today,
            estado = true,
            id_usuario = null
        };

        var doctor = new clsDoctor
        {
            nombre = empleado.nombre,
            apellido_paterno = empleado.apellido_paterno,
            apellido_materno = empleado.apellido_materno,
            fecha_nacimiento = empleado.fecha_nacimiento,
            curp = empleado.curp,
            email = empleado.email,
            telefono_principal = empleado.telefono_principal,
            telefono_secundario = empleado.telefono_secundario,
            tipo_empleado = empleado.tipo_empleado,
            fecha_contratacion = empleado.fecha_contratacion,
            estado = empleado.estado,
            id_usuario = empleado.id_usuario,
            cedula_profesional = $"CED{Guid.NewGuid():N}".Substring(0, 12),
            especialidad_principal = ObtenerPrimeraEspecialidadId(),
            consultorio = "Consultorio 2"
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        empleado.id_empleado = clsEmpleadoDAL.Insertar(empleado, transaccion);
        doctor.id_empleado = empleado.id_empleado;
        clsDoctorDAL.Insertar(doctor, transaccion);
        transaccion.Commit();
        return empleado;
    }

    private static void LimpiarDoctorYPaciente(int idEmpleado, int idPaciente)
    {
        clsConexion.EjecutarNonQuery("DELETE FROM DOCTOR WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
        clsConexion.EjecutarNonQuery("DELETE FROM EMPLEADO WHERE id_empleado = @id", new[] { new MySqlParameter("@id", idEmpleado) });
        clsConexion.EjecutarNonQuery("DELETE FROM PACIENTE WHERE id_paciente = @id", new[] { new MySqlParameter("@id", idPaciente) });
    }
}
