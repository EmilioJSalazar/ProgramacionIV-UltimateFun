using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using UltimateFunUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UltimateFunUWP.Views.Canciones
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsCancion : Page
    {
        public static int detalleSong;

        public static CancionesPage canc;


        public DetailsCancion()
        {
            this.InitializeComponent();
            cargarInforfacion();
        }
        public async void Deserializar(byte[] imageByte)
        {
            
            using(InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using(DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(imageByte);
                    await writer.StoreAsync();
                }
                var result = new BitmapImage();
                await result.SetSourceAsync(stream);

                this.imagen.Source = result;
            }

        }
        public async void cargarInforfacion()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/canciones" + "/" + detalleSong);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<CancionesViewModel>(content);
            nombre.Text = resultado.Nombre;
            dondeEscuchar.Text = resultado.LugarDeEscuchar;
            desc.Text = resultado.Descripcion;
            artista.Text = resultado.Artista;
            album.Text = resultado.Album;
            duracion.Text = resultado.Duracion.ToString();
            genero.Text = resultado.Genero;
            fecha.Text = resultado.FechaLanzamiento.ToString();
            Deserializar(resultado.Imagen);
        }

        

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CancionesPage));
        }
    }
}
