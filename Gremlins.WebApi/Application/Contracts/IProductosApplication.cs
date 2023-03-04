using Gremlins.WebApi.DTO.Productos;
using Gremlins.WebApi.DTO.Response;
using System.Collections.Generic;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IProductosApplication
    {
        ResponseQuery<List<ProductosDto>> GetProductos();

        ResponseQuery<ProductosDto> GetProductosForId(int idProducto);

        ResponseQuery<ProductosDto> UpdateProductos(ProductosDto clientesDtoUpdate);
    }
}
