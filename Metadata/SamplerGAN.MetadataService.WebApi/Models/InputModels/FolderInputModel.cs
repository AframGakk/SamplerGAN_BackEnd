using System.ComponentModel.DataAnnotations;

namespace SamplerGAN.MetadataService.WebApi.Models.InputModels
{
    public class FolderInputModel
    {
        [Required (ErrorMessage="Folder name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage="Folder parent is required")]
        public int  Parent { get; set; }
        // The userId is in the route
        //public int User { get; set; }
        [Required (ErrorMessage="Folder location is required")]
        public string Location { get; set; }
    }
}