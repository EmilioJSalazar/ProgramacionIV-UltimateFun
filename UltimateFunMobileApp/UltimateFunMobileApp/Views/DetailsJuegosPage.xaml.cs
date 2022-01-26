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
    public partial class DetailsJuegosPage : ContentPage
    {
        public DetailsJuegosPage(int VideojuegoID, string Nombre, string LugarDeJugar, string Descripcion, string Desarrollador, 
            DateTime FechaLanzamiento)
        {
            InitializeComponent();

            EntryId.Text = VideojuegoID.ToString();
            BloqueNombre.Text = Nombre;
            BloqueLugar.Text = LugarDeJugar;
            BloqueDes.Text = Descripcion;
            BloqueDesarrollador.Text = Desarrollador;
            BloqueFecha.Text = FechaLanzamiento.ToString();
        }
    }
}