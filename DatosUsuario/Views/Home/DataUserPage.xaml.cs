using System;
using System.Collections.Generic;
using DatosUsuario.ViewModels.Home;
using Xamarin.Forms;

namespace DatosUsuario.Views.Home
{
    public partial class DataUserPage : ContentPage
    {
        public DataUserPage()
        {
            InitializeComponent();
            BindingContext = new DataUserPageViewModel();
        }
    }
}
