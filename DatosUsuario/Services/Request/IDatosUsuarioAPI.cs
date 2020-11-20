using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace DatosUsuario.Services.Request
{
    public interface IDatosUsuarioAPI
    {
        [Get("/users")]
        Task<HttpResponseMessage> GetDataUsers();
    }
}
