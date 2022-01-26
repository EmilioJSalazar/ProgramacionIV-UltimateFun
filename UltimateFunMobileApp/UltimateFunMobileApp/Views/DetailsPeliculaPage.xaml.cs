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
    public partial class DetailsPeliculaPage : ContentPage
    {
        public DetailsPeliculaPage(int PeliculaID, int Tipo, string Nombre, string LugarDeVisualizacion, string Descripcion,
            string Actores,string Director, double Duracion, DateTime FechaLanzamiento)
        {
            InitializeComponent();

            EntryId.Text = PeliculaID.ToString();
            BloqueTipo.Text = Tipo.ToString();
            BloqueNombre.Text = Nombre;
            BloqueLugar.Text = LugarDeVisualizacion;
            BloqueDes.Text = Descripcion;
            BloqueActor.Text = Actores;
            BloqueDirec.Text = Director;
            BloqueDuracion.Text = Duracion.ToString();
            BloqueFecha.Text = FechaLanzamiento.ToString();
        }
    }
}