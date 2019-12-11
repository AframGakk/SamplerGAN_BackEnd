using System;

namespace SamplerGAN.UserService.Models.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("The content was not found") {}
        public ResourceNotFoundException(string message) : base(message) {}
        public ResourceNotFoundException(string message, Exception inner) : base(message, inner) {}  
    }
}