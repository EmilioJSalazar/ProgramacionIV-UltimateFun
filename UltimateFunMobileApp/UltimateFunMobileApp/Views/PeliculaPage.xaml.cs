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
    public partial class PeliculaPage : ContentPage
    {
        public PeliculaPage()
        {
            InitializeComponent();
            CargarPeli();
            Lista.ItemsSource = GetPeliculas();
            this.BindingContext = this;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://10.0.2.2:54386/api/peliculas");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Pelicula>>(content);

            Lista.ItemsSource = resultado;

        }

        private void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detailsPeli = e.Item as Pelicula;
            Navigation.PushAsync(new DetailsPeliculaPage(detailsPeli.PeliculaID,detailsPeli.Tipo,detailsPeli.Nombre,detailsPeli.LugarDeVisualizacion,
                detailsPeli.Descripcion,detailsPeli.Actores,detailsPeli.Director,detailsPeli.Duracion,detailsPeli.FechaLanzamiento));
            //ListView movies = (ListView)sender;
            //menu.ShowAt(movies, e.GetPosition(movies));
            //var pel = ((FrameworkElement)e.OriginalSource).DataContext as PeliculasViewModel;
            //peliSeleccionada = pel.PeliculaID;
            //DetailsPelicula.detallePeli = pel.PeliculaID;
            //EditPelicula.EditarPeliID = pel.PeliculaID;


        }
        private List<Pelicula> pelis;
        private async void CargarPeli()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://10.0.2.2:54386/api/peliculas");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Pelicula>>(content);

            Lista.ItemsSource = resultado;
            pelis = resultado;
        }

        IEnumerable<Pelicula> GetPeliculas(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return pelis;
            return pelis.Where(p => p.Nombre.StartsWith(searchText));
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            Lista.ItemsSource = GetPeliculas();
            Lista.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lista.ItemsSource = GetPeliculas(e.NewTextValue);
        }
    }
}