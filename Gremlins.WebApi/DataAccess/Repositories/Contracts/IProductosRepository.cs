using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    public interface IProductosRepository
    {
        IEnumerable<Productos> List();
        Productos Find(Expression<Func<Productos, bool>> expression);

        void Update(Productos productos);

    }
}