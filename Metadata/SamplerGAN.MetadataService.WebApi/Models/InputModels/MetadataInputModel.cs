using System.ComponentModel.DataAnnotations;

namespace SamplerGAN.MetadataService.WebApi.Models.InputModels
{
  public class MetadataInputModel
  {
    //[Required(ErrorMessage = "File_id is required")]
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