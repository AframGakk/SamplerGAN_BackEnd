using Microsoft.AspNetCore.Mvc;

namespace SamplerGAN.UserService.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GRUD
        //GetAllUsers
        //http://localhost:5000/api/users [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllUsers() {
            return Ok("Yo Dude");
        }

        //GetUserById
        //http://localhost:5000/api/users/1 [GET]
        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetUserById(int id) {
            return Ok();
        }
        //CreateUser
        //http://localhost:5000/api/users [POST]
       /*  [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserInputModel body) {
            return Ok();
        }
*/
        //UpdateUserById
        //http://localhost:5000/api/users/1 [Put]
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateUserById(int id) {
            return Ok();
        }

        //DeleteUserById
        //http://localhost:5000/api/users/1 [DELETE]
        [Route("{id:int}")]
        [HttpGet]
        public IActionResult DeleteUserById(int id) {
            return Ok();
        }
        
    }
}