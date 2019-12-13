using Microsoft.EntityFrameworkCore;
using SamplerGAN.UserService.Models.Entities;

namespace SamplerGAN.UserService.Models.Entities
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> opt) : base(opt) { }

    public DbSet<User> user { get; set; }

  }
}