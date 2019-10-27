using System.Security.Claims;
using SamplerGAN.AuthenticationService.WebApi.Entities;

namespace SamplerGAN.AuthenticationService.WebApi.Services
{
    public interface ILoginService
    {
        User Authenticate(string username, string password);
        string Validate(string token);
        ClaimsPrincipal GetPrincipal(string token);
    }
}