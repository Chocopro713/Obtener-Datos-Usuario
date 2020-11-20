using System;
namespace DatosUsuario.Services.Request
{
    using Fusillade;

    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
