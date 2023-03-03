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
    class PartidoRepository : IPartidoRepository
    {
        #region Fields
        protected readonly GremlinsDbContext _context;
        #endregion

        #region Builders

        public PartidoRepository(GremlinsDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public Partido Find(Expression<Func<Partido, bool>> expression)
        {
            return _context.Set<Partido>().AsNoTracking().FirstOrDefault(expression);
        }

        public IEnumerable<Partido> List(Expression<Func<Partido, bool>> expression)
        {
            return _context.Set<Partido>().Include(s => s.Team1).Include(s => s.Team2).AsNoTracking().Where(expression).ToList();
        }
        public IEnumerable<Partido> List()
        {
            return _context.Set<Partido>().Include(s=> s.Team1).Include(s=> s.Team2).AsNoTracking().ToList();
        }

        public void Insert(Partido partido)
        {
            _context.Partido.Add(partido);
            _context.SaveChanges();            
        }

        public void Update(Partido partido)
        {
            var originalPartido = _context.Partido.FirstOrDefault(x => x.Id == partido.Id);
            FrammeworkTypeUtility.SetProperties(partido, originalPartido);
            _context.SaveChanges();
        }
        #endregion

    }
}
