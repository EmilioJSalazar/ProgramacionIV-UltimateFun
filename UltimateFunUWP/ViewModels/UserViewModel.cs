using LoginConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UltimateFunUWP.Library;
using UltimateFunUWP.Models;
using UltimateFunUWP.Views.Users;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UltimateFunUWP.ViewModels
{
    public class UserViewModel : UserModel
    {
        private Connections _conn;
        private TextBox _textBoxNid, _textBoxName, _textBoxLastName, _textBoxTelephone, _textBoxUser, _textBoxEmail, _textBoxPass;
        private string fileName, filePath;

        public UserViewModel()
        {

        }

        public UserViewModel(object[] campos)
        {
            UserTitle = "Registrar usuarios";
            _textBoxNid = (TextBox)campos[0];
            _textBoxName = (TextBox)campos[1];
            _textBoxLastName = (TextBox)campos[2];
            _textBoxTelephone = (TextBox)campos[3];
            _textBoxUser = (TextBox)campos[4];
            _textBoxEmail = (TextBox)campos[5];
            _textBoxPass = (TextBox)campos[6];
            _conn = new Connections();
        }
        public ICommand AddCommand
        {
            get
            {
                return new CommandHandler(() => App.mContentFrame.Navigate(typeof(AddUser)));
            }
        }

        public ICommand AddUser
        {
            get { return new CommandHandler(async () => await RegisterUserAsync()); }
        }

        public async Task RegisterUserAsync()
        {
            if (Nid == null|| Nid.Equals(""))
            {
                UserTitle = "Ingrese el nid";
                _textBoxNid.Focus(FocusState.Programmatic);
            }
            else
            {
                if (Name == null || Name.Equals(""))
                {
                    UserTitle = "Ingrese el nombre";
                    _textBoxName.Focus(FocusState.Programmatic);
                }
                else
                {
                    if (LastName == null || LastName.Equals(""))
                    {
                        UserTitle = "Ingrese el apellido";
                        _textBoxLastName.Focus(FocusState.Programmatic);
                    }
                    else
                    {
                        if (Telephone == null || Telephone.Equals(""))
                        {
                            UserTitle = "Ingrese el numero de telefono";
                            _textBoxTelephone.Focus(FocusState.Programmatic);
                        }
                        else
                        {
                            if (Email == null || Email.Equals(""))
                            {
                                UserTitle = "Ingrese el Email";
                                _textBoxEmail.Focus(FocusState.Programmatic);
                            }
                            else
                            {
                                if (TextBoxEvent.IsValidEmail(Email))
                                {
                                   if(Password == null || Password.Equals(""))
                                    {
                                        UserTitle = "Ingrese el password";
                                        _textBoxPass.Focus(FocusState.Programmatic);
                                    }
                                    else
                                    {
                                        if (User == null || User.Equals(""))
                                        {
                                            UserTitle = "Ingrese el usuario";
                                            _textBoxUser.Focus(FocusState.Programmatic);
                                        }
                                        else
                                        {
                                            if (SelectedRole == null || SelectedRole.Equals(""))
                                            {
                                                UserTitle = "Seleccione un rol";
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    UserTitle = "El email no es correcto";
                                    _textBoxEmail.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
