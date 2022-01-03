using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFunUWP.ViewModels
{
    public class UsuariosViewModel : ObservableObject
    {
        public int Id_usuario { get; set; }

        public string Nombre { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Tipo_usuario { get; set; }

        
        public UsuariosViewModel()
        {
        }
    }
}
