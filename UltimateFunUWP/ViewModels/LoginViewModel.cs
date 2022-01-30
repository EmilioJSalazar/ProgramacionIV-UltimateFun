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
using LoginConnection;
using LoginModelsUWP;
using UltimateFunUWP.Views;

namespace UltimateFunUWP.ViewModels
{
  public class LoginViewModel : UserModel
    {
        private ICommand _command;
        private TextBox _textBoxEmail;
        private PasswordBox _textBoxPass;
        private String date = DateTime.Now.ToString("dd/MM/yyy");
        private Frame rootFrame = Window.Current.Content as Frame;
        private Connections _conn;
        private SQLiteConnections _sqlite;
        public LoginViewModel(object[] campos)
        {
            _textBoxEmail = (TextBox)campos[0];
            _textBoxPass = (PasswordBox)campos[1];
            _conn = new Connections();
            _sqlite = new SQLiteConnections();
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
            if (Email == null || Email.Equals(""))
            {
                EmailMessage = "Ingrese el email";
                _textBoxEmail.Focus(FocusState.Programmatic);
            }
            else
            {
                if (TextBoxEvent.IsValidEmail(Email))
                {
                    if(Password == null || Password.Equals(""))
                    {
                        PasswordMessage = "Ingrese el password";
                        _textBoxPass.Focus(FocusState.Programmatic);
                    }
                    else
                    {
                        try
                        {
                            var user = _conn.TUsers.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).ToList();

                            if (0 < user.Count)
                            {
                                var dataUser = user.ElementAt(0);
                                dataUser.Date = DateTime.Now.ToString("dd/MM/yyy");
                                _sqlite.Connection.Insert(dataUser);
                                rootFrame.Navigate(typeof(HomePage));
                            }
                            else
                            {
                                Message = "Contraseña o email incorrectos";
                            }
                        }
                        catch (Exception ex)
                        {
                            Message = ex.Message;
                        }
                       
                    }
                }
                else
                {
                    EmailMessage = "El email no es valido";
                    _textBoxEmail.Focus(FocusState.Programmatic);
                }
            }
        }
    }
}
