using System.Collections.Generic;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;

namespace SamplerGAN.MetadataService.WebApi.Repositories
{
    public interface IMetadataRepository
    {
        IEnumerable<FileDto> GetAllFilesByUserId(int id);
        IEnumerable<FolderDto> GetAllFoldersByUserId(int id);
    }
}