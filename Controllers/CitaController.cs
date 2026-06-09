using CitasApp.CitasApp.Domian.Interfaces;
using CitasApp.CitasApp.Domian.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Web.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaRepository _citaRepo;
        private readonly IPacienteRepository _pacienteRepo;
        private readonly IMedicoRepository _medicoRepo;

        public CitaController(ICitaRepository citaRepo,
                              IPacienteRepository pacienteRepo,
                              IMedicoRepository medicoRepo)
        {
            _citaRepo = citaRepo;
            _pacienteRepo = pacienteRepo;
            _medicoRepo = medicoRepo;
        }

        private void CargarViewBag()
        {
            ViewBag.Pacientes = _pacienteRepo.ObtenerTodos();
            ViewBag.Medicos = _medicoRepo.ObtenerTodos();
        }

        public IActionResult Index()
        {
            CargarViewBag();
            return View(_citaRepo.ObtenerTodos());
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            CargarViewBag();
            return View(_citaRepo.ObtenerPorPaciente(pacienteId));
        }

        public IActionResult Crear()
        {
            CargarViewBag();
            return View(new Cita());
        }

        [HttpPost]
        public IActionResult Crear(Cita cita)
        {
            _citaRepo.Agregar(cita);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var cita = _citaRepo.ObtenerPorId(id);
            if (cita == null) return NotFound();
            CargarViewBag();
            return View(cita);
        }

        [HttpPost]
        public IActionResult Editar(Cita cita)
        {
            _citaRepo.Actualizar(cita);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _citaRepo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}