using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gremlins.WebApi.Application
{
    class VentasApplication : IVentasApplication
    {
        #region Fields
        private readonly IVentaRepository _ventasRepository;
        private readonly IMapper mapper;
        #endregion

        #region Builders


        public VentasApplication(IMapper mapper, IVentaRepository sesionRepository)
        {
            this.mapper = mapper;
            _ventasRepository = sesionRepository;
        }
        #endregion

        #region Methods


        public ResponseQuery<int> ManageVentas(VentasDto request)
        {
            ResponseQuery<int> response = new ResponseQuery<int>();
            try
            {

                var sesion = mapper.Map<Ventas>(request);

                if (sesion.IdVenta == 0)
                {
                    _ventasRepository.Insert(sesion);
                }
                else
                    _ventasRepository.Update(sesion);
                response.Result = sesion.IdVenta;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }
        public ResponseQuery<List<VentasDto>> GetVentas()
        {
            ResponseQuery<List<VentasDto>> response = new ResponseQuery<List<VentasDto>>();
            try
            {
                var sesionList = _ventasRepository.ListVentas();


                var sesionDtoList = mapper.Map<List<VentasDto>>(sesionList);

                response.Result = sesionDtoList.ToList();

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
