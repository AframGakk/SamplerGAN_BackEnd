using System;
using System.Collections.Generic;
using SamplerGAN.UserService.Models.Entities;

namespace SamplerGAN.UserService.Repositories.Data
{
    public class DataProvider
    {
        public static List<User> Users = new List<User> 
        {
            new User {
                Id = 1,
                UserName = "ÍvarKristinn",
                FirstName = "Ívar",
                LastName = "Hallsson",
                Email = "ivar@gmail.com",
                Password = "123456abc",
                UserCreated = DateTime.Now
            },

            new User {
                Id = 2,
                UserName = "Villi",
                FirstName = "Vilhjálmur",
                LastName = "Vilhjálmsson",
                Email = "villi@gmail.com",
                Password = "123456abc",
                UserCreated = DateTime.Now
            }
        };
    }
}