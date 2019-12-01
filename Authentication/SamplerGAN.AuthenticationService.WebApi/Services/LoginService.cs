using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SamplerGAN.AuthenticationService.WebApi.Models.Entities;
using SamplerGAN.AuthenticationService.WebApi.Helpers;
using SamplerGAN.AuthenticationService.WebApi.Repositories;
using SamplerGAN.AuthenticationService.WebApi.Models.Exceptions;

namespace SamplerGAN.AuthenticationService.WebApi.Services
{
    public class LoginService : ILoginService
    {
        // DI
        private IAuthRepository _authRepostitory;
        private readonly AppSettings _appSettings;

        public LoginService(IOptions<AppSettings> appSettings, IAuthRepository authRepository)
        {
            _appSettings = appSettings.Value;
            _authRepostitory = authRepository;
        }
        // Helper function so Validate Route in the Controller,
        // returns the user id
        public int GetUserId(string username) {
            var userId = _authRepostitory.GetUserId(username);
            return userId;
        }

        public string Authenticate([FromBody] User body)
        {
            var userName = _authRepostitory.GetUserByNameAndPassword(body);
            
            if (userName == null) 
            {
                throw new ResourceNotFoundException("No user with this username and password");
            }
            else if(userName == body.UserName)
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] 
                    {
                        new Claim(ClaimTypes.Name, body.UserName)
                    }),
                    //Expires = DateTime.UtcNow.AddDays(7),
                    // Takes 60 min to expire
                    Expires = DateTime.UtcNow.AddMinutes(55),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userToken = tokenHandler.WriteToken(token);

                return userToken;
            }
            // ??? Take out before final
            return "HelloWhatToDoHere?";
        }
        
        public string Validate(string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetPrincipal(token);

            if (principal == null)
                return null;

            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            
            // TESTING - Take out before final
            Console.WriteLine("Hæ er í LoginService");
            Console.WriteLine(username);

            return username;
        }
        
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;

                //byte[] key = Convert.FromBase64String(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
