using Microsoft.AspNetCore.Mvc;
using SamplerGAN.AuthenticationService.WebApi.Entities;
using SamplerGAN.AuthenticationService.WebApi.Services;

namespace SamplerGAN.AuthenticationService.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // TODO global exception handler

        //DI
        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        
        // Authenticates user if username and password matches users in the database,
        // returns the user model with JWT token  
        [Route("authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User body)
        {
            var user = _loginService.Authenticate(body.Username, body.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // If token and username matches then the user is validated
        [Route("validate")]
        [HttpGet]
        public IActionResult Validate(string token, string username)
        {
            var user = _loginService.Validate(token);

            /*
            if(username.Equals(user)) 
            {
                return Ok(user);
            }
            return BadRequest(new { message = "Error with validating user" });
            */
            if (user == null)
            {
                return StatusCode(418, new { message = "Error with validating user" });
            }

            if(username.Equals(user)) 
            {
                return Ok(user);
            }
            return BadRequest(new { message = "Error with validating user" });
        }
        
    }
}