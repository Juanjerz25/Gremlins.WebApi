﻿using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    class UserAdminRepository: IUserAdminRepository
    {
        #region Fields
        protected readonly GoalPredictorDbContext _context;
        #endregion

        #region Builders

        public UserAdminRepository(GoalPredictorDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public UserAdmin Find(Expression<Func<UserAdmin, bool>> expression)
        {
            return _context.Set<UserAdmin>().AsNoTracking().FirstOrDefault(expression);
        }
        #endregion

    }
}
