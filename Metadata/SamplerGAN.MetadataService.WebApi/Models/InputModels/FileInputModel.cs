using System.ComponentModel.DataAnnotations;

namespace SamplerGAN.MetadataService.WebApi.Models.InputModels
{
    public class FileInputModel
    {
        [Required (ErrorMessage="File name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage="File Sound_type is required")]
        public int?  Sound_type { get; set; }

        [Required (ErrorMessage="File location is required")]
        public string Location { get; set; }

        [Required (ErrorMessage="File parent is required")]
        public int? Parent { get; set; }
        // The userId is in the route
        //public int User { get; set; }
    }
}