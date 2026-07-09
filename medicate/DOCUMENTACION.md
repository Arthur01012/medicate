# Documentación del proyecto MedicDate

## 1. Información general

MedicDate es una aplicación de escritorio desarrollada en C# con Windows Forms, orientada a la gestión de pacientes, médicos, asistentes, citas y usuarios del sistema.

- Tecnologías principales: .NET 8, Windows Forms, MySQL, MySqlConnector
- Arquitectura: capas por responsabilidad
- Base de datos: MySQL local configurada mediante [App.config](App.config)

## 2. Estructura del proyecto

- [CapaPresentacion](CapaPresentacion): formularios de login, registro, administración y agendas.
- [CapaNegocio](CapaNegocio): clases de negocio como usuarios, pacientes, empleados, doctores, citas y horarios.
- [CapaDatos](CapaDatos): acceso a datos y operaciones transaccionales con MySQL.
- [Helpers](Helpers): utilidades para validaciones y encriptación.

## 3. Estado actual del sistema

### Funcionalidades implementadas o validadas

- Autenticación de usuarios en el login.
- Registro de pacientes.
- Registro de asistentes y doctores.
- Gestión de citas y agendas.
- Inserciones transaccionales en la base de datos.
- Validación de commit y rollback mediante pruebas de integración.

### Componentes clave

- [CapaDatos/clsConexion.cs](CapaDatos/clsConexion.cs): conexión centralizada y ejecución de consultas.
- [CapaDatos/clsUsuarioDAL.cs](CapaDatos/clsUsuarioDAL.cs): autenticación y creación de usuarios.
- [CapaDatos/clsPacienteDAL.cs](CapaDatos/clsPacienteDAL.cs): inserción de pacientes.
- [CapaDatos/clsEmpleadoDAL.cs](CapaDatos/clsEmpleadoDAL.cs): inserción de empleados.
- [CapaDatos/clsDoctorDAL.cs](CapaDatos/clsDoctorDAL.cs): inserción de doctores.
- [CapaDatos/clsAsistenteDAL.cs](CapaDatos/clsAsistenteDAL.cs): inserción de asistentes.
- [CapaDatos/clsCitaDAL.cs](CapaDatos/clsCitaDAL.cs): inserción y gestión de citas.
- [CapaPresentacion/frmLogin.cs](CapaPresentacion/frmLogin.cs): flujo de autenticación.
- [PruebasIntegracionFinal/Program.cs](PruebasIntegracionFinal/Program.cs): pruebas de integración final para commit y rollback.

## 4. Manejo de base de datos

La aplicación usa una conexión a MySQL con transacciones para garantizar consistencia en operaciones multi-tabla.

### Tablas involucradas en las pruebas finales

- USUARIO
- PACIENTE
- EMPLEADO
- DOCTOR
- ASISTENTE
- CITA

## 5. Pruebas realizadas

### Prueba de compilación

Se verificó que el proyecto principal compila correctamente con:

```powershell
dotnet build .\medicate.csproj
```

Resultado: compilación exitosa, con advertencias de nulabilidad y algunas advertencias del código existente.

### Prueba de integración final

Se ejecutó el runner de pruebas finales con:

```powershell
dotnet run --project .\PruebasIntegracionFinal\PruebasIntegracionFinal.csproj
```

Resultado observado:

- Prueba de commit completada.
- Prueba de rollback completada.
- Pruebas finalizadas correctamente.

### Datos enviados durante las pruebas

#### Escenario de commit

- Usuario: usuario generado dinámicamente con sufijo temporal.
- Contraseña: 123456.
- Rol: primer rol encontrado en la tabla ROL.
- Paciente: datos de prueba con nombre, apellidos, correo y dirección ficticios.
- Empleado doctor: datos de prueba con CURP, correo y tipo empleado.
- Empleado asistente: datos de prueba con CURP, correo y tipo empleado.
- Doctor: datos con cédula profesional y consultorio.
- Asistente: turno asignado.
- Cita: fecha, hora, motivo y costo de prueba.

#### Escenario de rollback

- Se enviaron datos similares, pero con valores diferenciados para verificar que el rollback elimine toda la operación.

## 6. Observaciones importantes

- El flujo transaccional funciona correctamente.
- Las operaciones de commit y rollback quedan validadas contra la base de datos real.
- El proyecto quedó preparado para seguir con la integración de formularios y validaciones de negocio adicionales.

## 7. Recomendaciones

### Seguridad

- Eliminar el uso de texto plano para contraseñas y usar algoritmos modernos como Argon2id, bcrypt o scrypt.
- Mover la cadena de conexión a variables de entorno o un gestor de secretos.
- Mejorar las validaciones de entrada en formularios.
- Implementar logs de auditoría para cambios sensibles.

### Calidad y mantenimiento

- Añadir pruebas automatizadas para login fallido, duplicidad de correo y errores de negocio.
- Separar aún más la lógica de negocio de la capa de acceso a datos.
- Mantener un entorno de pruebas independiente del entorno productivo.

## 8. Riesgos y vulnerabilidades potenciales

- Uso de contraseñas con enfoque inseguro o fallback a texto plano.
- Manejo de credenciales sensibles en configuración local.
- Falta de validación estricta en algunos formularios.
- Posible exposición de mensajes de error demasiado detallados.

## 9. Siguientes pasos recomendados

1. Fortalecer el sistema de autenticación y cifrado.
2. Completar la integración de formularios con validaciones reales.
3. Añadir pruebas automáticas y manejo de excepciones más robusto.
4. Preparar una versión más segura para despliegue o validación adicional.
