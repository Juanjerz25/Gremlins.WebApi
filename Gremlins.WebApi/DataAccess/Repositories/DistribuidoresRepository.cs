using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    public class DistribuidoresRepository : IDistribuidoresRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        public DistribuidoresRepository(GremlinsDbContext gremlinsDbContext)
        {
            _context = gremlinsDbContext;

        }
        #region Methods

        public IEnumerable<Distribuidores> List()
        {
            return _context.Set<Distribuidores>().AsNoTracking().OrderBy(x => x.Nombres).ToList();
        }
        public Distribuidores Find(Expression<Func<Distribuidores, bool>> expression)
        {
            return _context.Set<Distribuidores>().AsNoTracking().FirstOrDefault(expression);
        }
        public void Update(Distribuidores distribuidores)
        {
            _context.Distribuidores.Update(distribuidores);
            _context.SaveChanges();
        }
        #endregion
    }
}
