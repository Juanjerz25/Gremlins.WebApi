using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    internal interface IVentaRepository
    {
        Ventas Find(Expression<Func<Ventas, bool>> expression);
        void Insert(Ventas sesion);
        IEnumerable<Ventas> List();
        IEnumerable<Ventas> List(Expression<Func<Ventas, bool>> expression);
        void Update(Ventas sesion);
    }
}