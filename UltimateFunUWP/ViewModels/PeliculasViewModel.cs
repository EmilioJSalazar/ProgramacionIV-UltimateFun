using System;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace UltimateFunUWP.ViewModels
{
    public class PeliculasViewModel : ObservableObject
    {
        public int PeliculaID { get; set; }

        public int Tipo { get; set; }

        public string Nombre { get; set; }

        public string LugarDeVisualizacion { get; set; }

        public string Descripcion { get; set; }

        public string Actores { get; set; }

        public string Director { get; set; }

        public double Duracion { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public byte[] Imagen { get; set; }
        public PeliculasViewModel()
        {
        }
    }
}
