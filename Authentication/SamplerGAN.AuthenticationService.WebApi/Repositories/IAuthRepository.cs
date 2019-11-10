using SamplerGAN.AuthenticationService.WebApi.Entities;

namespace SamplerGAN.AuthenticationService.WebApi.Repositories
{
    public interface IAuthRepository
    {
        int GetUserId(string username);
        string GetUserByNameAndPassword(User body);
    }
}