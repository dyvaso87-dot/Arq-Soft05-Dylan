using CitasApp.Application.Services;
using CitasApp.Domain.Interfaces;
using CitasApp.Infrastructure;
using CitasApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ─── REPOSITORIOS ───
// IPacienteRepository: Factory + Decorator (un solo registro)
builder.Services.AddScoped<IPacienteRepository>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var repo = RepositoryFactory.CrearPacienteRepository(
        builder.Environment.EnvironmentName, env);
    return new LoggingPacienteRepository(repo);
});

builder.Services.AddScoped<IMedicoRepository>(sp =>
    new JsonMedicoRepository(builder.Environment.ContentRootPath));

builder.Services.AddScoped<ICitaRepository>(sp =>
    new JsonCitaRepository(builder.Environment.ContentRootPath));

// ─── SERVICIOS DE APLICACIÓN ───
builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>(sp =>
{
    var repo = sp.GetRequiredService<ICitaRepository>();
    var service = new CitaService(repo);
    service.AgregarObserver(new SmsObserver());
    service.AgregarObserver(new EmailObserver());
    return service;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();