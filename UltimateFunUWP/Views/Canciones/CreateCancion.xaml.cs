using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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
//using Windows.Web.Http;
using Windows.Storage.Streams;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

//using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UltimateFunUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateCancion : Page
    {
        public CreateCancion()
        {
            this.InitializeComponent();
        }
        byte[] byteimage = null;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "Cancelar")
            {
                Frame.Navigate(typeof(CancionesPage));
                return;
            }
            var cancion = new CancionesViewModel
            {
                Nombre = Nombre.Text,

                LugarDeEscuchar = DondeEscuchar.Text,

                Descripcion = Descripcion.Text,

                Artista = Artista.Text,

                Album = Album.Text,

                Duracion = int.Parse(Duracion.Text.ToString()),

                Genero = Genero.Text,

                FechaLanzamiento = DateTime.Parse(FechaDeLanzamiento.Text.ToString()),

                Imagen = byteimage
            };
            //Create a traves de Post
            var client = new HttpClient();

            var content = JsonConvert.SerializeObject(cancion);
            

            var data = new StringContent(content, Encoding.UTF8, "application/json");
            var httpResponse =  await client.PostAsync("https://localhost:44344/api/canciones", data);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            Frame.Navigate(typeof(CancionesPage));

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
                this.textBlockImagen.Text = "Imagen seleccionada: " + file.Name;
                SerializarAsync(file);
            }
            else
            {
                this.textBlockImagen.Text = "Operación cancelada";
            }
            

        }


    }
}
