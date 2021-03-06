using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFunUWP.Models
{
    public class UserModel : PropertyChangedNotification
    {
        public string Email
        {
            get { return GetValue(() => Email); }
            set
            {
                SetValue(() => Email, value);
                EmailMessage = "";
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public string Password
        {
            get { return GetValue(() => Password); }
            set
            {
                SetValue(() => Password, value);
                PasswordMessage = "";
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public string Nid
        {
            get { return GetValue(() => Nid); }
            set
            {
                SetValue(() => Nid, value);
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public string Name
        {
            get { return GetValue(() => Name); }
            set
            {
                SetValue(() => Name, value);
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public string LastName
        {
            get { return GetValue(() => LastName); }
            set
            {
                SetValue(() => LastName, value);
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public string Telephone
        {
            get { return GetValue(() => Telephone); }
            set
            {
                SetValue(() => Telephone, value);
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public string User
        {
            get { return GetValue(() => User); }
            set
            {
                SetValue(() => User, value);
                Message = "";
                UserTitle = "Registrar usuario";
            }
        }

        public List<string> ListRoles
        {
            get
            {
                return new List<string>
                {
                    "Admin","User"
                };
            }
        }
        public string SelectedRole
        {
            get { return GetValue(() => SelectedRole); }
            set {
                SetValue(() => SelectedRole, value);
                UserTitle = "Registrar usuario";
            }
        }

        public string UserTitle
        {
            get { return GetValue(() => UserTitle); }
            set
            {
                if (UserTitle == null || UserTitle.Equals(""))
                {
                    SetValue(() => UserTitle, "Registrar usuarios");
                }
                else
                {
                    SetValue(() => UserTitle, value);
                }
            }
        }

        public string Message
        {
            get { return GetValue(() => Message); }
            set { SetValue(() => Message, value); }
        }
        public string EmailMessage
        {
            get { return GetValue(() => EmailMessage); }
            set { SetValue(() => EmailMessage, value); }
        }
        public string PasswordMessage
        {
            get { return GetValue(() => PasswordMessage); }
            set { SetValue(() => PasswordMessage, value); }
        }
    }
}
