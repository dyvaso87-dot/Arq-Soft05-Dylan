using Microsoft.AspNetCore.Mvc;
using CitasApp.Domain.Interfaces;

namespace CitasApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ICalculadoraService _calculadora;

        // Inyectamos el servicio mediante el constructor
        public CalculadoraController(ICalculadoraService calculadora)
        {
            _calculadora = calculadora;
        }

        [HttpGet("sumar")]
        public IActionResult Sumar([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(new { operacion = "suma", a, b, resultado = _calculadora.Sumar(a, b) });
        }

        // ─── AQUÍ ESTÁ LA RESTA QUE HACÍA FALTA ───
        [HttpGet("restar")]
        public IActionResult Restar([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(new { operacion = "resta", a, b, resultado = _calculadora.Restar(a, b) });
        }

        // ─── AQUÍ ESTÁ LA MULTIPLICACIÓN QUE HACÍA FALTA ───
        [HttpGet("multiplicar")]
        public IActionResult Multiplicar([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(new { operacion = "multiplicacion", a, b, resultado = _calculadora.Multiplicar(a, b) });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir([FromQuery] double a, [FromQuery] double b)
        {
            try
            {
                return Ok(new { operacion = "division", a, b, resultado = _calculadora.Dividir(a, b) });
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}