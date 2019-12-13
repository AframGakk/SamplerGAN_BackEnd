using System;

namespace SamplerGAN.MetadataService.WebApi.Models.Entities {
    public class Folder {
        public int id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public int User { get; set; }
        public string location { get; set; }
        public DateTime FolderCreated { get; set; }
    }
}