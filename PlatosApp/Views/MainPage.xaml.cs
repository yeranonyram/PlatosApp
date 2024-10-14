using PlatosApp.Models;
using PlatosApp.Services;
using System.Collections.ObjectModel;

namespace PlatosApp.Views
{
    public partial class MainPage : ContentPage
    {
        private PlatoService _platoService;
        public ObservableCollection<Plato> Platos { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _platoService = new PlatoService();
            Platos = new ObservableCollection<Plato>();
            PlatosCollectionView.ItemsSource = Platos; // Asegúrate de que esto funcione
            LoadPlatos();
        }

        private async void LoadPlatos()
        {
            var platos = await _platoService.GetPlatosAsync();
            var platosAleatorios = platos.OrderBy(p => Guid.NewGuid()).ToList();
            foreach (var plato in platosAleatorios)
            {
                Platos.Add(plato);
            }
        }

        private async void OnAddPlatoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlatoPage());
        }
    }
}