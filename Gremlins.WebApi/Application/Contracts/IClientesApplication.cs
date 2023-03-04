using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IClientesApplication
    {
        ResponseQuery<List<ClientesDto>> GetClientes();

        ResponseQuery<ClientesDto> GetClientesForDocument(int Documento);

        ResponseQuery<ClientesDto> UpdateCliente(ClientesDto clientesDtoUpdate);
    }
}
