using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using UltimateFunUWP.ViewModels;
using UltimateFunUWP.Views.Peliculas;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace UltimateFunUWP.Views
{
    public sealed partial class PeliculasPage : Page
    {
        public int peliSeleccionada;

        public PeliculasViewModel ViewModel { get; } = new PeliculasViewModel();

        public PeliculasPage()
        {
            InitializeComponent();
            volverCargarPeli();
        }
        PeliculasViewModel movie = new PeliculasViewModel();


        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/peliculas");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<PeliculasViewModel>>(content);
            Lista.ItemsSource = resultado;


        }
        public async void volverCargarPeli()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/peliculas");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<PeliculasViewModel>>(content);
            Lista.ItemsSource = resultado;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(CreatePelicula));


        }

        private void Lista_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView movies = (ListView)sender;
            menu.ShowAt(movies, e.GetPosition(movies));
            var pel = ((FrameworkElement)e.OriginalSource).DataContext as PeliculasViewModel;
            peliSeleccionada = pel.PeliculaID;
            DetailsPelicula.detallePeli = pel.PeliculaID;
            EditPelicula.EditarPeliID = pel.PeliculaID;

        }

        private void Details_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsPelicula));

        }
        private async void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/peliculas" + "/" + peliSeleccionada);
            request.Method = HttpMethod.Delete;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                httpHandler = new HttpClientHandler();
                request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44344/api/peliculas");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");

                client = new HttpClient(httpHandler);

                response = await client.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<PeliculasViewModel>>(content);
                Lista.ItemsSource = resultado;

            }
        }
        private void Edit_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPelicula));

        }

    }
}

