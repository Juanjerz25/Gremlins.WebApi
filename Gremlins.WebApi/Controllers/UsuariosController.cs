using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region Fields
        private readonly IUsuariosApplication _usuariosApplication;

        #endregion

        #region builder
        public UsuariosController(IUsuariosApplication usuariosApplication)
        {
            _usuariosApplication = usuariosApplication;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Actualizar un cliente
        /// </summary>
        /// <param name="requestLogin"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ResponseQuery<int>> FindUsuario( [FromBody] RequestLogin requestLogin)
        {
            return await Task.Run(() =>
            {
                return _usuariosApplication.FindUsuario(requestLogin);
            });
        }
        #endregion

    }
}
