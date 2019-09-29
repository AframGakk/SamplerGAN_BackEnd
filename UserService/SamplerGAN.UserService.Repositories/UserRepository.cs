using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Entities;
using SamplerGAN.UserService.Repositories.Data;

namespace SamplerGAN.UserService.Repositories
{
    public class UserRepository
    {
        public List<User> GetAllUsers() 
        {
            return DataProvider.Users.ToList();
        }
    }
}