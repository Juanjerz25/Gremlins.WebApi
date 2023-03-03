using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Clientes;
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
    public class ClientesController : ControllerBase
    {
        #region Fields
        private readonly IClientesApplication _clientesApplication;

        #endregion

        #region builder
        public ClientesController(IClientesApplication clientesApplication)
        {
            _clientesApplication = clientesApplication;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Consultar los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(ClientesController.GetClientes))]
        public async Task<ResponseQuery<List<ClientesDto>>> GetClientes()
        {
            return await Task.Run(() =>
            {
                return _clientesApplication.GetClientes();
            });
        }

        #endregion

    }
}
