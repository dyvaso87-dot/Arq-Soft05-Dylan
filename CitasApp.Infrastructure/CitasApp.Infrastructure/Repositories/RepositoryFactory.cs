using CitasApp.Domain.Interfaces;
using CitasApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace CitasApp.Infrastructure.Repositories
{
    public static class RepositoryFactory
    {
        public static IPacienteRepository CrearPacienteRepository(
            string entorno, IWebHostEnvironment env)
        {
            if (entorno == "Production")
                return new MemoriaPacienteRepository();

            return new JsonPacienteRepository(env.ContentRootPath);
        }
    }
}