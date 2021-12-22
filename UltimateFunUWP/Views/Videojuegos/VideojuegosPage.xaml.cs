using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using UltimateFunUWP.ViewModels;
using UltimateFunUWP.Views.Videojuegos;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace UltimateFunUWP.Views
{
    public sealed partial class VideojuegosPage : Page
    {
        public VideojuegosViewModel ViewModel { get; } = new VideojuegosViewModel();

        public VideojuegosPage()
        {
            InitializeComponent();
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

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateVideojuego));
        }

        private void ShowMenu(bool isTransient)
        {
            FlyoutShowOptions myOption = new FlyoutShowOptions();
            myOption.ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard;
            CommandBarFlyout1.ShowAt(Lista, myOption);
        }

        private void ListaButton_ContextRequested(Windows.UI.Xaml.UIElement sender, Windows.UI.Xaml.Input.ContextRequestedEventArgs args)
        {
            ShowMenu(false);
        }

        private void Lista_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMenu((sender as Button).IsPointerOver);
        }

        private void OnElementClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if ((sender as AppBarButton).Label == "Edit")
            {
                Frame.Navigate(typeof(EditVideojuego));
                return;
            }
            if ((sender as AppBarButton).Label == "Details")
            {
                Frame.Navigate(typeof(DetailsVideojuego));
                return;
            }
            if ((sender as AppBarButton).Label == "Delete")
            {
                Frame.Navigate(typeof(DeleteVideojuego));
                return;
            }
        }
    }
}
