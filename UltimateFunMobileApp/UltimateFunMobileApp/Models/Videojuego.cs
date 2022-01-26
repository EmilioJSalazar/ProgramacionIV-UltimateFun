using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFunMobileApp.Models
{
    class Videojuego
    {
        public int VideojuegoID { get; set; }

        public string Nombre { get; set; }

        public string LugarDeJugar { get; set; }

        public string Descripcion { get; set; }

        public string Desarrollador { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public byte[] Imagen { get; set; }
    }
}
