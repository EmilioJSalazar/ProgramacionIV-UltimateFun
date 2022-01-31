using LoginConnection;
using LoginModelsUWP;
using System;
using System.Linq;
using UltimateFunUWP.Services;
using UltimateFunUWP.Views;
using UltimateFunUWP.Views.Users;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UltimateFunUWP
{
    public sealed partial class App : Application
    {
        public static Frame mContentFrame { get; set; }
        private SQLiteConnections _sqlite = new SQLiteConnections();
        private String date = DateTime.Now.ToString("dd/MM/yyy");
        //private Lazy<ActivationService> _activationService;

        //private ActivationService ActivationService
        //{
        //    get { return _activationService.Value; }
        //}

        public App()
        {
            InitializeComponent();
            this.Suspending += OnSuspending;
            //UnhandledException += OnAppUnhandledException;

            //// Deferred execution until used. Check https://docs.microsoft.com/dotnet/api/system.lazy-1 for further info on Lazy<T> class.
            //_activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            //if (!args.PrelaunchActivated)
            //{
            //    await ActivationService.ActivateAsync(args);
            //}
            if(rootFrame==null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if(e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }
                Window.Current.Content = rootFrame;
            }

            if(e.PrelaunchActivated == false)
            {
                if(rootFrame.Content == null)
                {
                    var user = _sqlite.Connection.Table<TUsers>().Where(u => u.Date.Equals(date)).ToList();
                    if (0 < user.Count)
                    {
                        rootFrame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        _sqlite.Connection.DeleteAll<TUsers>();
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    }
                    
                }
                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
        //protected override async void OnActivated(IActivatedEventArgs args)
        //{
        //    await ActivationService.ActivateAsync(args);
        //}

        //private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        //{
        //    // TODO WTS: Please log and handle the exception as appropriate to your scenario
        //    // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        //}

        //private ActivationService CreateActivationService()
        //{
        //    var user = _sqlite.Connection.Table<TUsers>().Where(u => u.Date.Equals(date)).ToList();
        //    if (0 < user.Count)
        //    {
        //        return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
        //    }
        //    else
        //    {
        //        _sqlite.Connection.DeleteAll<TUsers>();
        //        return new ActivationService(this, typeof(Views.Users.Login), new Lazy<UIElement>(CreateShell));
        //    }
            
        //}

        //private UIElement CreateShell()
        //{
        //    return new Views.ShellPage();
        //}
    }
}
