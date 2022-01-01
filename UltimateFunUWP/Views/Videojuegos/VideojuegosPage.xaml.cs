using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using UltimateFunUWP.ViewModels;
using UltimateFunUWP.Views.Videojuegos;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace UltimateFunUWP.Views
{
    public sealed partial class VideojuegosPage : Page
    {
        public int juegoSeleccionado;
        public VideojuegosViewModel ViewModel { get; } = new VideojuegosViewModel();

        public VideojuegosPage()
        {
            InitializeComponent();
            volverCargarJuego();
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/videojuegos");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<VideojuegosViewModel>>(content);
            Lista.ItemsSource = resultado;
        }

        public async void volverCargarJuego()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/videojuegos");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<VideojuegosViewModel>>(content);
            Lista.ItemsSource = resultado;

        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateVideojuego));
        }

        private void Lista_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView games = (ListView)sender;
            menu.ShowAt(games, e.GetPosition(games));
            var game = ((FrameworkElement)e.OriginalSource).DataContext as VideojuegosViewModel;
            juegoSeleccionado = game.VideojuegoID;
            DetailsVideojuego.detallejuego = game.VideojuegoID;
            EditVideojuego.EditarJuegoID = game.VideojuegoID;

        }

        private void Details_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsVideojuego));

        }
        private async void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/videojuegos" + "/" + juegoSeleccionado);
            request.Method = HttpMethod.Delete;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                httpHandler = new HttpClientHandler();
                request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44344/api/videojuegos");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");

                client = new HttpClient(httpHandler);

                response = await client.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<VideojuegosViewModel>>(content);
                Lista.ItemsSource = resultado;

            }
        }
        private void Edit_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditVideojuego));

        }


    }
}
