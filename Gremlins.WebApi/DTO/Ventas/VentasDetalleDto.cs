using Gremlins.WebApi.DTO.Productos;
using System.Text.Json.Serialization;

namespace Gremlins.WebApi.DTO.Ventas
{
    public class VentasDetalleDto
    {
        public int IdVenta { get; set; }
        public int IdDetalleVenta { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public bool? Habilitado { get; set; } 
        [JsonIgnore]
        public virtual ProductosDto IdProductoNavigation { get; set; }
        [JsonIgnore]
        public virtual VentasDto IdVentaNavigation { get; set; }
    }
}
