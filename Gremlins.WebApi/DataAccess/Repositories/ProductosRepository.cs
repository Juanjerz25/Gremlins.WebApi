using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    class ProductosRepository : IProductosRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        #region Builders

        public ProductosRepository(GremlinsDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods

        public IEnumerable<Productos> List()
        {
            return _context.Set<Productos>().AsNoTracking().OrderBy(x=> x.Descripcion).ToList();
        }
        public Productos Find(Expression<Func<Productos, bool>> expression)
        {
            return _context.Set<Productos>().AsNoTracking().FirstOrDefault(expression);
        }
        public void Update(Productos productos)
        {
            _context.Productos.Update(productos);
            _context.SaveChanges();
        }
        #endregion

    }
}
