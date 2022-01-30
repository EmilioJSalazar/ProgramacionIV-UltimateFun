using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UltimateFunUWP.Library;
using UltimateFunUWP.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UltimateFunUWP.ViewModels
{
  public class LoginViewModel : UserModel
    {
        private ICommand _command;
        private TextBox _textBoxEmail;
        private PasswordBox _textBoxPass;
        private String date = DateTime.Now.ToString("dd/MM/yyy");
        private Frame rootFrame = Window.Current.Content as Frame;

        public LoginViewModel(object[] campos)
        {
            _textBoxEmail = (TextBox)campos[0];
            _textBoxPass = (PasswordBox)campos[1];
        }

        public ICommand IniciarCommand
        {
            get
            {
                return _command ?? (_command = new CommandHandler(async () =>
                {
                    await iniciarAsync();
                }));
            }
        }

        private async Task iniciarAsync()
        {
            var data = Email;

        }
    }
}
