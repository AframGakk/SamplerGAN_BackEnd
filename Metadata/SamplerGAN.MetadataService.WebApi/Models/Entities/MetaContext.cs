using Microsoft.EntityFrameworkCore;
using SamplerGAN.MetadataService.WebApi.Models.Entities;

namespace SamplerGAN.MetadataService.WebApi.Models.Entities
{
    public class MetaContext : DbContext
    {
        public MetaContext(DbContextOptions<MetaContext> opt) : base(opt) {}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        public DbSet<File> file { get; set; }
        public DbSet<Folder> folder { get; set; }
        public DbSet<File_Metadata> file_metadata { get; set; }

    }
}
