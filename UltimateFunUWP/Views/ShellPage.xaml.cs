using System;

using UltimateFunUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UltimateFunUWP.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        MainViewModel _main;
        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(ContentFrame, navigationView, KeyboardAccelerators);
            _main = new MainViewModel();
        }

        private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            App.mContentFrame = ContentFrame;
            _main.NavView_SelectionChanged(sender, args, ContentFrame);
        }
    }
}
