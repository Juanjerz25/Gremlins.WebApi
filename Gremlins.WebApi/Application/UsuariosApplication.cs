using AutoMapper;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Entities;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gremlins.WebApi.Application
{
    public class UsuariosApplication : IUsuariosApplication
    {
        #region Fields
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IMapper mapper;
        #endregion
        #region Builders


        public UsuariosApplication(IUsuariosRepository usuariosRepository, IMapper mapper)
        {
            _usuariosRepository = usuariosRepository;
            this.mapper = mapper;
        }
        #endregion



        public ResponseQuery<int> FindUsuario(RequestLogin requestLogin)
        {
            ResponseQuery<int> response = new ResponseQuery<int>();
            try
            {
                var usuario = _usuariosRepository.Find(c => c.Correo == requestLogin.Correo && c.Contrasena == requestLogin.Contrasena);

                if(usuario == null)
                {
                    response.ResponseMessage("Usuario y/o contraseña invalidos", false);
                }

                response.Result = usuario?.IdUsuario ?? 0;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }
    }
}
