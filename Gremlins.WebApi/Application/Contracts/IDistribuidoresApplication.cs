using Gremlins.WebApi.DTO.Distribuidores;
using Gremlins.WebApi.DTO.Response;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IDistribuidoresApplication
    {
        ResponseQuery<List<DistribuidoresDto>> GetDistribuidores();

        ResponseQuery<DistribuidoresDto> GetDistribuidoresForId(int idDistribuidor);

        ResponseQuery<DistribuidoresDto> UpdateDistribuidores(DistribuidoresDto distribuidoresDtoUpdate);
    }
}
