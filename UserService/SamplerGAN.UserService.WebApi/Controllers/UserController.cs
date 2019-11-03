using System.Net;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.UserService.Models.Exceptions;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Services.Interfaces;

namespace SamplerGAN.UserService.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // TODO Global error handling

        // DI
        private IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        //http://localhost:5000/api/users [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var userList = _userService.GetAllUsers();
            return Ok(userList);
        }

        //http://localhost:5000/api/users/{id} [GET]
        [Route("{id:int}", Name = "GetUserById")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            /*if(user == null) {
                return StatusCode(404);
            }*/
            return Ok(user);
        }

        //http://localhost:5000/api/users [POST]
        [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserInputModel body)
        {
            // ModelState Invalid check
            var newUserId = _userService.CreateUser(body);
            //Think it would be better with CreatedAtRoute
            return GetUserById(newUserId);
        }

        //http://localhost:5000/api/users/{id} [PATCH]
        [Route("{id:int}")]
        [HttpPatch]
        public IActionResult UpdateUserById(int id, [FromBody] UserInputModel body) {
            _userService.UpdateUserById(id, body);
            return NoContent();
        }

        //http://localhost:5000/api/users/{id} [DELETE]
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteUserById(int id) {
            _userService.DeleteUserById(id);
            return NoContent();
        }
    }
}
