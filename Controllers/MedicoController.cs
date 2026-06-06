using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private static List<Medico> _medicos = new()
        {
            new Medico { Id = 1, Nombre = "Carlos",   Apellido = "Reyes",   Especialidad = "Medicina General", NumeroLicencia = "MG-10421" },
            new Medico { Id = 2, Nombre = "Patricia", Apellido = "Vega",    Especialidad = "Pediatría",        NumeroLicencia = "PD-20835" },
            new Medico { Id = 3, Nombre = "Roberto",  Apellido = "Sánchez", Especialidad = "Cardiología",      NumeroLicencia = "CA-30117" },
        };

        public IActionResult Index() => View(_medicos);

        public IActionResult Detalle(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            return medico == null ? NotFound() : View(medico);
        }

        // GET: Crear
        public IActionResult Crear() => View(new Medico());

        // POST: Crear
        [HttpPost]
        public IActionResult Crear(Medico medico)
        {
            medico.Id = _medicos.Any() ? _medicos.Max(m => m.Id) + 1 : 1;
            _medicos.Add(medico);
            return RedirectToAction("Index");
        }

        // GET: Editar
        public IActionResult Editar(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            return medico == null ? NotFound() : View(medico);
        }

        // POST: Editar
        [HttpPost]
        public IActionResult Editar(Medico medico)
        {
            var existing = _medicos.FirstOrDefault(m => m.Id == medico.Id);
            if (existing == null) return NotFound();
            existing.Nombre = medico.Nombre;
            existing.Apellido = medico.Apellido;
            existing.Especialidad = medico.Especialidad;
            existing.NumeroLicencia = medico.NumeroLicencia;
            return RedirectToAction("Index");
        }

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            if (medico != null) _medicos.Remove(medico);
            return RedirectToAction("Index");
        }
    }
}