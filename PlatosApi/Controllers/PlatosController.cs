using Microsoft.AspNetCore.Mvc;
using PlatosApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlatosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private static List<Plato> platos = new List<Plato>
        {
            new Plato { Id = 1, Nombre = "Arroz con huevo", Costo = 7.50, Ingredientes = "Arroz, Huevo" },
            new Plato { Id = 2, Nombre = "Tacos", Costo = 5.00, Ingredientes = "Tortilla, Carne" }
        };

        [HttpGet]
        public ActionResult<List<Plato>> GetPlatos()
        {
            return Ok(platos);
        }

        [HttpPost]
        public ActionResult<Plato> AddPlato([FromBody] Plato plato)
        {
            plato.Id = platos.Max(p => p.Id) + 1; // Asignar un nuevo Id
            platos.Add(plato);
            return CreatedAtAction(nameof(GetPlatos), new { id = plato.Id }, plato);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlato(int id, [FromBody] Plato plato)
        {
            var existingPlato = platos.FirstOrDefault(p => p.Id == id);
            if (existingPlato == null) return NotFound();
            existingPlato.Nombre = plato.Nombre;
            existingPlato.Costo = plato.Costo;
            existingPlato.Ingredientes = plato.Ingredientes;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlato(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (plato == null) return NotFound();
            platos.Remove(plato);
            return NoContent();
        }
    }
}