using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        List<Paciente> ObtenerTodos();
        Paciente? ObtenerPorId(int id);
        void Agregar(Paciente paciente);
        void Actualizar(Paciente paciente);
        void Eliminar(int id);
    }
}