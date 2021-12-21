using System;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace UltimateFunUWP.ViewModels
{
    public class VideojuegosViewModel : ObservableObject
    {
        public int VideojuegoID { get; set; }

        public string Nombre { get; set; }

        public string LugarDeJugar { get; set; }

        public string Descripcion { get; set; }

        public string Desarrollador { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public byte[] Imagen { get; set; }
        public VideojuegosViewModel()
        {
        }
    }
}
