using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces
{
    public interface ICitaService
    {
        List<Cita> ObtenerTodos();
        List<Cita> ObtenerPorPaciente(int pacienteId);
        void Agregar(Cita cita);
        void AgregarObserver(ICitaObserver observer);
    }
}