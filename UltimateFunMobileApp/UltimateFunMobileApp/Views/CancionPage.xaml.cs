using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class CancionPage : ContentPage
    {
        public CancionPage()
        {
            InitializeComponent();
            CargarCanciones();
            Lista.ItemsSource = GetCanciones();
            this.BindingContext = this;
        }

        /*private async void Button_Click(object sender, EventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://10.0.2.2:54386/api/canciones");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Cancion>>(content);

            Lista.ItemsSource = resultado;

        }*/

        private void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details= e.Item as Cancion;
            Navigation.PushAsync(new DetailsCancionPage(details.CancionID,details.Nombre,details.LugarDeEscuchar,details.Descripcion,
               details.Artista,details.Album,details.Duracion,details.Genero,details.FechaLanzamiento,details.Imagen));
        }

        private List<Cancion> canciones;
        private async void CargarCanciones()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://10.0.2.2:54386/api/canciones");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Cancion>>(content);

            Lista.ItemsSource = resultado;
            canciones = resultado;
        }

        IEnumerable<Cancion> GetCanciones(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return canciones;
            return canciones.Where(p => p.Nombre.StartsWith(searchText));
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            Lista.ItemsSource = GetCanciones();
            Lista.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lista.ItemsSource = GetCanciones(e.NewTextValue);
        }
    }
}