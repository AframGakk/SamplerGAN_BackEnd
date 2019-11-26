using System;

namespace SamplerGAN.MetadataService.WebApi.Models.Exceptions
{
    public class RequestElementsNeededException : Exception
    {
        public RequestElementsNeededException() : base("Auth header or username is missing or both") {}
        public RequestElementsNeededException(string message) : base(message) {}
        public RequestElementsNeededException(string message, Exception inner) : base(message, inner) {}  
    }
}