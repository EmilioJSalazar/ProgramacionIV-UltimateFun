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

namespace UltimateFunUWP.Views.Videojuegos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditVideojuego : Page
    {

        public static int EditarJuegoID;

        public EditVideojuego()
        {
            this.InitializeComponent();
            cargarImforfacion();
        }

        byte[] byteimage = null;

        public async void Deserializar(byte[] imageByte)
        {

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(imageByte);
                    await writer.StoreAsync();
                }
                var result = new BitmapImage();
                if (imageByte != null)
                {
                    await result.SetSourceAsync(stream);
                    this.imagenDefecto.Text = "";
                }


                this.imagenCampo.Source = result;
            }

        }
        public async void cargarImforfacion()
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/videojuegos" + "/" + EditarJuegoID);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<VideojuegosViewModel>(content);
            nombre.Text = resultado.Nombre;
            dondejugar.Text = resultado.LugarDeJugar;
            desc.Text = resultado.Descripcion;
            desarrollador.Text = resultado.Desarrollador;
            fecha.Text = resultado.FechaLanzamiento.ToString();
            Deserializar(resultado.Imagen);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(VideojuegosPage));

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
                this.imagenDefecto.Text = "";
                this.imagenTexto.Text = "Imagen seleccionada: " + file.Name;
                byte[] i = null;
                Deserializar(i);
                SerializarAsync(file);
            }
            else
            {
                //Deserializar(resultado.Imagen);
                this.imagenDefecto.Text = "";
                this.imagenTexto.Text = "Operación cancelada";
            }

        }

        private async void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "Cancel")
            {
                Frame.Navigate(typeof(VideojuegosPage));
                return;
            }
            var Editarjuego = new VideojuegosViewModel

            {
                VideojuegoID=EditarJuegoID,

                Nombre = nombre.Text,

               LugarDeJugar = dondejugar.Text,

                Descripcion = desc.Text,

                Desarrollador = desarrollador.Text,

                FechaLanzamiento = DateTime.Parse(fecha.Text.ToString()),

                Imagen = byteimage,
            };

            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var content = JsonConvert.SerializeObject(Editarjuego);


            var data = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = await client.PutAsync("https://localhost:44344/api/videojuegos" + "/" + EditarJuegoID, data);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            Frame.Navigate(typeof(VideojuegosPage));

        }





    
}
}
