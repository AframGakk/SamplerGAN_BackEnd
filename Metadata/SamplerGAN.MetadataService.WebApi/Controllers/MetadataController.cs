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
        
        // Gets all files by user id /api/user/{id}/file/
        [Route("user/{userId:int}/file")]
        [HttpGet]
        
        // Gets all folders by user id /api/user/{id}/folder/
        [Route("user/{userId:int}/folder")]
        [HttpGet]
        
        // Gets file by userid, fileid /api/user/{id}/file/{id}
        [Route("user/{userId:int}/file/{fileId:int}")]
        [HttpGet]
        
        // Gets folder by userid, folderid /api/user/{id}/folder/{id}
        [Route("user/{userId:int}/folder/{folderId:int}")]
        [HttpGet]
        
        // Create file by user id /api/user/{id}/file/
        [Route("user/{userId:int}/file")]
        [HttpPost]
        
        // Create folder by user id /api/user/{id}/folder/
        [Route("user/{userId:int}/folder")]
        [HttpPost]
        
        // Update file by file id /api/file/{id}
        [Route("file/{fileId:int}")]
        [HttpPut]
        
        // Update folder by folder id /api/folder/{id}
        [Route("folder/{folderId:int}")]
        [HttpPut]
        
        // Update partially file by file id /api/file/{id}
        [Route("file/{fileId:int}")]
        [HttpPatch]
        
        // Update partially folder by folder id /api/folder/{id}
        [Route("folder/{folderId:int}")]
        [HttpPatch]
        
        // Delete file by fileid /api/file/{id}
        [Route("file/{fileId:int}")]
        [HttpDelete]
        
        // Delete folder by folderid /api/folder/{id}
        [Route("folder/{folderId:int}")]
        [HttpDelete]
    }
}
