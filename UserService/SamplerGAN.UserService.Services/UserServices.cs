using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Dtos;
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
    }
}