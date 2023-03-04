using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Ventas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class VentasController : ControllerBase
    {
        #region Fields
        private readonly IVentasApplication _sesionApplication;

        #endregion

        #region Builder

        public VentasController(IVentasApplication sesionApplication)
        {
            _sesionApplication = sesionApplication;
        }


        #endregion

        #region Methods

        [HttpPost]
        [Route(nameof(VentasController.ManageVentas))]
        public async Task<ResponseQuery<int>> ManageVentas(VentasDto request)
        {
            return await Task.Run((System.Func<ResponseQuery<int>>)(() =>
            {
                return (ResponseQuery<int>)_sesionApplication.ManageVentas(request);
            }));
        }

        [HttpPost]
        [Route(nameof(VentasController.ManageVentasDetalles))]
        public async Task<ResponseQuery<int>> ManageVentasDetalles(VentasDetalleDto request)
        {
            return await Task.Run((System.Func<ResponseQuery<int>>)(() =>
            {
                return (ResponseQuery<int>)_sesionApplication.ManageVentasDetalles(request);
            }));
        }

        [HttpGet]
        [Route(nameof(VentasController.GetVentas))]
        public async Task<ResponseQuery<List<VentasDto>>> GetVentas()
        {
            return await Task.Run(() =>
            {
                return _sesionApplication.GetVentas();
            });
        }

        [HttpGet]
        [Route(nameof(VentasController.GetVentasDetalles))]
        public async Task<ResponseQuery<List<VentasDetalleDto>>> GetVentasDetalles()
        {
            return await Task.Run(() =>
            {
                return _sesionApplication.GetVentasDetalles();
            });
        }

        #endregion
    }
}
