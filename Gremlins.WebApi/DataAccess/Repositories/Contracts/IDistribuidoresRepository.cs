using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    public interface IDistribuidoresRepository
    {
        IEnumerable<Distribuidores> List();
        Distribuidores Find(Expression<Func<Distribuidores, bool>> expression);

        void Update(Distribuidores distribuidores);
    }
}
