using CitasApp.Interfaces;
using CitasApp.Models;
using System.Text.Json;

namespace CitasApp.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonCitaRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "Data", "citas.json");
        }

        private List<Cita> Leer()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Cita>>(json, _options) ?? new();
        }

        private void Guardar(List<Cita> lista)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
            File.WriteAllText(_path, JsonSerializer.Serialize(lista, _options));
        }

        public List<Cita> ObtenerTodos() => Leer();

        public Cita? ObtenerPorId(int id) => Leer().FirstOrDefault(c => c.Id == id);

        public List<Cita> ObtenerPorPaciente(int pacienteId) =>
            Leer().Where(c => c.PacienteId == pacienteId).ToList();

        public void Agregar(Cita cita)
        {
            var lista = Leer();
            cita.Id = lista.Any() ? lista.Max(c => c.Id) + 1 : 1;
            lista.Add(cita);
            Guardar(lista);
        }

        public void Actualizar(Cita cita)
        {
            var lista = Leer();
            var existing = lista.FirstOrDefault(c => c.Id == cita.Id);
            if (existing == null) return;
            existing.PacienteId = cita.PacienteId;
            existing.MedicoId = cita.MedicoId;
            existing.Fecha = cita.Fecha;
            existing.Hora = cita.Hora;
            existing.Motivo = cita.Motivo;
            existing.Estado = cita.Estado;
            Guardar(lista);
        }

        public void Eliminar(int id)
        {
            var lista = Leer();
            var cita = lista.FirstOrDefault(c => c.Id == id);
            if (cita != null) { lista.Remove(cita); Guardar(lista); }
        }
    }
}