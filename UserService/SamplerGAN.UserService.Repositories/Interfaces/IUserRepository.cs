using System.Collections.Generic;
using SamplerGAN.UserService.Models.Dtos;
using SamplerGAN.UserService.Models.InputModels;

namespace SamplerGAN.UserService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<UserDto> GetAllUsers();
        UserDetailDto GetUserById(int id);
        int CreateUser(UserInputModel body);
        void UpdateUserById(int id, UserInputModel body);
        void DeleteUserById(int id);
    }
}