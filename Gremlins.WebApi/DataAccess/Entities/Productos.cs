using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gremlins.WebApi.DataAccess.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            VentasDetalles = new HashSet<VentasDetalles>();
        }

        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Existencias { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public decimal? Precio { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdDistribuidor { get; set; }

        public virtual Distribuidores IdDistribuidorNavigation { get; set; }
        public virtual ICollection<VentasDetalles> VentasDetalles { get; set; }
    }
}
