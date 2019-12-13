using System.Collections.Generic;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;
using SamplerGAN.MetadataService.WebApi.Models.InputModels;
using SamplerGAN.MetadataService.WebApi.Repositories;

namespace SamplerGAN.MetadataService.WebApi.Services {
  public class MetadataServices : IMetadataServices {
    // DI
    private IMetadataRepository _metaRepository;
    public MetadataServices (IMetadataRepository metadataRepository) {
      _metaRepository = metadataRepository;
    }

    public IEnumerable<FileDto> GetAllFilesByUserId (int id) {
      var files = _metaRepository.GetAllFilesByUserId (id);
      return files;
    }

    public IEnumerable<FolderDto> GetAllFoldersByUserId (int id) {
      var folders = _metaRepository.GetAllFoldersByUserId (id);
      return folders;
    }

    public IEnumerable<FileDetailDto> GetFileByUserIdAndFileId (int userId, int fileId) {
      var file = _metaRepository.GetFileByUserIdAndFileId (userId, fileId);
      return file;
    }

    public IEnumerable<FolderDetailDto> GetFolderByUserIdAndFolderId (int userId, int folderId) {
      var folder = _metaRepository.GetFolderByUserIdAndFolderId (userId, folderId);
      return folder;
    }

    public IEnumerable<FileMetadataDto> GetFileMetadataByFileId (int fileId) {
      var metadata = _metaRepository.GetFileMetadataByFileId (fileId);
      return metadata;
    }

    public int CreateFileByUserId (FileInputModel body, int userId) {
      return _metaRepository.CreateFileByUserId (body, userId);
    }

    public void CreateMetadataForFile (int fileId) {
      _metaRepository.CreateMetadataForFile (fileId);
    }

    public int CreateFolderByUserId (FolderInputModel body, int userId) {
      return _metaRepository.CreateFolderByUserId (body, userId);
    }
    public void UpdateFilePartiallyByFileId (FileInputModel body, int fileId) {
      _metaRepository.UpdateFilePartiallyByFileId (body, fileId);
    }
    public void UpdateFolderPartiallyByFolderId (FolderInputModel body, int folderId) {
      _metaRepository.UpdateFolderPartiallyByFolderId (body, folderId);
    }

    public IEnumerable<FileMetadataDto> UpdateMetadataById (MetadataInputModel body, int id) {
      var metadata = _metaRepository.UpdateMetadataById (body, id);
      return metadata;
    }

    public void DeleteFileById (int fileId) {
      _metaRepository.DeleteFileById (fileId);
    }
    public void DeleteFolderById (int folderId) {
      _metaRepository.DeleteFolderById (folderId);
    }
  }
}