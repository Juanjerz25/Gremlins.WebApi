using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Pais;
using Gremlins.WebApi.DTO.Partido;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.UserAdmin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gremlins.WebApi.Application
{
    class PaisApplication : IPaisApplication
    {
        #region Fields
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper mapper;
        #endregion

        #region Builders


        public PaisApplication(IPaisRepository paisRepository, IMapper mapper)
        {
            _paisRepository = paisRepository;
            this.mapper = mapper;
        }
        #endregion

        #region Methods

        public ResponseQuery<List<PaisDto>> GetPaises()
        {
            ResponseQuery<List<PaisDto>> response = new ResponseQuery<List<PaisDto>>();
            try
            {
                var partidoList = _paisRepository.List();


                var partidoDtoList = mapper.Map<List<PaisDto>>(partidoList);
                response.Result = partidoDtoList.ToList();

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        #endregion

        #region PrivateMethods
        #endregion
    }


}
