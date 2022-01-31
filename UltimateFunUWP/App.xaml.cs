using LoginConnection;
using LoginModelsUWP;
using System;
using System.Linq;
using UltimateFunUWP.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace UltimateFunUWP
{
    public sealed partial class App : Application
    {
        public static FrameworkElement mContentFrame { get; set; }
        private SQLiteConnections _sqlite = new SQLiteConnections();
        private String date = DateTime.Now.ToString("dd/MM/yyy");
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();
            UnhandledException += OnAppUnhandledException;

            // Deferred execution until used. Check https://docs.microsoft.com/dotnet/api/system.lazy-1 for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        }

        private ActivationService CreateActivationService()
        {
            var user = _sqlite.Connection.Table<TUsers>().Where(u => u.Date.Equals(date)).ToList();
            if (0 < user.Count)
            {
                return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
            }
            else
            {
                _sqlite.Connection.DeleteAll<TUsers>();
                return new ActivationService(this, typeof(Views.Users.Login), new Lazy<UIElement>(CreateShell));
            }
            
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
