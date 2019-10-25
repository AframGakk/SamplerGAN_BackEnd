using System;

namespace SamplerGAN.UserService.Models.Exceptions
{
    public class ContentNotFoundException : Exception
    {
        public ContentNotFoundException(string message) : base(message) {}
    }
}