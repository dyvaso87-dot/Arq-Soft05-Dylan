# CitasApp

App de citas médicas construida con ASP.NET Core MVC (.NET 8).

## Patrones de Diseño (GOF)

El proyecto aplica tres patrones de diseño clásicos del catálogo GOF:

### Factory Method
`RepositoryFactory` decide en tiempo de ejecución qué implementación de `IPacienteRepository` entregar según el entorno:
- **Development** → `JsonPacienteRepository` (persiste en archivos JSON)
- **Production** → `MemoriaPacienteRepository` (datos en memoria)

Esto evita que el código cliente dependa de una clase concreta.

### Decorator
`LoggingPacienteRepository` envuelve cualquier `IPacienteRepository` y le agrega logging con timestamp antes/después de cada operación, sin modificar ni heredar de la implementación original.

### Observer
`CitaService` mantiene una lista de `ICitaObserver` y los notifica automáticamente cuando se agrega una nueva cita. `EmailObserver` y `SmsObserver` son observadores concretos que reaccionan a ese evento sin que `CitaService` conozca los detalles de cada canal de notificación.

## Diagrama de Clases

A continuación se muestra el diagrama de clases del proyecto, incluyendo las capas (Domain, Application, Infrastructure) y los tres patrones descritos arriba:



## Entidades
- **Paciente** — lista y detalle de pacientes registrados
- **Médico** — lista y detalle de médicos disponibles
- **Cita** — agenda completa y filtro por paciente

## Datos
En memoria. Sin base de datos.

## Navegación
Escribe manualmente en la barra del navegador:
- `/Paciente` — lista de pacientes
- `/Medico` — lista de médicos
- `/Cita` — agenda completa
- `/Cita/PorPaciente?pacienteId=1` — citas de un paciente específico

## Requisitos
- .NET 8.0
- Visual Studio 2022

- `GET /api/medicos/{id}` — detalle de un médico
- `GET /api/citas` — agenda completa
- `GET /api/citas/porpaciente/{pacienteId}` — citas de un paciente
- `POST /api/citas/confirmar/{citaId}` — confirma una cita y dispara notificaciones

## Navegación Web (MVC)
- `/Paciente` — lista de pacientes

- **Factory** (`RepositoryFactory`) — selecciona el repositorio según el entorno (Development → JSON, Production → Memoria)
- **Decorator** (`LoggingPacienteRepository`) — agrega logging con timestamp sin modificar el repositorio original
- **Observer** (`SmsObserver`, `EmailObserver`) — notifican automáticamente al confirmar una cita sin acoplar CitaService a los canales de notificación

## Requisitos
- .NET 10.0 

## Clausula de IA

Declaro que este proyecto fue creado por cuestiones academicas y de aprendizaje, utilizando herramientas de inteligencia artificial para darme una guia de como agregar ciertos requisitos que solicito el profesor para este proyecto.