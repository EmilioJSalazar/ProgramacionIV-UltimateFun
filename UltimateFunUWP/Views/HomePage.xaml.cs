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
        private void ShowMenu(bool isTransient)
        {
            FlyoutShowOptions myOption = new FlyoutShowOptions();
            myOption.ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard;
            CommandBarFlyout1.ShowAt(Image1, myOption);
        }

        private void MyImageButton_ContextRequested(Windows.UI.Xaml.UIElement sender, ContextRequestedEventArgs args)
        {
            // always show a context menu in standard mode
            ShowMenu(false);
        }

        private void MyImageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ShowMenu((sender as Button).IsPointerOver);
        }

        private void OnElementClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
