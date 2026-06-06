using CitasApp.Interfaces;
using CitasApp.Models;
using System.Text.Json;

namespace CitasApp.Repositories
{
    public class JsonMedicoRepository : IMedicoRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonMedicoRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "Data", "medicos.json");
        }

        private List<Medico> Leer()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Medico>>(json, _options) ?? new();
        }

        private void Guardar(List<Medico> lista)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
            File.WriteAllText(_path, JsonSerializer.Serialize(lista, _options));
        }

        public List<Medico> ObtenerTodos() => Leer();

        public Medico? ObtenerPorId(int id) => Leer().FirstOrDefault(m => m.Id == id);

        public void Agregar(Medico medico)
        {
            var lista = Leer();
            medico.Id = lista.Any() ? lista.Max(m => m.Id) + 1 : 1;
            lista.Add(medico);
            Guardar(lista);
        }

        public void Actualizar(Medico medico)
        {
            var lista = Leer();
            var existing = lista.FirstOrDefault(m => m.Id == medico.Id);
            if (existing == null) return;
            existing.Nombre = medico.Nombre;
            existing.Apellido = medico.Apellido;
            existing.Especialidad = medico.Especialidad;
            existing.NumeroLicencia = medico.NumeroLicencia;
            Guardar(lista);
        }

        public void Eliminar(int id)
        {
            var lista = Leer();
            var medico = lista.FirstOrDefault(m => m.Id == id);
            if (medico != null) { lista.Remove(medico); Guardar(lista); }
        }
    }
}