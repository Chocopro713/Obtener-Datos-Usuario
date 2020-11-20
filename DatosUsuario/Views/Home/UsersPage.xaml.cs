using System;
using System.Collections.Generic;
using DatosUsuario.ViewModels.Home;
using Xamarin.Forms;

namespace DatosUsuario.Views.Home
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
            BindingContext = new UsersPageViewModel();
        }
    }
}
