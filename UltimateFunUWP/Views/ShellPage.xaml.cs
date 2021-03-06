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
            ViewModel.Initialize(frame, navigationView, KeyboardAccelerators);
            _main = new MainViewModel();
            
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            App.mContentFrame = frame;
            _main.NavView_SelectionChanged(sender, args, frame);
        }


    }
}
