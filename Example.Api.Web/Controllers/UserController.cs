using Example.Api.Business;
using Example.Api.Business.DTO;
using Example.Api.Business.Services.Interfaces;
using Example.Api.Web.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Example.Api.Data.Models;

namespace Example.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : GenericController<User, UserDto>
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService) :
            base(userService)
        {
            this.UserService = userService;
        }

        /// <summary>  
        /// Login Authentication using JWT Token Authentication  
        /// </summary>  
        /// <returns></returns>  
        [ValidateModel]
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public IActionResult Login([FromBody] LoginDto user)
        {
            IActionResult response = Unauthorized();
            UserDto userLogged = this.UserService.Login(user);
            if (userLogged != null)
            {
                var tokenString = this.UserService.GenerateJSONWebToken();
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }
    }
}
