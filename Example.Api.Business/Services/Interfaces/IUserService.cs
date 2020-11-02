using Example.Api.Business.DTO;
using Example.Api.Data.Models;

namespace Example.Api.Business.Services.Interfaces
{
    public interface IUserService : IService<User, UserDto>
    {
        UserDto Login(LoginDto user);
        string GenerateJSONWebToken();
    }
}
