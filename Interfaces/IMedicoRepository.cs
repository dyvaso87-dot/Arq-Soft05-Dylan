using CitasApp.Models;

namespace CitasApp.Interfaces
{
    public interface IMedicoRepository
    {
        List<Medico> ObtenerTodos();
        Medico? ObtenerPorId(int id);
        void Agregar(Medico medico);
        void Actualizar(Medico medico);
        void Eliminar(int id);
    }
}