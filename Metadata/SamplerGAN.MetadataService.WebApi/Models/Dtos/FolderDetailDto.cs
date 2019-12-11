using System;

namespace SamplerGAN.MetadataService.WebApi.Models.Dtos
{
    public class FolderDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public int User { get; set; }
        public string Location { get; set; }
        public DateTime FolderCreated { get; set; }
    }
}