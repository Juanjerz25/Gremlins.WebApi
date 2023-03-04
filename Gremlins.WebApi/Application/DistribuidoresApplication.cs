using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Distribuidores;
using Gremlins.WebApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gremlins.WebApi.Application
{
    public class DistribuidoresApplication : IDistribuidoresApplication
    {
        #region Fields
        private readonly IDistribuidoresRepository _distribuidoresRepository;
        private readonly IMapper _mapper;
        #endregion
        public DistribuidoresApplication(IDistribuidoresRepository distribuidoresRepository, IMapper mapper)
        {
            _distribuidoresRepository = distribuidoresRepository;
            _mapper = mapper;
        }
        public ResponseQuery<List<DistribuidoresDto>> GetDistribuidores()
        {

            ResponseQuery<List<DistribuidoresDto>> response = new ResponseQuery<List<DistribuidoresDto>>();
            try
            {
                var distribuidoresList = _distribuidoresRepository.List();


                var distribuidoresDtoList = _mapper.Map<List<DistribuidoresDto>>(distribuidoresList);
                response.Result = distribuidoresDtoList.ToList();

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        public ResponseQuery<DistribuidoresDto> GetDistribuidoresForId(int idDistribuidor)
        {
            ResponseQuery<DistribuidoresDto> response = new ResponseQuery<DistribuidoresDto>();
            try
            {
                var distribuidoresList = _distribuidoresRepository.Find(c => c.IdDistribuidor == idDistribuidor);


                var clienteDto = _mapper.Map<DistribuidoresDto>(distribuidoresList);
                response.Result = clienteDto;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        public ResponseQuery<DistribuidoresDto> UpdateDistribuidores(DistribuidoresDto distribuidoresDtoUpdate)
        {
            ResponseQuery<DistribuidoresDto> response = new ResponseQuery<DistribuidoresDto>();
            try
            {

                var distribuidoresUpdate = _mapper.Map<Distribuidores>(distribuidoresDtoUpdate);
                _distribuidoresRepository.Update(distribuidoresUpdate);

                response.Result = distribuidoresDtoUpdate;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
    }
}
