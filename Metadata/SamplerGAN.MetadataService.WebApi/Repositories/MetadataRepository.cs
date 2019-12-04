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
      var entities = from items in _db.file
                     where (items.User == id)
                     select new FileDto
                     {
                       Id = items.id,
                       Name = items.Name,
                       Sound_type = items.Sound_type,
                       User = items.User,
                       Parent = items.Parent
                     };

      return entities;
    }
    public IEnumerable<FolderDto> GetAllFoldersByUserId(int id)
    {
      var entities = from items in _db.folder
                     where (items.User == id)
                     select new FolderDto
                     {
                       Id = items.id,
                       Name = items.Name,
                       Parent = items.Parent,
                       User = items.User
                     };
      return entities;
    }
    public IEnumerable<FileDetailDto> GetFileByUserIdAndFileId(int userId, int fileId)
    {
      var entity = from item in _db.file
                   where (item.User == userId) && (item.id == fileId)
                   select new FileDetailDto
                   {
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
                   where (item.User == userId) && (item.id == folderId)
                   select new FolderDetailDto
                   {
                     Id = item.id,
                     Name = item.Name,
                     Parent = item.Parent,
                     User = item.User,
                     Location = item.location,
                     FolderCreated = item.FolderCreated
                   };
      return entity;
    }

    public IEnumerable<FileMetadataDto> GetFileMetadataByFileId(int fileId)
    {
      var entity = from item in _db.file_metadata
                   where (item.File_id == fileId)
                   select new FileMetadataDto
                   {
                     id = item.id,
                     File_id = item.File_id,
                     Gain = item.gain,
                     Attack = item.attack,
                     Decay = item.decay,
                     Hold = item.hold,
                     Reverb = item.reverb,
                     Delay = item.delay,
                     Cutoff = item.cutoff,
                     Reso = item.reso,
                     Fx = item.fx,
                     Envelopes = item.envelopes,
                     Filters = item.filters
                   };

      return entity;
    }
    // Helper function to return newly patch metadata to frontend
    public IEnumerable<FileMetadataDto> GetFileMetadataById(int id)
    {
      var entity = from item in _db.file_metadata
                   where (item.id == id)
                   select new FileMetadataDto
                   {
                     id = item.id,
                     File_id = item.File_id,
                     Gain = item.gain,
                     Attack = item.attack,
                     Decay = item.decay,
                     Hold = item.hold,
                     Reverb = item.reverb,
                     Delay = item.delay,
                     Cutoff = item.cutoff,
                     Reso = item.reso,
                     Fx = item.fx,
                     Envelopes = item.envelopes,
                     Filters = item.filters
                   };

      return entity;
    }
    public int CreateFileByUserId(FileInputModel filebody, int userId)
    {
      var newFile = new File
      {
        Name = filebody.Name,
        Sound_type = filebody.Sound_type.Value,
        Location = filebody.Location,
        Parent = filebody.Parent.Value,
        User = userId
      };
      _db.file.Add(newFile);
      _db.SaveChanges();
      return newFile.id;
    }

    public void CreateMetadataForFile(int fileId)
    {
      Console.WriteLine("POST METADATA UM :" + fileId);
      _db.file_metadata.Add(new File_Metadata
      {
        File_id = fileId,
        gain = 0,
        attack = 0,
        decay = 0,
        hold = 0,
        reverb = 0,
        delay = 0,
        cutoff = 0,
        reso = 0,
        fx = false,
        envelopes = false,
        filters = false
      });
      _db.SaveChanges();
    }

    public int CreateFolderByUserId(FolderInputModel folderbody, int userId)
    {
      var newFolder = new Folder
      {
        Name = folderbody.Name,
        Parent = folderbody.Parent.Value,
        User = userId,
        location = folderbody.Location
      };
      _db.folder.Add(newFolder);
      _db.SaveChanges();
      return newFolder.id;
    }
    public void UpdateFilePartiallyByFileId(FileInputModel body, int fileId)
    {
      var entity = _db.file.FirstOrDefault(f => f.id == fileId);
      if (entity == null)
      {
        throw new ResourceNotFoundException("No file with this id: " + fileId);
      }
      //Update prop of the user if provided
      if (!string.IsNullOrEmpty(body.Name)) { entity.Name = body.Name; }
      if (body.Sound_type.HasValue) { entity.Sound_type = body.Sound_type.Value; }
      if (!string.IsNullOrEmpty(body.Location)) { entity.Location = body.Location; }
      if (body.Parent.HasValue) { entity.Parent = body.Parent.Value; }

      _db.file.Update(entity);
      _db.SaveChanges();
    }
    public void UpdateFolderPartiallyByFolderId(FolderInputModel body, int folderId)
    {
      var entity = _db.folder.FirstOrDefault(f => f.id == folderId);
      if (entity == null)
      {
        throw new ResourceNotFoundException("No folder with this id: " + folderId);
      }
      //Update prop of the user if provided
      if (!string.IsNullOrEmpty(body.Name)) { entity.Name = body.Name; }
      if (body.Parent.HasValue) { entity.Parent = body.Parent.Value; }
      if (!string.IsNullOrEmpty(body.Location)) { entity.location = body.Location; }

      _db.folder.Update(entity);
      _db.SaveChanges();
    }

    public IEnumerable<FileMetadataDto> UpdateMetadataById(MetadataInputModel body, int id)
    {

      Console.WriteLine("Request is in repo");
      Console.WriteLine(body);
      Console.WriteLine(id);
      var entity = _db.file_metadata.FirstOrDefault(m => m.id == id);
      if (entity == null)
      {
        throw new ResourceNotFoundException("No metadata file with this id: " + id);
      }
      entity.gain = body.Gain;
      entity.attack = body.Attack;
      entity.decay = body.Decay;
      entity.hold = body.Hold;
      entity.reverb = body.Reverb;
      entity.delay = body.Delay;
      entity.cutoff = body.Cutoff;
      entity.reso = body.Reso;
      entity.fx = body.Fx;
      entity.envelopes = body.Envelopes;
      entity.filters = body.Filters;

      _db.file_metadata.Update(entity);
      _db.SaveChanges();

      var retMeta = GetFileMetadataById(id);

      return retMeta;
    }
    public void DeleteFileById(int fileId)
    {
      var entity = _db.file.FirstOrDefault(f => f.id == fileId);
      var meta = _db.file_metadata.FirstOrDefault(f => f.File_id == fileId);
      if (entity == null)
      {
        throw new ResourceNotFoundException("No file with this id: " + fileId);
      }
      _db.file_metadata.Remove(meta);
      _db.file.Remove(entity);
      _db.SaveChanges();
    }
    public void DeleteFolderById(int folderId)
    {
      var entity = _db.folder.FirstOrDefault(f => f.id == folderId);
      if (entity == null)
      {
        throw new ResourceNotFoundException("No folder with this id: " + folderId);
      }
      _db.folder.Remove(entity);
      _db.SaveChanges();
    }
  }
}