using CitasApp.Interfaces;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _repo;
        public MedicoController(IMedicoRepository repo) { _repo = repo; }

        public IActionResult Index() => View(_repo.ObtenerTodos());

        public IActionResult Detalle(int id)
        {
            var medico = _repo.ObtenerPorId(id);
            return medico == null ? NotFound() : View(medico);
        }

        public IActionResult Crear() => View(new Medico());

        [HttpPost]
        public IActionResult Crear(Medico medico)
        {
            _repo.Agregar(medico);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var medico = _repo.ObtenerPorId(id);
            return medico == null ? NotFound() : View(medico);
        }

        [HttpPost]
        public IActionResult Editar(Medico medico)
        {
            _repo.Actualizar(medico);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}