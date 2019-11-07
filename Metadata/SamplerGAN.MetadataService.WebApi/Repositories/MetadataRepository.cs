using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;
using SamplerGAN.MetadataService.WebApi.Models.Entities;
using SamplerGAN.MetadataService.WebApi.Models.Exceptions;
using SamplerGAN.MetadataService.WebApi.Models.InputModels;

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
        public IEnumerable<FolderDetailDto> GetFolderByUserIdAndFolderId(int userId, int folderId)
        {
            var entity = from item in _db.folder
                            where(item.User == userId) && (item.id == folderId)
                            select new FolderDetailDto {
                                Id = item.id,
                                Name = item.Name,
                                Parent = item.Parent,
                                User = item.User,
                                Location = item.location,
                                FolderCreated = item.FolderCreated
                            };
            return entity;
        }
        public void CreateFileByUserId(FileInputModel filebody, int userId)
        {
            _db.file.Add(new File 
            {
                Name = filebody.Name,
                Sound_type = filebody.Sound_type,
                Location = filebody.Location,
                Parent = filebody.Parent,
                User = userId
            });
            _db.SaveChanges();
        }

        public void CreateFolderByUserId(FolderInputModel folderbody, int userId)
        {
            _db.folder.Add(new Folder
            {
                Name = folderbody.Name,
                Parent = folderbody.Parent,
                User = userId,
                location = folderbody.Location
            });
            _db.SaveChanges();
        }
        public void DeleteFileById(int fileId)
        {
            var entity =_db.file.FirstOrDefault(f => f.id == fileId);
            if(entity == null)
            {
                throw new ResourceNotFoundException("No file with this id: " + fileId);
            }
            _db.file.Remove(entity);
            _db.SaveChanges();
        }
        public void DeleteFolderById(int folderId)
        {
            var entity =_db.folder.FirstOrDefault(f => f.id == folderId);
            if(entity == null)
            {
                throw new ResourceNotFoundException("No folder with this id: " + folderId);
            }
            _db.folder.Remove(entity);
            _db.SaveChanges();
        }
    }        
}