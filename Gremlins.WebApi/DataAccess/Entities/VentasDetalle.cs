using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gremlins.WebApi.DataAccess.Entities
{
    public partial class VentasDetalles
    {
        public int IdVenta { get; set; }
        public int IdDetalleVenta { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public bool? Habilitado { get; set; }
        public virtual Productos IdProductoNavigation { get; set; }
        public virtual Ventas IdVentaNavigation { get; set; }
    }
}
