using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    public interface IUsuariosRepository
    {
        Usuarios Find(Expression<Func<Usuarios, bool>> expression);
    }
}