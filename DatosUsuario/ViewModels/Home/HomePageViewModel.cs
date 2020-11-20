using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DatosUsuario.Model.Home;
using DatosUsuario.Services.Routing;
using Newtonsoft.Json;
using Splat;
using Xamarin.Forms;

namespace DatosUsuario.ViewModels.Home
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Attributes
        private IRoutingService _navigationService;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public bool IsAuthVisible { get; set; }
        #endregion

        #region Properties
        public ICommand AuthenticateCommand { get; set; }
        public ICommand ListUsersCommand { get; set; }

        public ICommand RefreshCommand => new Command(InitHome);
        #endregion

        #region Constructor
        public HomePageViewModel(IRoutingService navigationService = null)
        {
            // Variables
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();

            // Commands
            AuthenticateCommand = new Command(OnAuthenticateCommand);
            ListUsersCommand = new Command(OnListUsersCommand);

            // Methods
            InitHome();
            InitMessaginCenter();
        }
        #endregion

        #region Messaging center
        private void InitMessaginCenter()
        {
            MessagingCenter.Subscribe<string>(this, MessagingKeys.RegisterUser, (sender) => RegisteredUser());
        }
        #endregion Messaging center

        #region Methods
        public async void InitHome()
        {
            // Llamamos al servicio API
            this.PageDialog.ShowLoading("Cargando información");
            var apiUsers = await ApiManager.GetDataUsers();
            if (!apiUsers.IsSuccessStatusCode)
            {
                this.PageDialog.HideLoading();
                await PageDialog.AlertAsync("Algo salió mal, no se pueden obtener datos", "Error", "Aceptar");
                return;
            }
            var jsonResponse = await apiUsers.Content.ReadAsStringAsync();
            var responseAlistamiento = await Task.Run(() => JsonConvert.DeserializeObject<List<HomeModel>>(jsonResponse));
            GlobalSetting.GetInstance().Users = responseAlistamiento;
            this.PageDialog.HideLoading();
        }

        public void RegisteredUser()
        {
            if (GlobalSetting.GetInstance().UserAuth != null)
            {
                this.IsAuthVisible = true;
                this.Name = GlobalSetting.GetInstance().UserAuth.Name;
                this.Email = GlobalSetting.GetInstance().UserAuth.Email;
                this.Phone = GlobalSetting.GetInstance().UserAuth.Phone;
                this.Website = GlobalSetting.GetInstance().UserAuth.Website;
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Nos redirije a la pagina del login
        /// </summary>
        /// <param name="obj"></param>
        private async void OnAuthenticateCommand(object obj)
        {
            if (GlobalSetting.GetInstance().Users == null)
            {
                await PageDialog.AlertAsync("No fue posible acceder sin datos, recarga otra vez la pagina", "Error", "Aceptar");
                return;
            }
            await _navigationService.NavigateTo($"///login");
        }

        /// <summary>
        /// Nos redirije a la lista de usuarios
        /// </summary>
        /// <param name="obj"></param>
        private async void OnListUsersCommand(object obj)
        {
            if (GlobalSetting.GetInstance().Users == null)
            {
                await PageDialog.AlertAsync("No fue posible acceder sin datos, recarga otra vez la pagina", "Error", "Aceptar");
                return;
            }
            await _navigationService.NavigateTo($"///users");
        }
        #endregion
    }
}
