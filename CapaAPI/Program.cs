//using CapaAPI;
//using CapaAPI.Services;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer("Server=DESKTOP-1276GPH;Database=AngularNetAppi;User Id=AdminDeveloper;Password=AdminDeveloper0312809833;TrustServerCertificate=True;"));


//builder.Services.AddScoped<ServicioEstudiante>();
//builder.Services.AddScoped<ServicioProfesor>();
//builder.Services.AddScoped<ServicioNota>();

//builder.Services.AddControllers();

//var app = builder.Build();

//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.Run();




using CapaAPI;
using CapaAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DBContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-1276GPH;Database=AngularNetAppi;User Id=AdminDeveloper;Password=AdminDeveloper0312809833;TrustServerCertificate=True;"));

// Servicios
builder.Services.AddScoped<ServicioEstudiante>();
builder.Services.AddScoped<ServicioProfesor>();
builder.Services.AddScoped<ServicioNota>();

builder.Services.AddControllers();

// --- CORS Habilitado ---
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(); // <-- Permite que Angular en otro puerto acceda

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
