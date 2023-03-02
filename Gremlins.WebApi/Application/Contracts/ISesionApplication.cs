using Gremlins.WebApi.DTO.Partido;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Sesion;
using Gremlins.WebApi.DTO.UserAdmin;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface ISesionApplication
    {
        ResponseQuery<List<SesionDto>> GetSesiones();
        ResponseQuery<int> ManageSesion(SesionDto request);
    }
}
