using System;
using System.Windows.Input;
using DatosUsuario.Services.Routing;
using Splat;
using Xamarin.Forms;

namespace DatosUsuario.ViewModels.Home
{
    public class DataUserPageViewModel : BaseViewModel
    {
        #region Attributes
        private IRoutingService _navigationService;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        #endregion

        #region Properties
        public ICommand BackCommand { get; set; }
        #endregion

        #region Constructor
        public DataUserPageViewModel(IRoutingService navigationService = null)
        {
            // Variables
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();

            // Commands
            BackCommand = new Command(OnBackCommand);

            // Methods
            InitDataUser();
            InitMessaginCenter();
        }
        #endregion

        #region Messaging center
        private void InitMessaginCenter()
        {
            MessagingCenter.Subscribe<string>(this, MessagingKeys.UserSelected, (sender) => InitDataUser());
        }
        #endregion Messaging center

        #region Methods
        public void InitDataUser()
        {
            this.Id = GlobalSetting.GetInstance().UserSelect.Id;
            this.Name = GlobalSetting.GetInstance().UserSelect.Name;
            this.Age = GlobalSetting.GetInstance().UserSelect.Age;
            this.Email = GlobalSetting.GetInstance().UserSelect.Email;
            this.Phone = GlobalSetting.GetInstance().UserSelect.Phone;
            this.Website = GlobalSetting.GetInstance().UserSelect.Website;
        }
        #endregion

        #region Commands
        // Vuelve a la pagina anterior
        private async void OnBackCommand(object obj)
        {
            await _navigationService.NavigateTo($"///users");
        }
        #endregion
    }
}
