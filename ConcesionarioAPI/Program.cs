using Microsoft.EntityFrameworkCore;
using ConcesionarioAPI.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConcesionarioContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseStaticFiles(); 
app.UseCors("PermitirTodo");
app.UseAuthorization();
app.MapControllers();
app.Run();