using System;

namespace SamplerGAN.UserService.Models.Dtos
{
    public class UserDetailDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime UserCreated { get; set; }
    }
}