using Gremlins.WebApi.DataAccess.Entities;
using System.Collections.Generic;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    public interface IClientesRepository
    {
        IEnumerable<Clientes> List();
    }
}