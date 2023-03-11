using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        /// Consultar los clientes Totales 
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
        /// <summary>
        /// Consultar los clientes por Documento 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(ClientesController.GetClientesForDocument))]
        public async Task<ResponseQuery<ClientesDto>> GetClientesForDocument(int documento)
        {
            return await Task.Run(() =>
            {
                return _clientesApplication.GetClientesForDocument(documento);
            });
        }
        /// <summary>
        /// Actualizar un cliente
        /// </summary>
        /// <param name="clienteActualizado"></param>
        /// <returns></returns>
        [HttpPut("")]
        //[Route(nameof(ClientesController.ActualizarClientes))]
        public async Task<ResponseQuery<ClientesDto>> ActualizarClientes([FromBody] ClientesDto clienteActualizado)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseQuery<ClientesDto> { ErrorMessage = "", Successful = false, Message = "valide los campos vacios" };
            }
            if (!TryValidateModel(clienteActualizado))
            {
                return new ResponseQuery<ClientesDto> { ErrorMessage = "", Successful=false, Message="valide los campos vacios" };
            }
            return await Task.Run(() =>
            {
                return _clientesApplication.UpdateCliente(clienteActualizado);
            });

        }
        #endregion

    }
}
