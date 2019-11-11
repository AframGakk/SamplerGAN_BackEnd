using System;

namespace SamplerGAN.AuthenticationService.WebApi.Models.Exceptions
{
    public class MatchingUserJWTException : Exception
    {
        public MatchingUserJWTException() : base("User does not match the JWT token provided") {}
        public MatchingUserJWTException(string message) : base(message) {}
        public MatchingUserJWTException(string message, Exception inner) : base(message, inner) {}
    }
}