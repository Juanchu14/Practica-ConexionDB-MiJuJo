using ConcesionarioAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de la Base de Datos (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=concesionario.db"));

// 2. Agregamos los controladores (tus archivos en la carpeta Controllers)
builder.Services.AddControllers();

// 3. Agregamos Swagger al "motor" de la aplicación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configuramos el orden de uso (Pipeline)
// Si estamos en modo desarrollo, activamos la interfaz visual
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Esto hace que Swagger sea la página principal al abrir el navegador
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 5. Mapeamos los controladores para que las rutas funcionen
app.MapControllers();

app.Run();