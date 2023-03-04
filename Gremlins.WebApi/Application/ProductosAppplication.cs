using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Productos;
using Gremlins.WebApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gremlins.WebApi.Application
{
    public class ProductosAppplication : IProductosApplication
    {
        #region Fields
        private readonly IProductosRepository _productosRepository;
        private readonly IMapper mapper;
        #endregion
        #region Builders


        public ProductosAppplication(IProductosRepository productosRepository, IMapper mapper)
        {
            _productosRepository = productosRepository;
            this.mapper = mapper;
        }
        #endregion
        public ResponseQuery<List<ProductosDto>> GetProductos()
        {
            ResponseQuery<List<ProductosDto>> response = new ResponseQuery<List<ProductosDto>>();
            try
            {
                var productosList = _productosRepository.List();


                var productoDtoList = mapper.Map<List<ProductosDto>>(productosList);
                response.Result = productoDtoList.ToList();

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
        public ResponseQuery<ProductosDto> GetProductosForId(int idProducto)
        {
            ResponseQuery<ProductosDto> response = new ResponseQuery<ProductosDto>();
            try
            {
                var productosList = _productosRepository.Find(c => c.IdProducto == idProducto);


                var productoDto = mapper.Map<ProductosDto>(productosList);
                response.Result = productoDto;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        public ResponseQuery<ProductosDto> UpdateProductos(ProductosDto productosDtoUpdate)
        {
            ResponseQuery<ProductosDto> response = new ResponseQuery<ProductosDto>();
            try
            {
                
                var productoUpdate= mapper.Map<Productos>(productosDtoUpdate);
                _productosRepository.Update(productoUpdate);
                
                response.Result = productosDtoUpdate;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
    }
}
