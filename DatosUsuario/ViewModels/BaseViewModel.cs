using System;
using System.ComponentModel;
using Acr.UserDialogs;
using DatosUsuario.Services.Request;

namespace DatosUsuario.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        #region Attributes API
        IApiService<IDatosUsuarioAPI> drugstoreApi = new ApiService<IDatosUsuarioAPI>(GlobalSetting.ApiUrl);
        public IApiManager ApiManager;
        public bool IsBusy { get; set; }
        #endregion Attributes API

        #region Attributes
        public IUserDialogs PageDialog = UserDialogs.Instance;
        #endregion Attributes

        #region Constructor
        public BaseViewModel()
        {
            this.IsBusy = false;
            this.ApiManager = new ApiManager(drugstoreApi);
        }
        #endregion Constructor
    }
}
