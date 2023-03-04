using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    class UsuariosRepository : IUsuariosRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        #region Builders

        public UsuariosRepository(GremlinsDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods

        public IEnumerable<Usuarios> List()
        {
            return _context.Set<Usuarios>().AsNoTracking().ToList();
        }
        public Usuarios Find(Expression<Func<Usuarios, bool>> expression)
        {
            return _context.Set<Usuarios>().AsNoTracking().FirstOrDefault(expression);
        }
        public void Update(Usuarios usuarios)
        {
            _context.Usuarios.Update(usuarios);
            _context.SaveChanges();
        }
        #endregion

    }
}
