using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SamplerGAN.MetadataService.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        // TODO Global exception handler
        
        // DI
        
        //http://localhost:5002/api/user/{id}/file/ [GET]
        // Gets all files by user id
        [Route("user/{userId:int}/file")]
        [HttpGet]
        public IActionResult GetAllFilesByUserId(int userId) 
        {
            return Ok();
        }
        
        //http://localhost:5002/api/user/{id}/folder/ [GET]
        // Gets all folders by user id
        [Route("user/{userId:int}/folder")]
        [HttpGet]
        public IActionResult GetAllFoldersByUserId(int userId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/user/{id}/file/{id} [GET]
        // Gets file by userid, fileid
        [Route("user/{userId:int}/file/{fileId:int}")]
        [HttpGet]
        public IActionResult GetFileByUserIdAndFileId(int userId, int fileId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/user/{id}/folder/{id} [GET]
        // Gets folder by userid, folderid 
        [Route("user/{userId:int}/folder/{folderId:int}")]
        [HttpGet]
        public IActionResult GetFolderByUserIdAndFolderId(int userId, int folderId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/user/{id}/file/ [POST]
        // Create file by user id
        [Route("user/{userId:int}/file")]
        [HttpPost]
        public IActionResult CreateFileByUserId(int userId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/user/{id}/folder/ [POST]
        // Create folder by user id
        [Route("user/{userId:int}/folder")]
        [HttpPost]
        public IActionResult CreateFolderByUserId(int userId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/file/{id} [PUT]
        // Update file by file id
        [Route("file/{fileId:int}")]
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
        
        //http://localhost:5002/api/file/{id} [PATCH]
        // Update partially file by file id
        [Route("file/{fileId:int}")]
        [HttpPatch]
        public IActionResult UpdateFilePartiallyByFileId(int fileId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/folder/{id} [PATCH]
        // Update partially folder by folder id
        [Route("folder/{folderId:int}")]
        [HttpPatch]
        public IActionResult UpdateFolderPartiallyByFolderId(int folderId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/file/{id} [DELETE]
        // Delete file by fileid
        [Route("file/{fileId:int}")]
        [HttpDelete]
        public IActionResult DeleteFileById(int fileId)
        {
            return Ok();
        }
        
        //http://localhost:5002/api/folder/{id} [DELETE]
        // Delete folder by folderid
        [Route("folder/{folderId:int}")]
        [HttpDelete]
        public IActionResult DeleteFolderById(int folderId) 
        {
            return Ok();
        }
    }
}
