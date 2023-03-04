using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Productos;
using Gremlins.WebApi.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        #region Fields
        private readonly IProductosApplication _productosApplication;

        #endregion
        public ProductosController(IProductosApplication productosApplication)
        {
            _productosApplication = productosApplication;
        }
        #region Methods

       /// <summary>
       /// Consultar todos los productos
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        [Route(nameof(ProductosController.GetProductos))]
        public async Task<ResponseQuery<List<ProductosDto>>> GetProductos()
        {
            return await Task.Run(() =>
            {
                return _productosApplication.GetProductos();
            });
        }
        /// <summary>
        /// Consultar los productos por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(ProductosController.GetProductosForId))]
        public async Task<ResponseQuery<ProductosDto>> GetProductosForId(int idProducto)
        {
            return await Task.Run(() =>
            {
                return _productosApplication.GetProductosForId(idProducto);
            });
        }
        /// <summary>
        /// ACtualizar productos
        /// </summary>
        /// <param name="productoActualizado"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<ResponseQuery<ProductosDto>> ActualizarProducto([FromBody] ProductosDto productoActualizado)
        {
            return await Task.Run(() =>
            {
                return _productosApplication.UpdateProductos(productoActualizado);
            });
        }
        #endregion
    }
}
