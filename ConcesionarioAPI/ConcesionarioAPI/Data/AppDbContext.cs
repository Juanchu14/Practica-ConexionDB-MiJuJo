using Microsoft.EntityFrameworkCore;
using ConcesionarioAPI.Models;

namespace ConcesionarioAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}