using System;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.AuthenticationService.WebApi.Models.Entities;
using SamplerGAN.AuthenticationService.WebApi.Models.Exceptions;
using SamplerGAN.AuthenticationService.WebApi.Services;

namespace SamplerGAN.AuthenticationService.WebApi.Controllers {
  [Route ("api/")]
  [ApiController]
  public class AuthController : ControllerBase {
    //DI
    private ILoginService _loginService;

    public AuthController (ILoginService loginService) {
      _loginService = loginService;
    }

    // Helper function for GCP Kubernets healthchecks
    //http://localhost:5050/api/healthchecks [GET]
    [Route ("healthchecks")]
    [HttpGet]
    public IActionResult GetHealthCheck () {
      return StatusCode (200);
    }

    //http://localhost:5050/api/authenticate [POST]
    // Authenticates user if username and password matches users in the database,
    // returns the users JWT token  
    [Route ("authenticate")]
    [HttpPost]
    public IActionResult Authenticate ([FromBody] User body) {
      var user = _loginService.Authenticate (body);
      // Returns a token 
      return Ok (user);
    }

    //http://localhost:5050/api/validate [GET]
    // If token and username matches then the user is validated 
    // and returns the user Id for other services
    [Route ("validate")]
    [HttpGet]
    //public IActionResult Validate(string token, string username)
    public IActionResult Validate (string username) {
      // Takes the JWT token from Authorization header
      var token = Request.Headers["Authorization"];
      // TESTING - Take out later
      //Console.WriteLine("Controller Validate");
      //Console.WriteLine(token);

      // Returns username with that token
      var user = _loginService.Validate (token);

      // No User with that token
      if (user == null) {
        throw new ErrorValidatingUserException ();
      }
      // If the incoming username matches the token username
      if (user == username) {
        var userId = _loginService.GetUserId (username);
        //return StatusCode(202, true);
        return StatusCode (202, userId);
      }
      throw new MatchingUserJWTException ();
      //return StatusCode(403, new { message = "User does not match the JWT token provided" });
    }

  }
}