using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using UltimateFunUWP.ViewModels;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


using Windows.UI.Xaml.Controls;
using System.IO;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using UltimateFunUWP.Views.Canciones;

namespace UltimateFunUWP.Views
{
    public sealed partial class CancionesPage : Page
    {
        public CancionesViewModel ViewModel { get; } = new CancionesViewModel();

        public CancionesPage()
        {
            InitializeComponent();
        }
        CancionesViewModel cancion = new CancionesViewModel();
        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44376/api/canciones");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<CancionesViewModel>>(content);
            System.Collections.IList list = resultado;
            for (int i = 0; i < list.Count; i++)
            {
                if (list.Equals(cancion.Imagen))
                {
                    byte[] item = (byte[])list[i];
                    cancion.Deserializar(item);
                    
                }
            }

            Lista.ItemsSource = list;
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateCancion));
        }

        private void OnElementClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if ((sender as AppBarButton).Label == "Edit")
            {
                Frame.Navigate(typeof(EditCancion));
                return;
            }
            if ((sender as AppBarButton).Label == "Details")
            {
                Frame.Navigate(typeof(DetailsCancion));
                return;
            }
            if ((sender as AppBarButton).Label == "Delete")
            {
                Frame.Navigate(typeof(DeleteCancion));
                return;
            }
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

        /*public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }*/

        /*public ImageSource Imagen { get { return imagen; } set { Set(ref imagen, value); } }
        private ImageSource imagen;
        readonly byte[] imageByte = null;
        public async void Deserializar()
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(imageByte);
                    await writer.StoreAsync();
                }
                var image = new BitmapImage();
                await image.SetSourceAsync(stream);

                this.Imagen = image;
            }
        }*/
    }
}
