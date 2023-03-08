using Gremlins.WebApi.DTO.Response;
using System;
using System.Threading.Tasks;

namespace Gremlins.WebApi.DTO.Clientes
{
    public class ClientesDto
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public decimal? Telefono { get; set; }
        public bool? Habilitado { get; set; }

       
    }
}
