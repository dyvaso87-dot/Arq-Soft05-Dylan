using CitasApp.Domain.Interfaces;
using CitasApp.Infrastrcuture.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string contentRoot = builder.Environment.ContentRootPath;

builder.Services.AddScoped<IPacienteRepository>(_ => new JsonPacienteRepository(contentRoot));
builder.Services.AddScoped<IMedicoRepository>(_ => new JsonMedicoRepository(contentRoot));
builder.Services.AddScoped<ICitaRepository>(_ => new JsonCitaRepository(contentRoot));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

internal sealed class InfrastructureWebHostEnvironment : CitasApp.CitasApp.Infrastrcuture.Repositories.IWebHostEnvironment
{
    public InfrastructureWebHostEnvironment(Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
    {
        ContentRootPath = environment.ContentRootPath;
    }

    public string ContentRootPath { get; }
}
