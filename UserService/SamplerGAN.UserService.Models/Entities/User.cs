using System;

namespace SamplerGAN.UserService.Models.Entities
{
    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public DateTime UserCreated { get; set; }
    }
}