using Gremlins.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlins.WebApi.DataAccess.Repositories.Contracts
{
    internal interface IVentaRepository
    {
        Ventas FindVentas(Expression<Func<Ventas, bool>> expression);
        void InsertVentaDetalle(VentasDetalles ventasDetalles);
        void InsertVentas(Ventas sesion);
        IEnumerable<Ventas> ListVentas();
        IEnumerable<Ventas> ListVentas(Expression<Func<Ventas, bool>> expression);
        void UpdateVentaDetalle(VentasDetalles ventaDetalles);
        void UpdateVentas(Ventas sesion);
    }
}