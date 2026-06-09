using CitasApp.CitasApp.Domian.Interfaces;
using CitasApp.CitasApp.Infrastrcuture.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<CitasApp.CitasApp.Infrastrcuture.Repositories.IWebHostEnvironment>(
    new InfrastructureWebHostEnvironment(builder.Environment));
builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();

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
