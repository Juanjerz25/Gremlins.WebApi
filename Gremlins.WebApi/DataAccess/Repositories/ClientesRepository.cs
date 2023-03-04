using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    class ClientesRepository : IClientesRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        #region Builders

        public ClientesRepository(GremlinsDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods

        public IEnumerable<Clientes> List()
        {
            return _context.Set<Clientes>().AsNoTracking().OrderBy(x=> x.NombreCompleto).ToList();
        }
        public Clientes Find(Expression<Func<Clientes, bool>> expression)
        {
            return _context.Set<Clientes>().AsNoTracking().FirstOrDefault(expression);
        }
        public void Update(Clientes clientes)
        {
            _context.Clientes.Update(clientes);
            _context.SaveChanges();
        }
        #endregion

    }
}
