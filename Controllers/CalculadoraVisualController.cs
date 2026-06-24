using Microsoft.AspNetCore.Mvc;
using CitasApp.Domain.Interfaces;

namespace CitasApp.Web.Controllers
{
    public class CalculadoraVisualController : Controller
    {
        private readonly ICalculadoraService _calculadora;

        public CalculadoraVisualController(ICalculadoraService calculadora)
        {
            _calculadora = calculadora;
        }

        // Esta acción solo muestra la calculadora vacía al entrar
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Resultado = 0;
            return View();
        }

        // Esta acción procesa los clics de los botones
        [HttpPost]
        public IActionResult Index(double num1, double num2, string operacion)
        {
            double resultado = 0;
            try
            {
                resultado = operacion switch
                {
                    "suma" => _calculadora.Sumar(num1, num2),
                    "resta" => _calculadora.Restar(num1, num2),
                    "multiplicar" => _calculadora.Multiplicar(num1, num2),
                    "dividir" => _calculadora.Dividir(num1, num2),
                    _ => 0
                };
            }
            catch (DivideByZeroException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

            // Guardamos los valores para que no se borren de las cajitas al presionar el botón
            ViewBag.Num1 = num1;
            ViewBag.Num2 = num2;
            ViewBag.Resultado = resultado;
            ViewBag.Operacion = operacion;

            return View();
        }
    }
}