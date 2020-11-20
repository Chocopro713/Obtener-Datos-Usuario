using System;
using System.Collections.Generic;
using DatosUsuario.ViewModels.Login;
using Xamarin.Forms;

namespace DatosUsuario.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }
}
