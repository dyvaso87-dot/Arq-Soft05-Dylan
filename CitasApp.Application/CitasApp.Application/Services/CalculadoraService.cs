using CitasApp.Domain.Interfaces;

namespace CitasApp.Application.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double Sumar(double a, double b) => a + b;
        public double Restar(double a, double b) => a - b;
        public double Multiplicar(double a, double b) => a * b;

        public double Dividir(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("No se puede dividir entre cero.");
            return a / b;
        }
    }
}