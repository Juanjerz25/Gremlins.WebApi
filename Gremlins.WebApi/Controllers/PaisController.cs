using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DTO.Pais;
using Gremlins.WebApi.DTO.Partido;
using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class PaisController : ControllerBase
    {
        #region Fields
        private readonly IPaisApplication _paisApplication;

        #endregion

        #region Builder

        public PaisController(IPaisApplication paisApplication)
        {
            _paisApplication = paisApplication;
        }


        #endregion

        #region Methods

        [HttpGet]
        [Route(nameof(PaisController.GetPaises))]
        public async Task<ResponseQuery<List<PaisDto>>> GetPaises()
        {
            return await Task.Run(() =>
            {
                return _paisApplication.GetPaises();
            });
        }

        #endregion
    }
}
