namespace SamplerGAN.MetadataService.WebApi.Models.Dtos
{
  public class FileMetadataDto
  {
    public int id { get; set; }
    public int File_id { get; set; }
    public double Gain { get; set; }
    public double Attack { get; set; }
    public double Decay { get; set; }
    public double Hold { get; set; }
    public double Reverb { get; set; }
    public double Delay { get; set; }
    public double Cutoff { get; set; }
    public double Reso { get; set; }
    public bool Fx { get; set; }
    public bool Envelopes { get; set; }
    public bool Filters { get; set; }
  }
}