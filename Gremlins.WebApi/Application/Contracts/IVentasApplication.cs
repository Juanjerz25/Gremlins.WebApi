
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Ventas;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IVentasApplication
    {
        ResponseQuery<List<VentasDto>> GetVentas();
        ResponseQuery<List<VentasDetalleDto>> GetVentasDetalles();
        ResponseQuery<int> ManageVentas(VentasDto request);
        ResponseQuery<int> ManageVentasDetalles(VentasDetalleDto request);
    }
}
