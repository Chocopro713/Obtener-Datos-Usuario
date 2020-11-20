using System;
using System.Collections.Generic;
using DatosUsuario.ViewModels.Home;
using Xamarin.Forms;

namespace DatosUsuario.Views.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
    }
}
