using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConcesionarioAPI.Data;
using ConcesionarioAPI.Models;

namespace ConcesionarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly ConcesionarioContext _context;
        private readonly IWebHostEnvironment _env;

        public VehiculosController(ConcesionarioContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo([FromForm] VehiculoDto dto)
        {
            var vehiculo = new Vehiculo
            {
                Nombre = dto.Nombre,
                Stock = dto.Stock
            };

            if (dto.Imagen != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "imagenes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.Imagen.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(fileStream);
                }

                vehiculo.ImagenUrl = "/imagenes/" + uniqueFileName;
            }

            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, [FromForm] VehiculoDto dto)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            vehiculo.Nombre = dto.Nombre;
            vehiculo.Stock = dto.Stock;

            if (dto.Imagen != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "imagenes");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.Imagen.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(fileStream);
                }

                if (!string.IsNullOrEmpty(vehiculo.ImagenUrl))
                {
                    string oldImagePath = Path.Combine(_env.WebRootPath ?? "wwwroot", vehiculo.ImagenUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath)) 
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                vehiculo.ImagenUrl = "/imagenes/" + uniqueFileName;
            }

            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(vehiculo.ImagenUrl))
            {
                string imagePath = Path.Combine(_env.WebRootPath ?? "wwwroot", vehiculo.ImagenUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class VehiculoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}