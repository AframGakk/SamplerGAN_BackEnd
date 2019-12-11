using System;

namespace SamplerGAN.AuthenticationService.WebApi.Models.Exceptions
{
    public class ErrorValidatingUserException : Exception
    {
        public ErrorValidatingUserException() : base("Error with validating user") {}
        public ErrorValidatingUserException(string message) : base(message) {}
        public ErrorValidatingUserException(string message, Exception inner) : base(message, inner) {}  
    }
}