using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.UserService.Models.Exceptions;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Services.Interfaces;

namespace SamplerGAN.UserService.WebApi.Controllers {
    [Route ("api/")]
    [ApiController]
    public class UserController : ControllerBase {
        // Helper function to consume Authentication WebApi
        // to validate the user who is trying to access endpoints
        static string _address = "http://wisebeatstudio.com/api/auth/validate";
        private string result;
        private async Task<string> Validate (string jwtToken, string userName) {
            var client = new HttpClient ();
            client.DefaultRequestHeaders.Add ("Authorization", jwtToken);
            HttpResponseMessage response = await client.GetAsync (_address + "?username=" + userName);
            var resp = response.IsSuccessStatusCode;
            // If resp is false, then user in unauthenticated
            // throw error
            if (resp == false) {
                throw new UnauthorizedException ();
            }
            result = await response.Content.ReadAsStringAsync ();
            // return user id
            // question about if it's needed
            return result;
        }
        // DI
        private IUserServices _userService;

        public UserController (IUserServices userService) {
            _userService = userService;
        }

        // Helper function for GCP Kubernets healthchecks
        //http://localhost:5000/api/healthchecks [GET]
        [Route ("healthchecks")]
        [HttpGet]
        public IActionResult GetHealthCheck () {
            return StatusCode (200);
        }

        //Helper function for frontend
        //http://localhost:5000/api/helps [GET]
        [Route ("users/username")]
        [HttpGet]
        public IActionResult GetIdByUsername () {
            var queryString = Request.QueryString.ToString ();
            // If Querystring is empty throw error
            if (string.IsNullOrEmpty (queryString)) {
                throw new RequestElementsNeededException ();
            }
            var userName = queryString.Split ('=') [1];
            Console.WriteLine (userName);
            var userId = _userService.GetIdByUsername (userName);
            return Ok (userId);
        }

        //http://localhost:5000/api/users [GET]
        [Route ("users/")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers () {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString ();
            // If Authorization header is not present 
            // throw error
            if (string.IsNullOrEmpty (authToken)) {
                throw new RequestElementsNeededException ();
            }
            var queryString = Request.QueryString.ToString ();
            // If Querystring is empty throw error
            if (string.IsNullOrEmpty (queryString)) {
                throw new RequestElementsNeededException ();
            }
            var userName = queryString.Split ('=') [1];
            // returns user id, is it needed ?
            var result = await Validate (authToken, userName);
            var userList = _userService.GetAllUsers ();
            return Ok (userList);
        }

        //http://localhost:5000/api/users/{id} [GET]
        [Route ("users/{id:int}", Name = "GetUserById")]
        [HttpGet]
        public async Task<IActionResult> GetUserById (int id) {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString ();
            // If Authorization header is not present 
            // throw error
            if (string.IsNullOrEmpty (authToken)) {
                throw new RequestElementsNeededException ();
            }
            var queryString = Request.QueryString.ToString ();
            // If Querystring is empty throw error
            if (string.IsNullOrEmpty (queryString)) {
                throw new RequestElementsNeededException ();
            }
            var userName = queryString.Split ('=') [1];
            // returns user id, is it needed ?
            var result = await Validate (authToken, userName);
            var user = _userService.GetUserById (id);
            return Ok (user);
        }

        //http://localhost:5000/api/users [POST]
        [Route ("users/")]
        [HttpPost]
        public IActionResult CreateUser ([FromBody] UserInputModel body) {
            /*
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
*/
            // Should not be neccesary to be authenticated if
            // making new user
            if (!ModelState.IsValid) {
                return BadRequest ("The input model was not correct");
            }
            // returns user id, is it needed ?
            //var result = await Validate(authToken, userName);
            var newUserId = _userService.CreateUser (body);
            return StatusCode (201, newUserId);
        }

        //http://localhost:5000/api/users/{id} [PATCH]
        [Route ("users/{id:int}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateUserById (int id, [FromBody] UserInputModel body) {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString ();
            // If Authorization header is not present 
            // throw error
            if (string.IsNullOrEmpty (authToken)) {
                throw new RequestElementsNeededException ();
            }
            var queryString = Request.QueryString.ToString ();
            // If Querystring is empty throw error
            if (string.IsNullOrEmpty (queryString)) {
                throw new RequestElementsNeededException ();
            }
            var userName = queryString.Split ('=') [1];
            // returns user id, is it needed ?
            var result = await Validate (authToken, userName);
            _userService.UpdateUserById (id, body);
            return NoContent ();
        }

        //http://localhost:5000/api/users/{id} [DELETE]
        [Route ("users/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserById (int id) {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString ();
            // If Authorization header is not present 
            // throw error
            if (string.IsNullOrEmpty (authToken)) {
                throw new RequestElementsNeededException ();
            }
            var queryString = Request.QueryString.ToString ();
            // If Querystring is empty throw error
            if (string.IsNullOrEmpty (queryString)) {
                throw new RequestElementsNeededException ();
            }
            var userName = queryString.Split ('=') [1];
            // returns user id, is it needed ?
            var result = await Validate (authToken, userName);
            _userService.DeleteUserById (id);
            return NoContent ();
        }
    }
}