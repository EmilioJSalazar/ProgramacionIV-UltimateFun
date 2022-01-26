using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UltimateFunMobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UltimateFunMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideojuegoPage : ContentPage
    {
        public VideojuegoPage()
        {
            InitializeComponent();
            CargarVideojuegos();
            Lista.ItemsSource = GetVideojuegos();
            this.BindingContext = this;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://10.0.2.2:54386/api/videojuegos");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Videojuego>>(content);

            Lista.ItemsSource = resultado;

        }

        private void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detailsJuego = e.Item as Videojuego;
            Navigation.PushAsync(new DetailsJuegosPage(detailsJuego.VideojuegoID, detailsJuego.Nombre, detailsJuego.LugarDeJugar,
                detailsJuego.Descripcion,detailsJuego.Desarrollador, detailsJuego.FechaLanzamiento));
            //ListView movies = (ListView)sender;
            //menu.ShowAt(movies, e.GetPosition(movies));
            //var pel = ((FrameworkElement)e.OriginalSource).DataContext as PeliculasViewModel;
            //peliSeleccionada = pel.PeliculaID;
            //DetailsPelicula.detallePeli = pel.PeliculaID;
            //EditPelicula.EditarPeliID = pel.PeliculaID;


        }
        private List<Videojuego> videojuegos;
        private async void CargarVideojuegos()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://10.0.2.2:54386/api/videojuegos");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Videojuego>>(content);

            Lista.ItemsSource = resultado;
            videojuegos = resultado;
        }

        IEnumerable<Videojuego> GetVideojuegos(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return videojuegos;
            return videojuegos.Where(p => p.Nombre.StartsWith(searchText));
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            Lista.ItemsSource = GetVideojuegos();
            Lista.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lista.ItemsSource = GetVideojuegos(e.NewTextValue);
        }
    }
}