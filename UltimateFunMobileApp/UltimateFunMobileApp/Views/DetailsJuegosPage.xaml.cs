using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UltimateFunMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsJuegosPage : ContentPage
    {
        public DetailsJuegosPage(int VideojuegoID, string Nombre, string LugarDeJugar, string Descripcion, string Desarrollador, 
            DateTime FechaLanzamiento, byte[] Imagen)
        {
            InitializeComponent();

            EntryId.Text = VideojuegoID.ToString();
            BloqueNombre.Text = Nombre;
            BloqueLugar.Text = LugarDeJugar;
            BloqueDes.Text = Descripcion;
            BloqueDesarrollador.Text = Desarrollador;
            BloqueFecha.Text = FechaLanzamiento.ToString();
            BloqueImagen.Source = Convertidor(Imagen);
        }

        private ImageSource Convertidor(object value)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }
            return retSource;
        }
    }
}