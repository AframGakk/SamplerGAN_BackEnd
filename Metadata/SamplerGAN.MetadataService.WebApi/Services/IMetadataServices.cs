using System.Collections.Generic;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;

namespace SamplerGAN.MetadataService.WebApi.Services
{
    public interface IMetadataServices
    {
        IEnumerable<FileDto> GetAllFilesByUserId(int id);
        IEnumerable<FolderDto> GetAllFoldersByUserId(int id);
    }
}