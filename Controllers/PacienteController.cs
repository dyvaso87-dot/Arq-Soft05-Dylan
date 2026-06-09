using CitasApp.CitasApp.Domian.Interfaces;
using CitasApp.CitasApp.Domian.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Web.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _repo;
        public PacienteController(IPacienteRepository repo) { _repo = repo; }

        public IActionResult Index() => View(_repo.ObtenerTodos());

        public IActionResult Detalle(int id)
        {
            var paciente = _repo.ObtenerPorId(id);
            return paciente == null ? NotFound() : View(paciente);
        }

        public IActionResult Crear() => View(new Paciente());

        [HttpPost]
        public IActionResult Crear(Paciente paciente)
        {
            _repo.Agregar(paciente);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var paciente = _repo.ObtenerPorId(id);
            return paciente == null ? NotFound() : View(paciente);
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            _repo.Actualizar(paciente);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}