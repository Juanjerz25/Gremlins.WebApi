using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DTO.Partido;
using System.Collections.Generic;

namespace Gremlins.WebApi.DTO.Sesion
{
    public class SesionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EntryCode { get; set; }
        public int? PartidoId { get; set; }
        public bool? Status { get; set; }
        public PartidoDto Partido { get; set; }
        public  ICollection<SesionUsuarioDto> SesionUsuario { get; set; }
    }
}
