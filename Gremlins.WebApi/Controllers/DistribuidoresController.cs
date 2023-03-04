using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Distribuidores;
using Gremlins.WebApi.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidoresController : ControllerBase
    {
        #region Fields
        private readonly IDistribuidoresApplication _distribuidoresApplication;

        #endregion
        public DistribuidoresController(IDistribuidoresApplication distribuidoresApplication)
        {
            _distribuidoresApplication = distribuidoresApplication;
        }
        #region Methods

        /// <summary>
        /// Consultar todos los Distribuidores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(DistribuidoresController.GetDistribuidores))]
        public async Task<ResponseQuery<List<DistribuidoresDto>>> GetDistribuidores()
        {
            return await Task.Run(() =>
            {
                return _distribuidoresApplication.GetDistribuidores();
            });
        }
        /// <summary>
        /// Consultar los Distribuidores por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(DistribuidoresController.GetDistribuidoresForId))]
        public async Task<ResponseQuery<DistribuidoresDto>> GetDistribuidoresForId(int idDistribuidor)
        {
            return await Task.Run(() =>
            {
                return _distribuidoresApplication.GetDistribuidoresForId(idDistribuidor);
            });
        }
        /// <summary>
        /// ACtualizar Distribuidores
        /// </summary>
        /// <param name="distribuidorActualizado"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<ResponseQuery<DistribuidoresDto>> ActualizarDistribuidor([FromBody] DistribuidoresDto distribuidorActualizado)
        {
            return await Task.Run(() =>
            {
                return _distribuidoresApplication.UpdateDistribuidores(distribuidorActualizado);
            });
        }
        #endregion
    }
}
