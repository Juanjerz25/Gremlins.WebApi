using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gremlins.WebApi.Application
{
    public class ClientesApplication : IClientesApplication
    {
        #region Fields
        private readonly IClientesRepository _clientesRepository;
        private readonly IMapper mapper;
        #endregion
        #region Builders


        public ClientesApplication(IClientesRepository clientesRepository, IMapper mapper)
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


                var clienteDtoList = mapper.Map<List<ClientesDto>>(clientesList);
                response.Result = clienteDtoList.ToList();

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
        public ResponseQuery<ClientesDto> GetClientesForDocument(int Documento)
        {
            ResponseQuery<ClientesDto> response = new ResponseQuery<ClientesDto>();
            try
            {
                var clientesList = _clientesRepository.Find(c => c.NumeroDocumento == Documento.ToString());


                var clienteDto = mapper.Map<ClientesDto>(clientesList);
                response.Result = clienteDto;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        public ResponseQuery<ClientesDto> UpdateCliente(ClientesDto clientesDtoUpdate)
        {
            ResponseQuery<ClientesDto> response = new ResponseQuery<ClientesDto>();
            try
            {
                //var clientesList = _clientesRepository.Find(c => c.NumeroDocumento == Documento.ToString());
                var clienteUpdate= mapper.Map<Clientes>(clientesDtoUpdate);
                 _clientesRepository.Update(clienteUpdate);
                
                response.Result = clientesDtoUpdate;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
    }
}
