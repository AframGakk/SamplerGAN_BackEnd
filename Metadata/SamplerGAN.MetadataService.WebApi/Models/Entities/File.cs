using System;

namespace SamplerGAN.MetadataService.WebApi.Models.Entities
{
    public class File
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Sound_type { get; set; }
        public string Location { get; set; }
        public int Parent { get; set; }
        public int User { get; set; }
        public DateTime FileCreated { get; set; }
    }
}