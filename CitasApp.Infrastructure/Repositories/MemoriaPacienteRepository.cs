using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories
{
    public class MemoriaPacienteRepository : IPacienteRepository
    {
        private static readonly List<Paciente> _pacientes = new List<Paciente>
        {
            new Paciente { Id = 1, Nombre = "Paciente", Apellido = "Produccion 1", Email = "prod1@citas.com" },
            new Paciente { Id = 2, Nombre = "Paciente", Apellido = "Produccion 2", Email = "prod2@citas.com" }
        };

        private static int _nextId = 3;

        public List<Paciente> ObtenerTodos()
        {
            return _pacientes;
        }

        public Paciente? ObtenerPorId(int id)
        {
            return _pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void Guardar(Paciente paciente)
        {
            if (paciente.Id == 0)
            {
                paciente.Id = _nextId++;
            }
            _pacientes.Add(paciente);
        }

        public void Agregar(Paciente paciente)
        {
            Guardar(paciente);
        }

        public void Actualizar(Paciente paciente)
        {
            var existente = _pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (existente != null)
            {
                existente.Nombre = paciente.Nombre;
                existente.Apellido = paciente.Apellido;
                existente.Email = paciente.Email;
                existente.Telefono = paciente.Telefono;
            }
        }

        public void Eliminar(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
                _pacientes.Remove(paciente);
        }
    }
}