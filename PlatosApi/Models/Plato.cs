using System.ComponentModel.DataAnnotations;

namespace PlatosApi.Models
{
    public class Plato
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Costo { get; set; }
        public string Ingredientes { get; set; }
    }
}