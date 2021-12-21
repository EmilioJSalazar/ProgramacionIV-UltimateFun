using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace UltimateFunUWP.ViewModels
{
    public class CancionesViewModel : ObservableObject
    {
        public int CancionID { get; set; }

        public string Nombre { get; set; }

        public string LugarDeEscuchar { get; set; }

        public string Descripcion { get; set; }

        public string Artista { get; set; }

        public string Album { get; set; }

        public double Duracion { get; set; }

        public string Genero { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public byte[] Imagen { get; set; }
        public ImageSource CurrentImage { get { return imagen; } set { SetProperty(ref imagen, value); } }
        private ImageSource imagen;
        
        public async void Deserializar(byte[] imageByte)
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
                this.CurrentImage = image;
            }
        }

        public CancionesViewModel()
        {
            
        }
    }
}
