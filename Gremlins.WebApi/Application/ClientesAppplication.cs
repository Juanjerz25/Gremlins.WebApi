using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Application
{
    public class ClientesAppplication : IClientesApplication
    {
        #region Fields
        private readonly IClientesRepository _clientesRepository;
        private readonly IMapper mapper;
        #endregion
        #region Builders

       
        public ClientesAppplication(IClientesRepository clientesRepository , IMapper mapper)
        {
            _clientesRepository = clientesRepository;
            this.mapper = mapper;
        }
        #endregion
        public ResponseQuery<List<ClientesDto>> GetClientes()
        {
            ResponseQuery<List<ClientesDto>> response = new ResponseQuery<List<ClientesDto>>();
            try
            {
                var clientesList = _clientesRepository.List();


                var partidoDtoList = mapper.Map<List<ClientesDto>>(clientesList);
                response.Result = partidoDtoList.ToList();

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
    }
}
