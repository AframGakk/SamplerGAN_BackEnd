namespace SamplerGAN.MetadataService.WebApi.Models.Dtos
{
  public class FileDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Sound_type { get; set; }
    public string Location { get; set; }
    public int Parent { get; set; }
    public int User { get; set; }

  }
}