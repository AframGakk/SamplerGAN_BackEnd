namespace SamplerGAN.MetadataService.WebApi.Models.Entities
{
    public class File_Metadata
    {        
        public int id { get; set; }
        public int File_id { get; set; }
        public int gain { get; set; }
        public int attack { get; set; }
        public int decay { get; set; }
        public int hold { get; set; }
        public int reverb { get; set; }
        public int delay { get; set; }
        public int cutoff { get; set; }
        public int reso { get; set; }
        public bool fx { get; set; }
        public bool envelopes { get; set; }
        public bool filters { get; set; }
    }
}