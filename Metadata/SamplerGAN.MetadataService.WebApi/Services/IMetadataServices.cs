using System.Collections.Generic;
using SamplerGAN.MetadataService.WebApi.Models.Dtos;
using SamplerGAN.MetadataService.WebApi.Models.InputModels;

namespace SamplerGAN.MetadataService.WebApi.Services {
  public interface IMetadataServices {
    IEnumerable<FileDto> GetAllFilesByUserId (int id);
    IEnumerable<FolderDto> GetAllFoldersByUserId (int id);
    IEnumerable<FileDetailDto> GetFileByUserIdAndFileId (int userId, int fileId);
    IEnumerable<FolderDetailDto> GetFolderByUserIdAndFolderId (int userId, int folderId);
    IEnumerable<FileMetadataDto> GetFileMetadataByFileId (int fileId);
    int CreateFileByUserId (FileInputModel body, int userId);
    void CreateMetadataForFile (int fileId);
    int CreateFolderByUserId (FolderInputModel body, int userId);
    void UpdateFilePartiallyByFileId (FileInputModel body, int fileId);
    void UpdateFolderPartiallyByFolderId (FolderInputModel body, int folderId);
    IEnumerable<FileMetadataDto> UpdateMetadataById (MetadataInputModel body, int id);
    void DeleteFileById (int fileId);
    void DeleteFolderById (int folderId);
  }
}