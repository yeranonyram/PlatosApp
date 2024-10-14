using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatosApp.Models;
using System.Net.Http.Json;

namespace PlatosApp.Services
{
    public class PlatoService
    {
        private readonly HttpClient _httpClient;

        public PlatoService()
        {
           
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:7166/api/")
            };
        }

        // Método GET
        public async Task<List<Plato>> GetPlatosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Plato>>("platos") ?? new List<Plato>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la solicitud: {e.Message}");
                return new List<Plato>(); // Retorna lista vacía en caso de error
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return new List<Plato>(); // Retorna lista vacía en caso de error
            }
        }

        // Método POST
        public async Task AddPlatoAsync(Plato plato)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("platos", plato);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al agregar plato: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        // Método PUT
        public async Task UpdatePlatoAsync(Plato plato)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"platos/{plato.Id}", plato);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al actualizar plato: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        // Método DELETE
        public async Task DeletePlatoAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"platos/{id}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al eliminar plato: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}