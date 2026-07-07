using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories
{
    public class LoggingPacienteRepository : IPacienteRepository
    {
        private readonly IPacienteRepository _repositoryDecorado;

        public LoggingPacienteRepository(IPacienteRepository repositoryDecorado)
        {
            _repositoryDecorado = repositoryDecorado;
        }

        public List<Paciente> ObtenerTodos()
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] ObtenerTodos — inicio");

            var resultado = _repositoryDecorado.ObtenerTodos();

            fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] ObtenerTodos — {resultado.Count} registros");

            return resultado;
        }

        public Paciente? ObtenerPorId(int id)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] ObtenerPorId — id: {id}");
            return _repositoryDecorado.ObtenerPorId(id);
        }

        public void Agregar(Paciente paciente)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] Agregar — inicio para paciente: {paciente.Nombre}");
            _repositoryDecorado.Agregar(paciente);
            fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] Agregar — éxito");
        }

        public void Actualizar(Paciente paciente)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] Actualizar — inicio para paciente: {paciente.Nombre}");
            _repositoryDecorado.Actualizar(paciente);
            fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] Actualizar — éxito");
        }

        public void Eliminar(int id)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] Eliminar — id: {id}");
            _repositoryDecorado.Eliminar(id);
            fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{fechaHora}] Eliminar — éxito");
        }
    }
}