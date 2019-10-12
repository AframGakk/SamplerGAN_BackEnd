using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Dtos;
using SamplerGAN.UserService.Models.Entities;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Repositories;
using SamplerGAN.UserService.Services.Interfaces;
using SamplerGAN.UserService.Repositories.Interfaces;

namespace SamplerGAN.UserService.Services.Implementations
{
    public class UserServices : IUserServices
    {
        // DI
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users;
        }

        public UserDetailDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return user;
        }

        public int CreateUser(UserInputModel body)
        {
            return _userRepository.CreateUser(body);
        }
        
        public void UpdateUserById(int id, UserInputModel body)
        {
            _userRepository.UpdateUserById(id, body);
        }

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteUserById(id);
        }
       
    }
}