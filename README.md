# CitasApp

App de citas médicas construida con ASP.NET Core MVC (.NET 8).

## Arquitectura

Este proyecto se estaba desarrollando con una arquitectura MVC tradicional, pero se decidió cambiar a una arquitectura Hexagonal.
Hexagonal (Ports & Adapters) dividida en tres proyectos:

- **CitasApp.Domain** — modelos e interfaces (sin dependencias externas)
- **CitasApp.Infrastructure** — repositorios JSON (implementa las interfaces del Domain)
- **CitasApp.Web** — controllers, views y configuración (MVC)


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

## Clausula de IA

Declaro que este proyecto fue creado por cuestiones academicas y de aprendizaje, utilizando herramientas de inteligencia artificial para darme una guia de como agregar ciertos requisitos que solicito el profesor para este proyecto.