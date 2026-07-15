using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces
{
    public interface IMedicoService
    {
        List<Medico> ObtenerTodos();
        Medico? ObtenerPorId(int id);
        void Agregar(Medico medico);
    }
}