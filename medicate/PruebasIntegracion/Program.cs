using System;
using System.Data;
using MedicDate.CapaDatos;
using MedicDate.CapaNegocio;
using MySql.Data.MySqlClient;

namespace PruebasIntegracion;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iniciando pruebas de integración...");

        ProbarConexion();
        PruebaPacienteCommit();
        PruebaPacienteRollback();
        PruebaUsuarioCommit();
        PruebaEmpleadoCommit();
        PruebaDoctorAsistenteCommit();
        PruebaCitaCommit();

        Console.WriteLine("Pruebas finalizadas.");
    }

    static void ProbarConexion()
    {
        try
        {
            using var conn = clsConexion.ObtenerConexion();
            Console.WriteLine($"Conexión OK: {conn.State}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FALLO conexión: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static void PruebaPacienteCommit()
    {
        var paciente = new clsPaciente
        {
            nombre = "Prueba",
            apellido_paterno = "Paciente",
            apellido_materno = "Commit",
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
            notas_medicas = "Prueba commit"
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        var id = clsPacienteDAL.Insertar(paciente, transaccion);
        transaccion.Commit();
        Console.WriteLine($"Paciente commit OK: id={id}");
        clsConexion.EjecutarNonQuery("DELETE FROM PACIENTE WHERE id_paciente=@id", new[] { new MySqlParameter("@id", id) });
    }

    static void PruebaPacienteRollback()
    {
        var paciente = new clsPaciente
        {
            nombre = "Prueba",
            apellido_paterno = "Paciente",
            apellido_materno = "Rollback",
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
            notas_medicas = "Prueba rollback"
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        var id = clsPacienteDAL.Insertar(paciente, transaccion);
        transaccion.Rollback();
        var tabla = clsConexion.EjecutarConsulta("SELECT * FROM PACIENTE WHERE id_paciente=@id", new[] { new MySqlParameter("@id", id) });
        Console.WriteLine($"Paciente rollback OK: filas={tabla.Rows.Count}");
    }

    static void PruebaUsuarioCommit()
    {
        var usuario = new clsUsuario
        {
            usuario = $"usr_{Guid.NewGuid():N}".Substring(0, 12),
            contrasena = "123456",
            id_rol = ObtenerPrimerRolId(),
            activo = true
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        var ok = clsUsuarioDAL.CrearUsuario(usuario, transaccion);
        transaccion.Commit();
        Console.WriteLine($"Usuario commit OK: ok={ok}, id={usuario.id_usuario}");
        clsConexion.EjecutarNonQuery("DELETE FROM USUARIO WHERE id_usuario=@id", new[] { new MySqlParameter("@id", usuario.id_usuario) });
    }

    static void PruebaEmpleadoCommit()
    {
        var empleado = new clsEmpleado
        {
            nombre = "Prueba",
            apellido_paterno = "Empleado",
            apellido_materno = "Commit",
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

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        var id = clsEmpleadoDAL.Insertar(empleado, transaccion);
        transaccion.Commit();
        Console.WriteLine($"Empleado commit OK: id={id}");
        clsConexion.EjecutarNonQuery("DELETE FROM EMPLEADO WHERE id_empleado=@id", new[] { new MySqlParameter("@id", id) });
    }

    static void PruebaDoctorAsistenteCommit()
    {
        var empleado = new clsEmpleado
        {
            nombre = "Prueba",
            apellido_paterno = "DoctorAsistente",
            apellido_materno = "Commit",
            fecha_nacimiento = new DateTime(1988, 8, 8),
            curp = $"CURP{Guid.NewGuid():N}".Substring(0, 18),
            email = $"da_{Guid.NewGuid():N}@test.com",
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
            tipo_empleado = "asistente",
            fecha_contratacion = empleado.fecha_contratacion,
            estado = empleado.estado,
            id_usuario = empleado.id_usuario,
            turno = "Mañana"
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        var idEmpleado = clsEmpleadoDAL.Insertar(empleado, transaccion);
        doctor.id_empleado = idEmpleado;
        asistente.id_empleado = idEmpleado;
        clsDoctorDAL.Insertar(doctor, transaccion);
        clsAsistenteDAL.Insertar(asistente, transaccion);
        transaccion.Commit();
        Console.WriteLine($"Doctor/Asistente commit OK: idEmpleado={idEmpleado}");
        clsConexion.EjecutarNonQuery("DELETE FROM ASISTENTE WHERE id_empleado=@id", new[] { new MySqlParameter("@id", idEmpleado) });
        clsConexion.EjecutarNonQuery("DELETE FROM DOCTOR WHERE id_empleado=@id", new[] { new MySqlParameter("@id", idEmpleado) });
        clsConexion.EjecutarNonQuery("DELETE FROM EMPLEADO WHERE id_empleado=@id", new[] { new MySqlParameter("@id", idEmpleado) });
    }

    static void PruebaCitaCommit()
    {
        var paciente = new clsPaciente
        {
            nombre = "Prueba",
            apellido_paterno = "Cita",
            apellido_materno = "Commit",
            fecha_nacimiento = new DateTime(1991, 3, 3),
            telefono_principal = "555000666",
            telefono_secundario = "555000667",
            email = $"cita_{Guid.NewGuid():N}@test.com",
            calle = "Calle Cita",
            colonia = "Colonia Cita",
            numero = "999",
            localidad = "Localidad Cita",
            id_municipio = 1,
            alergias = "Ninguna",
            notas_medicas = "Prueba cita"
        };

        using var conexion = clsConexion.ObtenerConexion();
        using var transaccion = conexion.BeginTransaction();
        var idPaciente = clsPacienteDAL.Insertar(paciente, transaccion);
        var idDoctor = ObtenerPrimerEmpleadoDoctorId();
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
        var idCita = clsCitaDAL.Insertar(cita, transaccion);
        transaccion.Commit();
        Console.WriteLine($"Cita commit OK: id={idCita}");
        clsConexion.EjecutarNonQuery("DELETE FROM CITA WHERE id_cita=@id", new[] { new MySqlParameter("@id", idCita) });
        clsConexion.EjecutarNonQuery("DELETE FROM PACIENTE WHERE id_paciente=@id", new[] { new MySqlParameter("@id", idPaciente) });
    }

    static int ObtenerPrimerRolId()
    {
        var tabla = clsConexion.EjecutarConsulta("SELECT id_rol FROM ROL ORDER BY id_rol LIMIT 1");
        return Convert.ToInt32(tabla.Rows[0]["id_rol"]);
    }

    static int? ObtenerPrimeraEspecialidadId()
    {
        var tabla = clsConexion.EjecutarConsulta("SELECT id_especialidad FROM ESPECIALIDAD ORDER BY id_especialidad LIMIT 1");
        return tabla.Rows.Count > 0 ? Convert.ToInt32(tabla.Rows[0]["id_especialidad"]) : null;
    }

    static int ObtenerPrimerEmpleadoDoctorId()
    {
        var tabla = clsConexion.EjecutarConsulta("SELECT id_empleado FROM EMPLEADO WHERE tipo_empleado='doctor' ORDER BY id_empleado LIMIT 1");
        if (tabla.Rows.Count == 0)
        {
            throw new InvalidOperationException("No hay empleados tipo doctor registrados para la prueba de cita.");
        }
        return Convert.ToInt32(tabla.Rows[0]["id_empleado"]);
    }
}
