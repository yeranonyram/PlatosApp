using PlatosApp.Models;
using PlatosApp.Services;

namespace PlatosApp.Views
{
    public partial class PlatoPage : ContentPage
    {
        private PlatoService _platoService;
        private Plato _plato;

        public PlatoPage(Plato plato = null)
        {
            InitializeComponent();
            _platoService = new PlatoService();

            if (plato != null)
            {
                _plato = plato;
                NombreEntry.Text = plato.Nombre;
                CostoEntry.Text = plato.Costo.ToString();
                IngredientesEntry.Text = plato.Ingredientes;
            }
            else
            {
                _plato = new Plato();
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _plato.Nombre = NombreEntry.Text;
            _plato.Costo = double.Parse(CostoEntry.Text);
            _plato.Ingredientes = IngredientesEntry.Text;

            if (_plato.Id == 0)
            {
                await _platoService.AddPlatoAsync(_plato);
            }
            else
            {
                await _platoService.UpdatePlatoAsync(_plato);
            }

            await Navigation.PopAsync();
        }
    }
}