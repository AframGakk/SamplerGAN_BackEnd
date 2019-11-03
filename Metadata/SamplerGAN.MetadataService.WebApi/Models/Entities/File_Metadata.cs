namespace SamplerGAN.MetadataService.WebApi.Models.Entities
{
    public class File_Metadata
    {
        public int id { get; set; }
        public int File_id { get; set; }
        public decimal Volume { get; set; }
        public decimal Attack { get; set; }
        public decimal Decay { get; set; }
        public decimal Sustain { get; set; }
        public decimal Release { get; set; }
    }
}