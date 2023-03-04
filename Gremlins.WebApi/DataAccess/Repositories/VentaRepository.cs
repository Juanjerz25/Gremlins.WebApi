using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories
{
    class VentaRepository : IVentaRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        #region Builders

        public VentaRepository(GremlinsDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public Ventas FindVentas(Expression<Func<Ventas, bool>> expression)
        {
            return _context.Set<Ventas>().AsNoTracking().FirstOrDefault(expression);
        }

        public IEnumerable<Ventas> ListVentas(Expression<Func<Ventas, bool>> expression)
        {
            return _context.Set<Ventas>().Include(s => s.VentasDetalles).Include(s=> s.IdClienteNavigation).AsNoTracking().Where(expression).ToList();
        }
        public IEnumerable<Ventas> ListVentas()
        {
            return _context.Set<Ventas>().Include(s=> s.VentasDetalles).Include(s => s.IdClienteNavigation).AsNoTracking().ToList();
        }

        public void Insert(Ventas ventas)
        {
            _context.Ventas.Add(ventas);
            _context.SaveChanges();            
        }

        public void Update(Ventas venta)
        {
            var originalVenta = _context.Ventas.FirstOrDefault(x => x.IdVenta == venta.IdVenta);
            FrammeworkTypeUtility.SetProperties(venta, originalVenta);
            _context.SaveChanges();
        }
        #endregion

    }
}
