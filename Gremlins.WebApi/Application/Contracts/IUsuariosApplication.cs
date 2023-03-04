using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Usuarios;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IUsuariosApplication
    {
        public ResponseQuery<int> FindUsuario(RequestLogin requestLogin);
    }
}
