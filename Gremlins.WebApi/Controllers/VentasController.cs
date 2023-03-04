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
        [Route(nameof(VentasController.ManageSesion))]
        public async Task<ResponseQuery<int>> ManageSesion(VentasDto request)
        {
            return await Task.Run((System.Func<ResponseQuery<int>>)(() =>
            {
                return (ResponseQuery<int>)_sesionApplication.ManageVentas(request);
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

        #endregion
    }
}
