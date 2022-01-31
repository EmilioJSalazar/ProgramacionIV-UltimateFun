using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UltimateFunUWP.Library;
using UltimateFunUWP.Views.Users;

namespace UltimateFunUWP.ViewModels
{
    public class UserViewModel
    {
        public ICommand AddCommand
        {
            get
            {
                return new CommandHandler(() => App.mContentFrame.Navigate(typeof(AddUser)));
            }
        }
    }
}
