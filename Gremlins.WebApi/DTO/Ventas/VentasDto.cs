using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gremlins.WebApi.DTO.Ventas
{
    public class VentasDto
    {
        public int IdVenta { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public decimal? ValorTotal { get; set; }
        public bool? Habilitado { get; set; }
        [JsonIgnore]
        public ClientesDto IdClienteNavigation { get; set; }
        public ICollection<VentasDetalleDto> VentasDetalles { get; set; }
    }
}
