using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DatosUsuario.Model.Home;
using DatosUsuario.Services.Routing;
using Splat;
using Xamarin.Forms;

namespace DatosUsuario.ViewModels.Home
{
    public class UsersPageViewModel : BaseViewModel
    {
        #region Attributes
        private IRoutingService _navigationService;
        #endregion

        #region Properties
        public ObservableCollection<HomeModel> Users { get; set; }

        public ICommand SelectUserCommand { get; set; }
        public ICommand BackCommand { get; set; }
        #endregion

        #region Constructor
        public UsersPageViewModel(IRoutingService navigationService = null)
        {
            // Variables
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            this.Users = new ObservableCollection<HomeModel>(GlobalSetting.GetInstance().Users);

            // Commands
            SelectUserCommand = new Command<HomeModel>(OnSelectUserCommand);
            BackCommand = new Command(OnBackCommand);
        }
        #endregion

        #region Methods
        #endregion

        #region Commands
        // Ve el detalle del usuario
        private async void OnSelectUserCommand(HomeModel user)
        {
            GlobalSetting.GetInstance().UserSelect = user;
            MessagingCenter.Send("Ok", MessagingKeys.UserSelected);
            await _navigationService.NavigateTo($"///datauser");
        }

        // Vuelve a la pagina anterior
        private async void OnBackCommand(object obj)
        {
            await _navigationService.NavigateTo($"///home");
        }
        #endregion
    }
}
