using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;
using SamplerGAN.MetadataService.WebApi.Models.Entities;

namespace SamplerGAN.MetadataService.WebApi.Repositories
{
    public class MetadataRepository : IMetadataRepository
    {
        // DI
        private MetaContext _db;
        public MetadataRepository(MetaContext db)
        {
            _db = db;
        }

        public IEnumerable<FileDto> GetAllFilesByUserId(int id)
        {
            /*var retList = _db.file.Select(item => new FileDto {
                Name = item.Name,
                Sound_type = item.Sound_type,
                User = item.User
            }).ToList().Where(User == id);*/

            Console.WriteLine("From Repo" + id);
            var retList = from items in _db.file
                            where(items.User == id)
                            select new FileDto {
                                Name = items.Name,
                                Sound_type = items.Sound_type,
                                User = items.User
                            };
            
            return retList;
        }     
    }        
}