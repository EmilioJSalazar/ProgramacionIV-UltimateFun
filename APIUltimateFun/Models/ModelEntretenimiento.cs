using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace APIUltimateFun.Models
{
    public partial class ModelEntretenimiento : DbContext
    {
        public ModelEntretenimiento()
            : base("name=ModelEntretenimiento")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Cancion> Cancions { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Videojuego> Videojuegoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Cancions)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Usuario_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Comentarios)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Usuario_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Peliculas)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Usuario_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Videojuegoes)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Usuario_Id);
        }
    }
}
