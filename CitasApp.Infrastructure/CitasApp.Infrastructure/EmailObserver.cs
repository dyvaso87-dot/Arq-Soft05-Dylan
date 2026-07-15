using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure
{
    public class EmailObserver : ICitaObserver
    {
        public void Notificar(Cita cita)
        {
            Console.WriteLine($"[EMAIL] Cita confirmada para paciente {cita.PacienteId} el {cita.Fecha}");
        }
    }
}