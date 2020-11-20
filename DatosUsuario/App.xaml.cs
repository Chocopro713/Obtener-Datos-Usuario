using System;
using DatosUsuario.Services.Routing;
using DatosUsuario.ViewModels.Home;
using DatosUsuario.ViewModels.Login;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DatosUsuario
{
    public partial class App : Application
    {
        public App()
        {

            InitializeDi();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private void InitializeDi()
        {
            // URL BASE
            // https://mallibone.com/post/xamarin-forms-shell-login
            // https://github.com/mallibone/ShellLoginSample

            // Services
            Locator.CurrentMutable.RegisterLazySingleton<IRoutingService>(() => new ShellRoutingService());

            // ViewModels
            Locator.CurrentMutable.Register(() => new LoginPageViewModel());
            Locator.CurrentMutable.Register(() => new HomePageViewModel());
            Locator.CurrentMutable.Register(() => new DataUserPageViewModel());
            Locator.CurrentMutable.Register(() => new UsersPageViewModel());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
