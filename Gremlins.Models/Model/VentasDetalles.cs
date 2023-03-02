using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class VentasDetalles
    {
        public int IdVenta { get; set; }
        public int IdDetalleVenta { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Precio { get; set; }

        public virtual Productos IdProductoNavigation { get; set; }
        public virtual Ventas IdVentaNavigation { get; set; }
    }
}
