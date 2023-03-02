using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    interface IUserAdminRepository
    {
        UserAdmin Find(Expression<Func<UserAdmin, bool>> expression);
    }
}
