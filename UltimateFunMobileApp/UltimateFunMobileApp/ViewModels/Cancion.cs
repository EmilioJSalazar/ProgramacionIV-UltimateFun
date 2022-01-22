using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFunMobileApp.ViewModels
{
    class Cancion
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
    }
}
