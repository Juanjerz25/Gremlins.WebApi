using Gremlins.WebApi.DTO.Productos;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gremlins.WebApi.DTO.Distribuidores
{
    public class DistribuidoresDto
    {
        public int IdDistribuidor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public decimal? NumeroTelefonico { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        [JsonIgnore]
        public  ICollection<ProductosDto> Productos { get; set; }
    }
}
