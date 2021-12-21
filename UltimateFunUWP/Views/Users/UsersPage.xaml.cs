using System;

using UltimateFunUWP.ViewModels;
using UltimateFunUWP.Views.Users;
using Windows.UI.Xaml.Controls;

namespace UltimateFunUWP.Views
{
    public sealed partial class UsersPage : Page
    {
        public UsersViewModel ViewModel { get; } = new UsersViewModel();

        public UsersPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


        }


        private void RegisterButtonTextBlock_OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Registro));
        }
    }
}
