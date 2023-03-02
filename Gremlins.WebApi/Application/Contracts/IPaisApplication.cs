using Gremlins.WebApi.DTO.Pais;
using Gremlins.WebApi.DTO.Partido;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.UserAdmin;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IPaisApplication
    {
        ResponseQuery<List<PaisDto>> GetPaises();
    }
}
