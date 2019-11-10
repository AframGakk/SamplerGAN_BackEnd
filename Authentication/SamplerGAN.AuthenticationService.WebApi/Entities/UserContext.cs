using Microsoft.EntityFrameworkCore;

namespace SamplerGAN.AuthenticationService.WebApi.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt) {}

        public DbSet<User> user { get; set; }
    }
}