namespace UltimateFunUWP.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cancion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cancion()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int CancionID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string LugarDeEscuchar { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Artista { get; set; }

        [Required]
        public string Album { get; set; }

        public double Duracion { get; set; }

        [Required]
        public string Genero { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public byte[] Imagen { get; set; }

        [StringLength(128)]
        public string Usuario_Id { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
