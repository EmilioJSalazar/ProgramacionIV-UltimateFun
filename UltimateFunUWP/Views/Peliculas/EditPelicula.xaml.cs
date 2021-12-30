using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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
    public sealed partial class EditPelicula : Page
    {

        public static int EditarPeli;


        public EditPelicula()
        {
            this.InitializeComponent();
            cargarInforfacion();
        }
        byte[] byteimage = null;


        public async void cargarInforfacion()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/peliculas" + "/" + EditarPeli);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<PeliculasViewModel>(content);
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

        private async void SerializarAsync(Windows.Storage.StorageFile file)
        {

            byte[] imageByte = null;
            using (var inputStream = await file.OpenSequentialReadAsync())
            {
                Task task = Task.Run(async () =>
                {

                    var readStream = inputStream.AsStreamForRead();
                    var byteArray = new byte[readStream.Length];
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                    imageByte = byteArray;

                });

                task.Wait();

            }
            this.byteimage = imageByte;
            //bitmap            
        }

        private async void Imagen_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.imageN.Text = "Picked photo: " + file.Name;
            }
            else
            {
                this.imageN.Text = "Operation cancelled.";
            }
            SerializarAsync(file);

        }

        private async void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "Cancel")
            {
                Frame.Navigate(typeof(PeliculasPage));
                return;
            }
            var EditarCancion = new PeliculasViewModel
            {
                Tipo = int.Parse(tipo.Text.ToString()),

                Nombre = nombre.Text,

                LugarDeVisualizacion = dondeVisualizar.Text,

                Descripcion = desc.Text,

                Actores = actores.Text,

                Director = director.Text,

                Duracion = int.Parse(duracion.Text.ToString()),

                FechaLanzamiento = DateTime.Parse(fecha.Text.ToString()),

                Imagen = byteimage
            };

            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var content = JsonConvert.SerializeObject(EditarCancion);


            var data = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = await client.PutAsync("https://localhost:44344/api/peliculas" + "/" + EditarPeli, data);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            Frame.Navigate(typeof(PeliculasPage));

        }


    


}
    

}
