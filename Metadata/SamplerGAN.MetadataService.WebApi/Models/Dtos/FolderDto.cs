namespace SamplerGAN.MetadataService.WebApi.Models.Dtos
{
    public class FolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public int User { get; set; }
    }
}