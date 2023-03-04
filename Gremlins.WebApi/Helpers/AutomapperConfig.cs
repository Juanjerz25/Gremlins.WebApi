using AutoMapper;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Distribuidores;
using Gremlins.WebApi.DTO.Productos;
using Gremlins.WebApi.DTO.Ventas;

namespace Gremlins.WebApi.Helpers
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
            CreateMap<ClientesDto, Clientes>().ReverseMap();
            CreateMap<ProductosDto, Productos>().ReverseMap();
            CreateMap<DistribuidoresDto, Distribuidores>().ReverseMap();
            CreateMap<VentasDto, Ventas>().ReverseMap();
            CreateMap<VentasDetalleDto, VentasDetalles>().ReverseMap();
        }

    }
}
