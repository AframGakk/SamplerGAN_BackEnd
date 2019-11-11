using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.MetadataService.WebApi.Models.Exceptions;
using SamplerGAN.MetadataService.WebApi.Models.InputModels;
using SamplerGAN.MetadataService.WebApi.Services;
using SamplerGAN.MetadataService.WebApi.Extensions;
using SamplerGAN.MetadataService.WebApi.Models.Entities;

namespace SamplerGAN.MetadataService.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        // DI
        private IMetadataServices _metaService;

        public MetadataController(IMetadataServices metaService)
        {
            _metaService = metaService;
        }
        
        //http://localhost:5002/api/user/{id}/file/ [GET]
        // Gets all files by user id
        [Route("user/{userId:int}/file")]
        [HttpGet]
        public IActionResult GetAllFilesByUserId(int userId)
        {
            var files = _metaService.GetAllFilesByUserId(userId);
            if (!files.Any())
            {
                throw new ResourceNotFoundException("This user has no files");
            }
            return Ok(files);
        }
        
        //http://localhost:5002/api/user/{id}/folder/ [GET]
        // Gets all folders by user id
        [Route("user/{userId:int}/folder")]
        [HttpGet]
        public IActionResult GetAllFoldersByUserId(int userId)
        {
            var folders = _metaService.GetAllFoldersByUserId(userId);
            if(!folders.Any())
            {
                throw new ResourceNotFoundException("This user has no folders");
            }
            return Ok(folders);
        }
        
        //http://localhost:5002/api/user/{id}/file/{id} [GET]
        // Get file by userid and fileid ** Should be one file
        [Route("user/{userId:int}/file/{fileId:int}")]
        [HttpGet]
        public IActionResult GetFileByUserIdAndFileId(int userId, int fileId)
        {
            var file = _metaService.GetFileByUserIdAndFileId(userId, fileId);
            if(!file.Any())
            {
                throw new ResourceNotFoundException("No file was found with these requirements");
            }
            return Ok(file);
        }
        
        //http://localhost:5002/api/user/{id}/folder/{id} [GET]
        // Gets folder by userid, folderid 
        [Route("user/{userId:int}/folder/{folderId:int}")]
        [HttpGet]
        public IActionResult GetFolderByUserIdAndFolderId(int userId, int folderId)
        {
            var folder = _metaService.GetFolderByUserIdAndFolderId(userId, folderId);
            if(!folder.Any())
            {
                throw new ResourceNotFoundException("No folder was found with these requirements");
            }
            return Ok(folder);
        }
        
        //http://localhost:5002/api/user/{id}/file/ [POST]
        // Create file by user id
        [Route("user/{userId:int}/file")]
        [HttpPost]
        public IActionResult CreateFileByUserId([FromBody] FileInputModel body, int userId)
        {   
            if(!ModelState.IsValid)
            {
                return BadRequest("The input model was not correct");
            }
            // vill ég skila einhverju meira hérna en bara created ?
            _metaService.CreateFileByUserId(body, userId);
            return StatusCode(201);
        }
        
        //http://localhost:5002/api/user/{id}/folder/ [POST]
        // Create folder by user id
        [Route("user/{userId:int}/folder")]
        [HttpPost]
        public IActionResult CreateFolderByUserId([FromBody] FolderInputModel body, int userId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("The input model was not correct");
            }
            // vill ég skila einhverju meira hérna en bara created ?
            _metaService.CreateFolderByUserId(body, userId);
            return StatusCode(201);
        }
        
        // Do we need put if we have patch and create ???
        //http://localhost:5002/api/file/{id} [PUT]
        // Update file by file id
        /*[Route("file/{fileId:int}")]
        [HttpPut]
        public IActionResult UpdateFileByFileId(int fileId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/folder/{id} [PUT]
        // Update folder by folder id
        [Route("folder/{folderId:int}")]
        [HttpPut]
        public IActionResult UpdateFolderByFolderId(int folderId)
        {
            return Ok();
        }
        */

        //http://localhost:5002/api/file/{id} [PATCH]
        // Update partially file by file id
        [Route("file/{fileId:int}")]
        [HttpPatch]
        public IActionResult UpdateFilePartiallyByFileId([FromBody] FileInputModel body, int fileId)
        {
            _metaService.UpdateFilePartiallyByFileId(body, fileId);
            return NoContent();
        }
        
        //http://localhost:5002/api/folder/{id} [PATCH]
        // Update partially folder by folder id
        [Route("folder/{folderId:int}")]
        [HttpPatch]
        public IActionResult UpdateFolderPartiallyByFolderId([FromBody] FolderInputModel body, int folderId)
        {
            _metaService.UpdateFolderPartiallyByFolderId(body, folderId);
            return NoContent();
        }
        
        //http://localhost:5002/api/file/{id} [DELETE]
        // Delete file by fileid
        [Route("file/{fileId:int}")]
        [HttpDelete]
        public IActionResult DeleteFileById(int fileId)
        {
            _metaService.DeleteFileById(fileId);
            return NoContent();
        }
        
        //http://localhost:5002/api/folder/{id} [DELETE]
        // Delete folder by folderid
        [Route("folder/{folderId:int}")]
        [HttpDelete]
        public IActionResult DeleteFolderById(int folderId) 
        {
            _metaService.DeleteFolderById(folderId);
            return NoContent();
        }
    }
}
