using CitasApp.Interfaces;
using CitasApp.Models;
using System.Text.Json;

namespace CitasApp.Repositories
{
    public class JsonPacienteRepository : IPacienteRepository
    {
        private readonly string _path = "Data/pacientes.json";

        private List<Paciente> Leer()
        {
            if (!File.Exists(_path)) return new List<Paciente>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Paciente>>(json) ?? new List<Paciente>();
        }

        private void Guardar(List<Paciente> lista)
        {
            Directory.CreateDirectory("Data");
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public List<Paciente> ObtenerTodos() => Leer();

        public Paciente? ObtenerPorId(int id) => Leer().FirstOrDefault(p => p.Id == id);

        public void Agregar(Paciente paciente)
        {
            var lista = Leer();
            paciente.Id = lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
            lista.Add(paciente);
            Guardar(lista);
        }

        public void Actualizar(Paciente paciente)
        {
            var lista = Leer();
            var existing = lista.FirstOrDefault(p => p.Id == paciente.Id);
            if (existing == null) return;
            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.Email = paciente.Email;
            existing.Telefono = paciente.Telefono;
            Guardar(lista);
        }

        public void Eliminar(int id)
        {
            var lista = Leer();
            var paciente = lista.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                lista.Remove(paciente);
                Guardar(lista);
            }
        }
    }
}