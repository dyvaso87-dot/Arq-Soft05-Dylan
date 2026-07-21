using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Application.Services
{
    public class CitaService
    {
        private readonly ICitaRepository _repo;
        private readonly List<ICitaObserver> _observers = new();

        public CitaService(ICitaRepository repo)
        {
            _repo = repo;
        }

        public void AgregarObserver(ICitaObserver observer)
        {
            _observers.Add(observer);
        }

        public List<Cita> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            return _repo.ObtenerPorPaciente(pacienteId);
        }

        public void Agregar(Cita cita)
        {
            _repo.Agregar(cita);

            foreach (var observer in _observers)
                observer.Notificar(cita);
        }
    }
}