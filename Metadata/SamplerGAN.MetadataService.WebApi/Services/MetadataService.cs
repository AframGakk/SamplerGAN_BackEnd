using System.Collections.Generic;
using System.Threading.Tasks;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;
using SamplerGAN.MetadataService.WebApi.Repositories;

namespace SamplerGAN.MetadataService.WebApi.Services
{
    public class MetadataServices : IMetadataServices
    {
        // DI
        private IMetadataRepository _metaRepository;
        public MetadataServices(IMetadataRepository metadataRepository)
        {
            _metaRepository = metadataRepository;
        }

        public IEnumerable<FileDto> GetAllFilesByUserId(int id)
        {
            var files = _metaRepository.GetAllFilesByUserId(id);
            return files;

        }
    }
}