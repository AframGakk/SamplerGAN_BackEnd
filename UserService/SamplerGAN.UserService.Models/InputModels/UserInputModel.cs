using System.ComponentModel.DataAnnotations;

namespace SamplerGAN.UserService.Models.InputModels
{
    public class UserInputModel
    {
        [Required (ErrorMessage="User name is required")]
        public string Username { get; set; }

        [Required (ErrorMessage="First name is required")]
        public string  FirstName { get; set; }

        [Required (ErrorMessage="Last name is required")]
        public string LastName { get; set; }

        [Required (ErrorMessage="Valid email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required (ErrorMessage="Password is required")]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}