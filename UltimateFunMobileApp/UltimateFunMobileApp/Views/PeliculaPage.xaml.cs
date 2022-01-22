using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UltimateFunMobileApp.ViewModels;
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

    }
}