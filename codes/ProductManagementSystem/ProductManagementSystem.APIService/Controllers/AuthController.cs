using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.APIService.Models;
using ProductManagementSystem.Entities;
using ProductManagementSystem.Repository;

namespace ProductManagementSystem.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserRepository repository, ITokenManager tokenManager) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult<string> Register([FromBody] User user)
        {
            try
            {
                var status = repository.RegisterUser(user);
                return status ? CreatedAtAction(nameof(Register), "successfully registered") : BadRequest("user could not be registered..or already exists");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: 500);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<string> Login([FromBody] User user)
        {
            try
            {
                var status = repository.AuthenticateUser(user);
                if (status)
                {
                    var tokenValue = tokenManager.GenerateJSONWebToken(user);
                    return Ok(new { token = tokenValue });
                }
                else
                    return BadRequest("user is invalid");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: 500);
            }
        }
    }
}
