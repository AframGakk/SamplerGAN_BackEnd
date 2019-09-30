using System.Net;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.UserService.Models.Exceptions;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Services;

namespace SamplerGAN.UserService.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // TODO Global error handling

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
        [Route("{id:int}", Name = "GetUserById")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }
        
        //CreateUser
        //http://localhost:5000/api/users [POST]
        [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserInputModel body) 
        {
            // ModelState Invalid check
            var newUserId = _userService.CreateUser(body);
            return GetUserById(newUserId);
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