using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces
{
    public interface IPacienteService
    {
        List<Paciente> ObtenerTodos();
        Paciente? ObtenerPorId(int id);
        void Agregar(Paciente paciente);
    }
}