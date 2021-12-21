using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace UltimateFunUWP.ViewModels
{
    public class UsersViewModel : ObservableObject
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<CancionesViewModel> Cancions { get; set; }

  
        //public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual ICollection<PeliculasViewModel> Peliculas { get; set; }

        public virtual ICollection<VideojuegosViewModel> Videojuegoes { get; set; }
        public UsersViewModel()
        {
        }
    }
}
