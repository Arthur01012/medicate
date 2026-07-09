# Documentación completa del proyecto MedicDate

## 1. Introducción

MedicDate es una aplicación de escritorio desarrollada en C# con Windows Forms para la gestión clínica y administrativa de una clínica o consultorio médico. El sistema permite administrar usuarios, pacientes, empleados, doctores, asistentes y citas, además de validar operaciones críticas mediante transacciones de base de datos.

El proyecto sigue una arquitectura por capas para separar la interfaz de usuario, la lógica de negocio y el acceso a datos.

## 2. Objetivo del sistema

El objetivo principal del sistema es centralizar y automatizar procesos de gestión médica básicos, tales como:

- Registro y autenticación de usuarios.
- Gestión de pacientes.
- Gestión de personal médico y administrativo.
- Registro de citas médicas.
- Validación de integridad de datos mediante transacciones.

## 3. Tecnologías utilizadas

- Lenguaje: C#
- Framework de interfaz: Windows Forms
- Plataforma: .NET 8
- Base de datos: MySQL
- Conectores: MySql.Data y MySqlConnector
- Herramienta de ejecución: dotnet

## 4. Arquitectura del proyecto

El proyecto está organizado en capas:

### 4.1 Capa de presentación
Ubicada en [CapaPresentacion](CapaPresentacion).

Contiene los formularios de la aplicación, entre ellos:

- [CapaPresentacion/frmLogin.cs](CapaPresentacion/frmLogin.cs): inicio de sesión.
- [CapaPresentacion/frmRegistroPaciente.cs](CapaPresentacion/frmRegistroPaciente.cs): registro de pacientes.
- [CapaPresentacion/frmRegistroDoctor.cs](CapaPresentacion/frmRegistroDoctor.cs): registro de doctores.
- [CapaPresentacion/frmRegistroAsistente.cs](CapaPresentacion/frmRegistroAsistente.cs): registro de asistentes.
- [CapaPresentacion/frmNuevaCita.cs](CapaPresentacion/frmNuevaCita.cs): creación de citas.
- [CapaPresentacion/frmAdministrador.cs](CapaPresentacion/frmAdministrador.cs): panel administrativo.
- [CapaPresentacion/frmAgendaMedico.cs](CapaPresentacion/frmAgendaMedico.cs): agenda médica.
- [CapaPresentacion/frmAgendaAsistente.cs](CapaPresentacion/frmAgendaAsistente.cs): agenda de asistente.

### 4.2 Capa de negocio
Ubicada en [CapaNegocio](CapaNegocio).

Aquí se definen las clases que representan entidades del sistema, por ejemplo:

- [CapaNegocio/clsUsuario.cs](CapaNegocio/clsUsuario.cs)
- [CapaNegocio/clsPaciente.cs](CapaNegocio/clsPaciente.cs)
- [CapaNegocio/clsEmpleado.cs](CapaNegocio/clsEmpleado.cs)
- [CapaNegocio/clsDoctor.cs](CapaNegocio/clsDoctor.cs)
- [CapaNegocio/clsAsistente.cs](CapaNegocio/clsAsistente.cs)
- [CapaNegocio/clsCita.cs](CapaNegocio/clsCita.cs)
- [CapaNegocio/clsHorario.cs](CapaNegocio/clsHorario.cs)
- [CapaNegocio/clsEspecialidad.cs](CapaNegocio/clsEspecialidad.cs)
- [CapaNegocio/clsMunicipio.cs](CapaNegocio/clsMunicipio.cs)

### 4.3 Capa de datos
Ubicada en [CapaDatos](CapaDatos).

Contiene la lógica de acceso a la base de datos y las operaciones transaccionales. Los archivos clave son:

- [CapaDatos/clsConexion.cs](CapaDatos/clsConexion.cs): creación de conexiones y ejecución de consultas.
- [CapaDatos/clsUsuarioDAL.cs](CapaDatos/clsUsuarioDAL.cs): autenticación y creación de usuarios.
- [CapaDatos/clsPacienteDAL.cs](CapaDatos/clsPacienteDAL.cs): inserción de pacientes.
- [CapaDatos/clsEmpleadoDAL.cs](CapaDatos/clsEmpleadoDAL.cs): inserción y lectura de empleados.
- [CapaDatos/clsDoctorDAL.cs](CapaDatos/clsDoctorDAL.cs): inserción de doctores.
- [CapaDatos/clsAsistenteDAL.cs](CapaDatos/clsAsistenteDAL.cs): inserción de asistentes.
- [CapaDatos/clsCitaDAL.cs](CapaDatos/clsCitaDAL.cs): inserción y gestión de citas.

