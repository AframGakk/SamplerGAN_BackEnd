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

            //Console.WriteLine("From Repo" + id);
            var entities = from items in _db.file
                            where(items.User == id)
                            select new FileDto {
                                Name = items.Name,
                                Sound_type = items.Sound_type,
                                User = items.User
                            };
            
            return entities;
        }    
        public IEnumerable<FolderDto> GetAllFoldersByUserId(int id)
        {
            var entities = from items in _db.folder
                            where(items.User == id)
                            select new FolderDto {
                                Name = items.Name,
                                Parent = items.Parent,
                                User = items.User
                            };
            return entities;
        }
        public IEnumerable<FileDetailDto> GetFileByUserIdAndFileId(int userId, int fileId)
        {
            var entity = from item in _db.file
                            where(item.User == userId) && (item.id == fileId)
                            select new FileDetailDto {
                                Id = item.id,
                                Name = item.Name,
                                Sound_type = item.Sound_type,
                                Location = item.Location,
                                Parent = item.Parent,
                                User = item.User,
                                FileCreated = item.FileCreated
                            };
            return entity;
        }
    }        
}