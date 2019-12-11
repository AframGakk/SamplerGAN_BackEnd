namespace SamplerGAN.MetadataService.WebApi.Models.Entities
{
  public class File_Metadata
  {
    public int id { get; set; }
    public int File_id { get; set; }
    public double gain { get; set; }
    public double attack { get; set; }
    public double decay { get; set; }
    public double hold { get; set; }
    public double reverb { get; set; }
    public double delay { get; set; }
    public double cutoff { get; set; }
    public double reso { get; set; }
    public bool fx { get; set; }
    public bool envelopes { get; set; }
    public bool filters { get; set; }
  }
}