### 4.4 Helpers
Ubicada en [Helpers](Helpers).

Incluye componentes auxiliares como:

- [Helpers/clsEncriptacion.cs](Helpers/clsEncriptacion.cs): funciones de cifrado y manejo de credenciales.
- [Helpers/clsValidaciones.cs](Helpers/clsValidaciones.cs): reglas de validación reutilizables.

## 5. Configuración de la base de datos

La conexión a MySQL se configura en [App.config](App.config).

La aplicación trabaja contra una base de datos local o de desarrollo, donde se almacenan los registros de usuarios, pacientes, empleados y citas.

## 6. Funcionalidades implementadas

### 6.1 Autenticación de usuarios
Se implementó un flujo de login que valida credenciales de usuario contra la base de datos.

### 6.2 Registro de pacientes
Permite capturar datos del paciente y persistirlos en la base de datos.

### 6.3 Registro de doctores y asistentes
Se completó la lógica para almacenarlos con sus respectivos datos y relación con empleados.

### 6.4 Gestión de citas
Se añadió la lógica de registro y manejo de citas, incluyendo fecha, hora, estado y médico asociado.

### 6.5 Transacciones y consistencia
El sistema usa transacciones para asegurar que operaciones multi-tabla se completen o reviertan por completo en caso de fallar.

## 7. Pruebas realizadas

### 7.1 Prueba de compilación
Se validó que el proyecto compile correctamente mediante:

```powershell
dotnet build .\medicate.csproj
```

Resultado: compilación exitosa con advertencias de nulabilidad y algunas advertencias históricas del código.

### 7.2 Prueba de integración final
Se ejecutó una prueba integral para validar el comportamiento real de las operaciones transaccionales con la base de datos.

Comando ejecutado:

```powershell
dotnet run --project .\PruebasIntegracionFinal\PruebasIntegracionFinal.csproj
```

Resultado observado:

- Prueba de commit completada.
- Prueba de rollback completada.
- Pruebas finalizadas correctamente.

### 7.3 Alcance de las pruebas
Las pruebas afectaron las tablas:

- USUARIO
- PACIENTE
- EMPLEADO
- DOCTOR
- ASISTENTE
- CITA

## 8. Datos utilizados durante las pruebas

Durante las pruebas se ingresaron datos ficticios generados dinámicamente para evitar conflictos con registros existentes.

### Escenario de commit
Se insertaron datos para:

- Un usuario nuevo.
- Un paciente nuevo.
- Un empleado tipo doctor.
- Un empleado tipo asistente.
- Un doctor asociado al empleado doctor.
- Un asistente asociado al empleado asistente.
- Una cita nueva.

### Escenario de rollback
Se ejecutó un flujo similar, pero al terminar la transacción se aplicó rollback para verificar que los registros no quedaran persistidos.

## 9. Observaciones técnicas

- El flujo transaccional está funcionando correctamente.
- La capa de datos se comporta adecuadamente frente a operaciones complejas.
- El proyecto se encuentra en una etapa funcional de validación y desarrollo intermedio.
- Se recomienda continuar con la integración de formularios y mejoras de seguridad.

## 10. Riesgos y recomendaciones

### 10.1 Riesgos de seguridad

- El manejo de contraseñas debe reforzarse.
- La cadena de conexión debe protegerse mejor.
- Es recomendable implementar hash moderno para contraseñas.
- Se debe evitar almacenar secretos en texto plano en archivos de configuración.

### 10.2 Recomendaciones de calidad

- Implementar validaciones más estrictas en formularios.
- Añadir logs de auditoría.
- Crear pruebas automatizadas para casos de error y validación.
- Separar aún más la lógica de negocio de las operaciones de acceso a datos.

## 11. Estado actual del proyecto

El proyecto se encuentra en una fase funcional donde:

- La base de datos ya responde a operaciones reales.
- El flujo de autenticación y registro está operando.
- Las pruebas de integración confirmaron el manejo de commit y rollback.
- Faltan mejoras de seguridad, validaciones y consolidación de la interfaz.

## 12. Siguientes pasos recomendados

1. Fortalecer la autenticación y el cifrado de contraseñas.
2. Mejorar validaciones de entrada en todos los formularios.
3. Implementar logs y auditoría.
4. Añadir pruebas automatizadas.
5. Preparar la aplicación para una siguiente fase de integración y despliegue.
