using System.Data;
using MedicDate.CapaDatos;
using MedicDate.CapaNegocio;
using MySql.Data.MySqlClient;

namespace PruebasIntegracionFinal;

internal static class Program
{
    private static int Main()
    {
        try
        {
            EjecutarPruebaCommit();
            EjecutarPruebaRollback();
            Console.WriteLine("Pruebas finalizadas correctamente.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error en las pruebas: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
            return 1;
        }
    }

    private static void EjecutarPruebaCommit()
    {
        string suffix = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string usuario = $"user{suffix}";
        string email = $"test{suffix}@mail.com";
        string cedula = $"CED{suffix}";
        string motivo = $"motivo-{suffix}";

        using MySqlConnection conexion = clsConexion.ObtenerConexion();
        using MySqlTransaction transaccion = conexion.BeginTransaction();

        try
        {
            int idRol = ObtenerPrimerRolId(transaccion);

            var usuarioNuevo = new clsUsuario
            {
                usuario = usuario,
                contrasena = "123456",
                id_rol = idRol,
                activo = true
            };

            if (!clsUsuarioDAL.CrearUsuario(usuarioNuevo, transaccion))
            {
                throw new Exception("No se pudo insertar el usuario.");
            }

            var paciente = new clsPaciente
            {
                nombre = "Prueba",
                apellido_paterno = "Commit",
                apellido_materno = "Final",
                fecha_nacimiento = new DateTime(1990, 1, 1),
                telefono_principal = "5550000000",
                telefono_secundario = "5550000001",
                email = email,
                calle = "Calle Test",
                colonia = "Colonia Test",
                numero = "100",
                localidad = "Localidad Test",
                id_municipio = null,
                alergias = "Ninguna",
                notas_medicas = "Prueba de commit"
            };

            int idPaciente = clsPacienteDAL.Insertar(paciente, transaccion);
            if (idPaciente <= 0)
            {
                throw new Exception("No se pudo insertar el paciente.");
            }

            var empleadoDoctor = new clsEmpleado
            {
                nombre = "Empleado",
                apellido_paterno = "Commit",
                apellido_materno = "Final",
                fecha_nacimiento = new DateTime(1985, 2, 2),
                curp = $"CURP{suffix}",
                email = $"empleado{suffix}@mail.com",
                telefono_principal = "5551111111",
                telefono_secundario = "5551111112",
                tipo_empleado = "doctor",
                fecha_contratacion = DateTime.Today,
                estado = true,
                id_usuario = usuarioNuevo.id_usuario
            };

            int idEmpleadoDoctor = clsEmpleadoDAL.Insertar(empleadoDoctor, transaccion);
            if (idEmpleadoDoctor <= 0)
            {
                throw new Exception("No se pudo insertar el empleado doctor.");
            }

            var empleadoAsistente = new clsEmpleado
            {
                nombre = "Asistente",
                apellido_paterno = "Commit",
                apellido_materno = "Final",
                fecha_nacimiento = new DateTime(1986, 3, 3),
                curp = $"CURPA{suffix}",
                email = $"asistente{suffix}@mail.com",
                telefono_principal = "5552222222",
                telefono_secundario = "5552222223",
                tipo_empleado = "asistente",
                fecha_contratacion = DateTime.Today,
                estado = true,
                id_usuario = null
            };

            int idEmpleadoAsistente = clsEmpleadoDAL.Insertar(empleadoAsistente, transaccion);
            if (idEmpleadoAsistente <= 0)
            {
                throw new Exception("No se pudo insertar el empleado asistente.");
            }

            var doctor = new clsDoctor
            {
                id_empleado = idEmpleadoDoctor,
                cedula_profesional = cedula,
                especialidad_principal = null,
                consultorio = "101"
            };

            if (!clsDoctorDAL.Insertar(doctor, transaccion))
            {
                throw new Exception("No se pudo insertar el doctor.");
            }

            var asistente = new clsAsistente
            {
                id_empleado = idEmpleadoAsistente,
                turno = "Matutino"
            };

            if (!clsAsistenteDAL.Insertar(asistente, transaccion))
            {
                throw new Exception("No se pudo insertar el asistente.");
            }

            var cita = new clsCita
            {
                id_paciente = idPaciente,
                id_doctor = idEmpleadoDoctor,
                fecha = DateTime.Today.AddDays(1),
                hora = new TimeSpan(10, 0, 0),
                duracion = 30,
                motivo = motivo,
                estado = "Pendiente",
                costo = 500,
                notas_internas = "Prueba de commit",
                id_registrado_por = null
            };

            int idCita = clsCitaDAL.Insertar(cita, transaccion);
            if (idCita <= 0)
            {
                throw new Exception("No se pudo insertar la cita.");
            }

            transaccion.Commit();

            VerificarRegistro("USUARIO", "usuario", usuario, 1);
            VerificarRegistro("PACIENTE", "email", email, 1);
            VerificarRegistro("EMPLEADO", "email", empleadoDoctor.email, 1);
            VerificarRegistro("DOCTOR", "cedula_profesional", cedula, 1);
            VerificarRegistro("ASISTENTE", "id_empleado", idEmpleadoAsistente.ToString(), 1);
            VerificarRegistro("CITA", "motivo", motivo, 1);

            Console.WriteLine("Prueba de commit completada.");
        }
        catch
        {
            transaccion.Rollback();
            throw;
        }
    }

    private static void EjecutarPruebaRollback()
    {
        string suffix = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string usuario = $"rollback{suffix}";
        string email = $"rollback{suffix}@mail.com";
        string cedula = $"RB{suffix}";
        string motivo = $"rollback-{suffix}";

        using MySqlConnection conexion = clsConexion.ObtenerConexion();
        using MySqlTransaction transaccion = conexion.BeginTransaction();

        try
        {
            int idRol = ObtenerPrimerRolId(transaccion);

            var usuarioNuevo = new clsUsuario
            {
                usuario = usuario,
                contrasena = "123456",
                id_rol = idRol,
                activo = true
            };

            if (!clsUsuarioDAL.CrearUsuario(usuarioNuevo, transaccion))
            {
                throw new Exception("No se pudo insertar el usuario para rollback.");
            }

            var paciente = new clsPaciente
            {
                nombre = "Rollback",
                apellido_paterno = "Final",
                apellido_materno = "Test",
                fecha_nacimiento = new DateTime(1992, 3, 3),
                telefono_principal = "5552222222",
                telefono_secundario = "5552222223",
                email = email,
                calle = "Calle Rollback",
                colonia = "Colonia Rollback",
                numero = "200",
                localidad = "Localidad Rollback",
                id_municipio = null,
                alergias = "Ninguna",
                notas_medicas = "Prueba de rollback"
            };

            int idPaciente = clsPacienteDAL.Insertar(paciente, transaccion);
            if (idPaciente <= 0)
            {
                throw new Exception("No se pudo insertar el paciente para rollback.");
            }

            var empleadoDoctor = new clsEmpleado
            {
                nombre = "Empleado",
                apellido_paterno = "Rollback",
                apellido_materno = "Final",
                fecha_nacimiento = new DateTime(1987, 4, 4),
                curp = $"RB{suffix}",
                email = $"empleadoR{suffix}@mail.com",
                telefono_principal = "5553333333",
                telefono_secundario = "5553333334",
                tipo_empleado = "doctor",
                fecha_contratacion = DateTime.Today,
                estado = true,
                id_usuario = usuarioNuevo.id_usuario
            };

            int idEmpleadoDoctor = clsEmpleadoDAL.Insertar(empleadoDoctor, transaccion);
            if (idEmpleadoDoctor <= 0)
            {
                throw new Exception("No se pudo insertar el empleado para rollback.");
            }

            var empleadoAsistente = new clsEmpleado
            {
                nombre = "Asistente",
                apellido_paterno = "Rollback",
                apellido_materno = "Final",
                fecha_nacimiento = new DateTime(1988, 5, 5),
                curp = $"RBA{suffix}",
                email = $"asistenteR{suffix}@mail.com",
                telefono_principal = "5554444444",
                telefono_secundario = "5554444445",
                tipo_empleado = "asistente",
                fecha_contratacion = DateTime.Today,
                estado = true,
                id_usuario = null
            };

            int idEmpleadoAsistente = clsEmpleadoDAL.Insertar(empleadoAsistente, transaccion);
            if (idEmpleadoAsistente <= 0)
            {
                throw new Exception("No se pudo insertar el empleado asistente para rollback.");
            }

            var doctor = new clsDoctor
            {
                id_empleado = idEmpleadoDoctor,
                cedula_profesional = cedula,
                especialidad_principal = null,
                consultorio = "202"
            };

            if (!clsDoctorDAL.Insertar(doctor, transaccion))
            {
                throw new Exception("No se pudo insertar el doctor para rollback.");
            }

            var asistente = new clsAsistente
            {
                id_empleado = idEmpleadoAsistente,
                turno = "Vespertino"
            };

            if (!clsAsistenteDAL.Insertar(asistente, transaccion))
            {
                throw new Exception("No se pudo insertar el asistente para rollback.");
            }

            var cita = new clsCita
            {
                id_paciente = idPaciente,
                id_doctor = idEmpleadoDoctor,
                fecha = DateTime.Today.AddDays(2),
                hora = new TimeSpan(14, 0, 0),
                duracion = 45,
                motivo = motivo,
                estado = "Pendiente",
                costo = 700,
                notas_internas = "Prueba de rollback",
                id_registrado_por = null
            };

            int idCita = clsCitaDAL.Insertar(cita, transaccion);
            if (idCita <= 0)
            {
                throw new Exception("No se pudo insertar la cita para rollback.");
            }

            transaccion.Rollback();

            VerificarRegistro("USUARIO", "usuario", usuario, 0);
            VerificarRegistro("PACIENTE", "email", email, 0);
            VerificarRegistro("EMPLEADO", "email", empleadoDoctor.email, 0);
            VerificarRegistro("DOCTOR", "cedula_profesional", cedula, 0);
            VerificarRegistro("ASISTENTE", "id_empleado", idEmpleadoAsistente.ToString(), 0);
            VerificarRegistro("CITA", "motivo", motivo, 0);

            Console.WriteLine("Prueba de rollback completada.");
        }
        catch
        {
            transaccion.Rollback();
            throw;
        }
    }

    private static int ObtenerPrimerRolId(MySqlTransaction transaccion)
    {
        DataTable resultado = clsConexion.EjecutarConsulta("SELECT id_rol FROM ROL LIMIT 1", null, transaccion);
        if (resultado.Rows.Count == 0)
        {
            throw new Exception("No hay roles registrados para usar en las pruebas.");
        }

        return Convert.ToInt32(resultado.Rows[0]["id_rol"]);
    }

    private static void VerificarRegistro(string tabla, string columna, string valor, int esperado)
    {
        string consulta = $"SELECT COUNT(*) FROM {tabla} WHERE {columna} = @valor";
        MySqlParameter[] parametros = { new MySqlParameter("@valor", valor) };
        object resultado = clsConexion.EjecutarScalar(consulta, parametros);
        int cuenta = Convert.ToInt32(resultado);

        if (cuenta != esperado)
        {
            throw new Exception($"La verificación de {tabla}.{columna} esperó {esperado} registro(s) pero encontró {cuenta}.");
        }
    }
}
