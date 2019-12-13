using System.ComponentModel.DataAnnotations;

namespace SamplerGAN.MetadataService.WebApi.Models.InputModels {
  public class MetadataInputModel {
    [Required (ErrorMessage = "Gain is required")]
    public double Gain { get; set; }

    [Required (ErrorMessage = "Attack is required")]
    public double Attack { get; set; }

    [Required (ErrorMessage = "Decay is required")]
    public double Decay { get; set; }

    [Required (ErrorMessage = "Hold is required")]
    public double Hold { get; set; }

    [Required (ErrorMessage = "Reverb is required")]
    public double Reverb { get; set; }

    [Required (ErrorMessage = "Delay is required")]
    public double Delay { get; set; }

    [Required (ErrorMessage = "Cutoff is required")]
    public double Cutoff { get; set; }

    [Required (ErrorMessage = "Reso is required")]
    public double Reso { get; set; }

    [Required (ErrorMessage = "Fx is required")]
    public bool Fx { get; set; }

    [Required (ErrorMessage = "Envelopes is required")]
    public bool Envelopes { get; set; }

    [Required (ErrorMessage = "Filters is required")]
    public bool Filters { get; set; }
  }
}