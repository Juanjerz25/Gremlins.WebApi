using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.UserAdmin;
using System;

namespace Gremlins.WebApi.Application
{
    class UserAdminApplication: IUserAdminApplication
    {
        #region Fields
        private readonly IUserAdminRepository _userAdminRepository;
        #endregion

        #region Builders


        public UserAdminApplication(IUserAdminRepository userAdminRepository)
        {
            _userAdminRepository = userAdminRepository;
        }
        #endregion

        #region Methods

        public ResponseQuery<bool> LogIn(RequestLogInDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                var userAdmin = _userAdminRepository.Find(x => x.Nombre == request.Nombre && x.Contrasena == request.Contrasena);
                if (userAdmin == null)
                {
                    response.ResponseMessage("Usuario y/o contraseña invalido", false);
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);               
            }
            return response;
        }
        #endregion
    }
}
