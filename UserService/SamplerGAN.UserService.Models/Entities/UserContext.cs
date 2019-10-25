using Microsoft.EntityFrameworkCore;
using SamplerGAN.UserService.Models.Entities;

namespace SamplerGAN.UserService.Models.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt) {}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        public DbSet<User> user { get; set; }
    
    }
}