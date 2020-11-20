namespace DatosUsuario.Services.Routing
{
    using System;
    using System.Threading.Tasks;

    public interface IRoutingService
    {
        // URL BASE
        // https://mallibone.com/post/xamarin-forms-shell-login
        // https://github.com/mallibone/ShellLoginSample

        Task GoBack();
        Task GoBackModal();
        Task NavigateTo(string route);
    }
}
