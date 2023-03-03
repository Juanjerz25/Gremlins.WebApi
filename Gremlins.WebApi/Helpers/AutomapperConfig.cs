using AutoMapper;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Pais;
using Gremlins.WebApi.DTO.Partido;
using Gremlins.WebApi.DTO.Sesion;

namespace Gremlins.WebApi.Helpers
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
            CreateMap<PartidoDto, Partido>()
                            .AfterMap((input, output) =>
                            {
                                output.FechaFin = input.FechaInicio.Value.AddMinutes(90);
                            })
                            .ReverseMap();

            CreateMap<PaisDto, Pais>().ReverseMap();
            CreateMap<SesionDto, Sesion>().ReverseMap();
            CreateMap<SesionUsuarioDto, SesionUsuario>().ReverseMap();
            CreateMap<ClientesDto, Clientes>().ReverseMap();
        }

    }
}
