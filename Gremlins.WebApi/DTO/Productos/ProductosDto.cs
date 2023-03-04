using Gremlins.WebApi.DTO.Distribuidores;
using Gremlins.WebApi.DTO.Ventas;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gremlins.WebApi.DTO.Productos
{
    public class ProductosDto
    {

        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Existencias { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public decimal? Precio { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdDistribuidor { get; set; }

        public DistribuidoresDto IdDistribuidorNavigation { get; set; }
        [JsonIgnore]
        public ICollection<VentasDetalleDto> VentasDetalles { get; set; }
    }
}
