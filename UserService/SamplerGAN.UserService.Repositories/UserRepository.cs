using System;
using System.Collections.Generic;
using System.Linq;
using SamplerGAN.UserService.Models.Dtos;
using SamplerGAN.UserService.Models.Entities;
using SamplerGAN.UserService.Models.Exceptions;
using SamplerGAN.UserService.Models.InputModels;
using SamplerGAN.UserService.Repositories.Data;

namespace SamplerGAN.UserService.Repositories
{
    public class UserRepository
    {
        public List<User> GetAllUsers() 
        {
            return DataProvider.Users.ToList();
        }

        public User GetUserById(int id)
        {
            var user = DataProvider.Users.FirstOrDefault(u => u.Id == id);
            /*if (user == null)
            {
                throw new ContentNotFoundException(string.Format("Unable to find user by id:" + id));
            }
            */
            return user;
        }

        public int CreateUser(UserInputModel body)
        {
            var nextId = DataProvider.Users.Last().Id + 1;
            DataProvider.Users.Add(new User
            {
                Id = nextId,
                UserName = body.UserName,
                FirstName = body.FirstName,
                LastName = body.LastName,
                Email = body.Email
            });
            return nextId;
        }
    }
}