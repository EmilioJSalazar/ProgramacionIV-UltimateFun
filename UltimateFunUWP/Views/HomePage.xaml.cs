using System;

using UltimateFunUWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace UltimateFunUWP.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage()
        {
            InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PeliculasPage));

        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(VideojuegosPage));

        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CancionesPage));

        }
    }
}
