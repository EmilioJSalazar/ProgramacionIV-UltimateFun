using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using UltimateFunUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UltimateFunUWP.Views.Peliculas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPelicula : Page
    {
        public static int detallePeli;



        public DetailsPelicula()
        {
            this.InitializeComponent();
            cargarInforfacion();
        }


        public async void cargarInforfacion()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/peliculas" + "/" + detallePeli);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<PeliculasViewModel>(content);
            
            string tip = resultado.Tipo.ToString();
            if (tip == "0")
            {
                tipo.Text = "Pelicula";
            }
            else
            {
                tipo.Text = "Serie";
            }
            nombre.Text = resultado.Nombre;
            dondeVisualizar.Text = resultado.LugarDeVisualizacion;
            desc.Text = resultado.Descripcion;
            actores.Text = resultado.Actores;
            director.Text = resultado.Director;
            duracion.Text = resultado.Duracion.ToString();
            fecha.Text = resultado.FechaLanzamiento.ToString();
            imageN.Text = resultado.Imagen.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PeliculasPage));

        }
    }
        
}
