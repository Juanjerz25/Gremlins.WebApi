using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class Ventas
    {
        public Ventas()
        {
            VentasDetalles = new HashSet<VentasDetalles>();
        }

        public int IdVenta { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public decimal? ValorTotal { get; set; }
        public bool? Habilitado { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual ICollection<VentasDetalles> VentasDetalles { get; set; }
    }
}
