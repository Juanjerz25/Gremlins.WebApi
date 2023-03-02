using Gremlins.WebApi.DTO.Response;
using Gremlins.WebApi.DTO.UserAdmin;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IUserAdminApplication
    {
        ResponseQuery<bool> LogIn(RequestLogInDto request);
    }
}
