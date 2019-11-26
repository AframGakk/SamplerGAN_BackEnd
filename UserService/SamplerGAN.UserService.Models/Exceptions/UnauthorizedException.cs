using System;

namespace SamplerGAN.UserService.Models.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("User is unauthorized, please authenticate") {}
        public UnauthorizedException(string message) : base(message) {}
        public UnauthorizedException(string message, Exception inner) : base(message, inner) {}  
    }
}