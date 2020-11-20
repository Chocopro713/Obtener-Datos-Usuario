namespace DatosUsuario.Services.Request
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IApiManager
    {
        Task<HttpResponseMessage> GetDataUsers();
    }
}
