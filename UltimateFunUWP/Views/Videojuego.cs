namespace UltimateFunUWP.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Videojuego
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Videojuego()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int VideojuegoID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string LugarDeJugar { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Desarrollador { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public byte[] Imagen { get; set; }

        [StringLength(128)]
        public string Usuario_Id { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
