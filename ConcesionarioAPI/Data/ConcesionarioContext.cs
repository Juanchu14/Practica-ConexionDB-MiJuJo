using Microsoft.EntityFrameworkCore;
using ConcesionarioAPI.Models;

namespace ConcesionarioAPI.Data
{
    public class ConcesionarioContext : DbContext
    {
        public ConcesionarioContext(DbContextOptions<ConcesionarioContext> options) : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vehiculo>().HasData(
                new Vehiculo { Id = 1, Nombre = "Mercedes-Benz A45 AMG", Stock = 3, ImagenUrl = "/imagenes/a45.png" },
                new Vehiculo { Id = 2, Nombre = "Mercedes-Benz C63 AMG", Stock = 2, ImagenUrl = "/imagenes/c63.png" },
                new Vehiculo { Id = 3, Nombre = "Mercedes-Benz CLA 45 AMG", Stock = 4, ImagenUrl = "/imagenes/cla45.png" },
                new Vehiculo { Id = 4, Nombre = "Mercedes-Benz CLS 63 AMG", Stock = 1, ImagenUrl = "/imagenes/cls63.png" },
                new Vehiculo { Id = 5, Nombre = "Mercedes-Benz G63 AMG", Stock = 2, ImagenUrl = "/imagenes/g63.png" },
                new Vehiculo { Id = 6, Nombre = "Mercedes-Benz GLE 63 AMG", Stock = 3, ImagenUrl = "/imagenes/gle63.png" },
                new Vehiculo { Id = 7, Nombre = "Mercedes-Benz GLS", Stock = 5, ImagenUrl = "/imagenes/gls.png" },
                new Vehiculo { Id = 8, Nombre = "Mercedes-AMG GT 63", Stock = 1, ImagenUrl = "/imagenes/gt63.png" },
                new Vehiculo { Id = 9, Nombre = "Mercedes-Maybach", Stock = 1, ImagenUrl = "/imagenes/maybach.png" },
                new Vehiculo { Id = 10, Nombre = "Mercedes-Benz SLS AMG", Stock = 1, ImagenUrl = "/imagenes/sls.png" },
                new Vehiculo { Id = 11, Nombre = "BMW Alpina B7", Stock = 2, ImagenUrl = "/imagenes/alpinab7.png" },
                new Vehiculo { Id = 12, Nombre = "BMW i8", Stock = 2, ImagenUrl = "/imagenes/i8.png" },
                new Vehiculo { Id = 13, Nombre = "BMW M2", Stock = 4, ImagenUrl = "/imagenes/m2.png" },
                new Vehiculo { Id = 14, Nombre = "BMW M3 Competition Touring", Stock = 3, ImagenUrl = "/imagenes/m3competitiontouring.png" },
                new Vehiculo { Id = 15, Nombre = "BMW M4 Competition", Stock = 3, ImagenUrl = "/imagenes/m4competition.png" },
                new Vehiculo { Id = 16, Nombre = "BMW M5 CS", Stock = 1, ImagenUrl = "/imagenes/m5cs.png" },
                new Vehiculo { Id = 17, Nombre = "BMW M8 Competition", Stock = 2, ImagenUrl = "/imagenes/m8competition.png" },
                new Vehiculo { Id = 18, Nombre = "BMW Serie 8 Convertible", Stock = 3, ImagenUrl = "/imagenes/serie8convertible.png" },
                new Vehiculo { Id = 19, Nombre = "BMW XM", Stock = 2, ImagenUrl = "/imagenes/xm.png" },
                new Vehiculo { Id = 20, Nombre = "BMW Z4 M40i", Stock = 4, ImagenUrl = "/imagenes/z4m40i.png" },
                new Vehiculo { Id = 21, Nombre = "Audi Q8 e-tron", Stock = 5, ImagenUrl = "/imagenes/q8e-tron.png" },
                new Vehiculo { Id = 22, Nombre = "Audi R8", Stock = 1, ImagenUrl = "/imagenes/r8.png" },
                new Vehiculo { Id = 23, Nombre = "Audi RS3", Stock = 4, ImagenUrl = "/imagenes/rs3.png" },
                new Vehiculo { Id = 24, Nombre = "Audi RS5 Coupe", Stock = 3, ImagenUrl = "/imagenes/rs5coupe.png" },
                new Vehiculo { Id = 25, Nombre = "Audi RS6 Avant", Stock = 2, ImagenUrl = "/imagenes/rs6.png" },
                new Vehiculo { Id = 26, Nombre = "Audi RS7", Stock = 2, ImagenUrl = "/imagenes/rs7.png" },
                new Vehiculo { Id = 27, Nombre = "Audi RS e-tron GT", Stock = 2, ImagenUrl = "/imagenes/rse-trongt.png" },
                new Vehiculo { Id = 28, Nombre = "Audi RSQ8", Stock = 3, ImagenUrl = "/imagenes/rsq8.png" },
                new Vehiculo { Id = 29, Nombre = "Audi S8", Stock = 2, ImagenUrl = "/imagenes/s8.png" },
                new Vehiculo { Id = 30, Nombre = "Audi TT RS", Stock = 3, ImagenUrl = "/imagenes/ttrs.png" }
            );
        }
    }
}