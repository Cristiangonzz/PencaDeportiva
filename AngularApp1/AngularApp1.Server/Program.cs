using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.infraestructure.db;
using AngularApp1.Server.Infraestructure.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PencaDeportes")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IEquipoRepository, EquipoRepository>();
builder.Services.AddScoped<IClasificacionRepository, ClasificacionRepository>();
builder.Services.AddScoped<IPartidoRepository, PartidoRepository>();
builder.Services.AddScoped<ITablaRepository, TablaRepository>();
builder.Services.AddScoped<ICampionatoRepository, CampionatoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin()
                   .WithExposedHeaders("Content-Length", "Content-Type")
                   .WithExposedHeaders("Access-Control-Allow-Origin"); // Agregar este m�todo para exponer el encabezado CORS.
        });
});
var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();




app.UseCors("AllowAngularLocalhost");
// Otro middleware
// ...
app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
