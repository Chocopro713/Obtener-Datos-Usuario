using System;
using System.Windows.Input;
using DatosUsuario.Services.Routing;
using Splat;
using Xamarin.Forms;

namespace DatosUsuario.ViewModels.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Attributes
        private IRoutingService _navigationService;
        #endregion

        #region Properties
        public string User { get; set; }
        public string Pass { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand BackCommand { get; set; }
        #endregion

        #region Constructor
        public LoginPageViewModel(IRoutingService navigationService = null)
        {
            // Variables
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();

            // Commands
            LoginCommand = new Command(OnLoginCommand);
            BackCommand = new Command(OnBackCommand);
        }
        #endregion

        #region Methods
        #endregion

        #region Commands
        /// <summary>
        /// Valida si se autentico y lo dijire hacia Home
        /// </summary>
        /// <param name="obj"></param>
        private async void OnLoginCommand(object obj)
        {
            var userAuth = GlobalSetting.GetInstance().Users.Find(a => a.Username == this.User && a.Password == this.Pass);
            if(userAuth == null)
            {
                await this.PageDialog.AlertAsync("No se pudo encontrar ningun usuario", "Error", "Aceptar");
                return;
            }
            GlobalSetting.GetInstance().UserAuth = userAuth;
            MessagingCenter.Send("Ok", MessagingKeys.RegisterUser);
            await _navigationService.NavigateTo($"///home");
        }

        // Vuelve a la pagina anterior
        private async void OnBackCommand(object obj)
        {
            await _navigationService.NavigateTo($"///home");
        }
        #endregion
    }
}
