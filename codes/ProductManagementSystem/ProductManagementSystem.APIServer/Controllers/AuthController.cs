using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.APIServer.Models;
using ProductManagementSystem.Repository;

namespace ProductManagementSystem.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserRepository repository, ITokenManager tokenManager, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult RegisterUser([FromBody] UserRegistrationDto user)
        {
            try
            {
                var userToRegister = mapper.Map<User>(user);
                return repository.Register(userToRegister) ? CreatedAtAction(nameof(RegisterUser), user) : BadRequest("user already exists");
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<string> AuthenticateUser([FromBody] LogInUserDto user)
        {
            try
            {
                var userToLogin = mapper.Map<User>(user);
                var userInfo = repository.Authenticate(userToLogin);
                if (userInfo != null)
                {
                    var token = tokenManager.GenerateJSONWebToken(userInfo);
                    return Ok(token);
                }
                else
                    return BadRequest("user does not exist");
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
    }
}
