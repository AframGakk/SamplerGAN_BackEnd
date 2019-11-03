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
        
        // GET all files by user id /api/user/{id}/file/
        [Route("user/{id:int}/file")]
        [HttpGet]
        
        // GET all folders by user id /api/user/{id}/folder/
        [Route("user/{id:int}/folder")]
        [HttpGet]
        
        // GET file by userid, fileid /api/user/{id}/file/{id}
        [Route("user/{id:int}/file/{id:int}")]
        [HttpGet]
        
        // GET folder by userid, folderid /api/user/{id}/folder/{id}
        [Route("user/{id:int}/folder/{id:int}")]
        [HttpGet]
        
        // POST file by user id /api/user/{id}/file/
        [Route("user/{id:int}/file")]
        [HttpPost]
        
        // POST folder by user id /api/user/{id}/folder/
        [Route("user/{id:int}/folder")]
        [HttpPost]
        
        // PUT file by file id /api/file/{id}
        [Route("file/{id:int}")]
        [HttpPut]
        
        // PUT folder by folder id /api/folder/{id}
        [Route("folder/{id:int}")]
        [HttpPut]
        
        // PATCH file by file id /api/file/{id}
        [Route("file/{id:int}")]
        [HttpPatch]
        
        // PATCH folder by folder id /api/folder/{id}
        [Route("folder/{id:int}")]
        [HttpPatch]
        
        // DELETE file by fileid /api/file/{id}
        [Route("file/{id:int}")]
        [HttpDelete]
        
        // DELETE folder by folderid /api/folder/{id}
        [Route("folder/{id:int}")]
        [HttpDelete]
    }
}
