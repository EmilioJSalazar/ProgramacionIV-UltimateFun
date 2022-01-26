using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UltimateFunMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsCancionPage : ContentPage
    {
        public DetailsCancionPage(int CancionID, string Nombre, string LugarDeEscuchar, string Descripcion,
              string Artista, string Album, double Duracion, string Genero, DateTime FechaLanzamiento)
        {
            InitializeComponent();
            EntryId.Text = CancionID.ToString();
            BloqueNombre.Text = Nombre;
            BloqueLugar.Text = LugarDeEscuchar;
            BloqueDes.Text = Descripcion;
            BloqueArtista.Text = Artista;
            BloqueAlbum.Text = Album;
            BloqueDuracion.Text = Duracion.ToString();
            BloqueGenero.Text = Genero;
            BloqueFecha.Text = FechaLanzamiento.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CancionPage());
        }
    }
}