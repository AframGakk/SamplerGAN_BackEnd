using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Dtos;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Repositories;

namespace SamplerGAN.UserService.Services
{
    public class UserServices
    {
        UserRepository _userRepository = new UserRepository();

        public List<UserDto> GetAllUsers() 
        {
            return _userRepository.GetAllUsers().Select(item => new UserDto {
                UserName = item.UserName,
                FirstName = item.FirstName,
                LastName = item.LastName
            }).ToList();
        }

        public UserDetailDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return new UserDetailDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserCreated = user.UserCreated
            };
        }

        public int CreateUser(UserInputModel body)
        {
            return _userRepository.CreateUser(body);
        }
    }
}