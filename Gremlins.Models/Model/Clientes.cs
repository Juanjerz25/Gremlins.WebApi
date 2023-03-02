using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class Clientes
    {
        public Clientes()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public decimal? Telefono { get; set; }
        public bool? Habilitado { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
