namespace SamplerGAN.MetadataService.WebApi.Models.Dtos
{
    public class FileMetadataDto
    {
        public int id { get; set; }
        public int File_id { get; set; }
        public int Gain { get; set; }
        public int Attack { get; set; }
        public int Decay { get; set; }
        public int Hold { get; set; }
        public int Reverb { get; set; }
        public int Delay { get; set; }
        public int Cutoff { get; set; }
        public int Reso { get; set; }
        public bool Fx { get; set; }
        public bool Envelopes { get; set; }
        public bool Filters { get; set; }
    }
}