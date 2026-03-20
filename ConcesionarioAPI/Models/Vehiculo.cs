namespace ConcesionarioAPI.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string ImagenUrl { get; set; } = string.Empty; // Aquí guardaremos la ruta de la foto, no el archivo en sí
    }
}