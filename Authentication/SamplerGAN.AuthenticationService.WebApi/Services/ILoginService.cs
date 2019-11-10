using System.Security.Claims;
using SamplerGAN.AuthenticationService.WebApi.Entities;

namespace SamplerGAN.AuthenticationService.WebApi.Services
{
    public interface ILoginService
    {
        int GetUserId(string username);
        string Authenticate(User body);
        string Validate(string token);
        ClaimsPrincipal GetPrincipal(string token);
    }
}