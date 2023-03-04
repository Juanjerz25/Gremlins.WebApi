using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    public interface IClientesRepository
    {
        IEnumerable<Clientes> List();
        Clientes Find(Expression<Func<Clientes, bool>> expression);

        void Update(Clientes clientes);

    }
}