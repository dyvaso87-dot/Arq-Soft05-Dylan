using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class PacienteController : Controller
    {
        private static List<Paciente> _pacientes = new()
        {
            new Paciente { Id = 1, Nombre = "Ana",   Apellido = "García",   Email = "ana@mail.com",   Telefono = "555-0001" },
            new Paciente { Id = 2, Nombre = "Luis",  Apellido = "Martínez", Email = "luis@mail.com",  Telefono = "555-0002" },
            new Paciente { Id = 3, Nombre = "María", Apellido = "López",    Email = "maria@mail.com", Telefono = "555-0003" },
        };

        public IActionResult Index() => View(_pacientes);

        public IActionResult Detalle(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            return paciente == null ? NotFound() : View(paciente);
        }

        // GET: Crear
        public IActionResult Crear() => View(new Paciente());

        // POST: Crear
        [HttpPost]
        public IActionResult Crear(Paciente paciente)
        {
            paciente.Id = _pacientes.Any() ? _pacientes.Max(p => p.Id) + 1 : 1;
            _pacientes.Add(paciente);
            return RedirectToAction("Index");
        }

        // GET: Editar
        public IActionResult Editar(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            return paciente == null ? NotFound() : View(paciente);
        }

        // POST: Editar
        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            var existing = _pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (existing == null) return NotFound();
            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.Email = paciente.Email;
            existing.Telefono = paciente.Telefono;
            return RedirectToAction("Index");
        }

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null) _pacientes.Remove(paciente);
            return RedirectToAction("Index");
        }
    }
}