using Microsoft.AspNetCore.Mvc;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Services;

namespace SamplerGAN.UserService.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserServices _userService = new UserServices();

        // GRUD
        //GetAllUsers
        //http://localhost:5000/api/users [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllUsers() {
            var userList = _userService.GetAllUsers();
            if(userList == null) {
                return StatusCode(500);
            }
            return Ok(userList);
        }

        //GetUserById
        //http://localhost:5000/api/users/1 [GET]
        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetUserById(int id) {
            return Ok(id);
        }
        //CreateUser
        //http://localhost:5000/api/users [POST]
        [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserInputModel body) {
            return Ok(body);
        }
        
        //UpdateUserById
        //http://localhost:5000/api/users/1 [Put]
        [Route("{id:int}")]
        [HttpPut]
        // Taka body hérna líka inn
        public IActionResult UpdateUserById(int id) {
            return Ok(id);
        }

        //DeleteUserById
        //http://localhost:5000/api/users/1 [DELETE]
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteUserById(int id) {
            return Ok(id);
        }
        
    }
}