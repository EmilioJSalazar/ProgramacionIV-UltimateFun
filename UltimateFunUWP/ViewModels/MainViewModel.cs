using LoginConnection;
using LoginModelsUWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFunUWP.Views;
using UltimateFunUWP.Views.Users;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UltimateFunUWP.ViewModels
{
    
    public class MainViewModel
    {
        private SQLiteConnections _sqlite;
        public MainViewModel()
        {
            _sqlite = new SQLiteConnections();
        }
        public void NavView_SelectionChanged(NavigationView sender,
        NavigationViewSelectionChangedEventArgs args, Frame contentFrame)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag)
            {
                case "close":
                    _sqlite.Connection.DeleteAll<TUsers>();
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(Login));
                    break;
                case "user":
                    contentFrame.Navigate(typeof(Usuarios));

                    break;
                case "null":
                    contentFrame.Navigate(typeof(HomePage));
                    break;
                default:
                    contentFrame.Navigate(typeof(HomePage));
                    break;
            }
        }
    }

    
}
