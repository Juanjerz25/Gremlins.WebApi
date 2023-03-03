﻿using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    class PaisRepository : IPaisRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        #region Builders

        public PaisRepository(GremlinsDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods

        public IEnumerable<Pais> List()
        {
            return _context.Set<Pais>().AsNoTracking().OrderBy(x=> x.Nombre).ToList();
        }

        #endregion

    }
}
