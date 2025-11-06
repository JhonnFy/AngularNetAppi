using CapaAPI;
using CapaAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-1276GPH;Database=AngularNetAppi;User Id=AdminDeveloper;Password=AdminDeveloper0312809833;TrustServerCertificate=True;"));


builder.Services.AddScoped<ServicioEstudiante>();
builder.Services.AddScoped<ServicioProfesor>();
builder.Services.AddScoped<ServicioNota>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
