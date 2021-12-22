namespace APIUltimateFun.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comentario
    {
        public int ComentarioID { get; set; }

        public int CancionID { get; set; }

        public int VideojuegoID { get; set; }

        public int PeliculaID { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        [StringLength(128)]
        public string Usuario_Id { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Cancion Cancion { get; set; }

        public virtual Pelicula Pelicula { get; set; }

        public virtual Videojuego Videojuego { get; set; }
    }
}
