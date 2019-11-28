﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.MetadataService.WebApi.Models.Exceptions;
using SamplerGAN.MetadataService.WebApi.Models.InputModels;
using SamplerGAN.MetadataService.WebApi.Services;
using SamplerGAN.MetadataService.WebApi.Extensions;
using SamplerGAN.MetadataService.WebApi.Models.Entities;
using System.Net.Http;

namespace SamplerGAN.MetadataService.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        // Helper function to consume Authentication WebApi
        // to validate the user who is trying to access endpoints
        static string _address = "http://localhost:5050/api/validate";
        private string result;
        private async Task<string> Validate(string jwtToken, string userName)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", jwtToken);
            HttpResponseMessage response = await client.GetAsync(_address + "?username=" + userName);
            var resp = response.IsSuccessStatusCode;
            // If resp is false, then user in unauthenticated
            // throw error
            if(resp == false)
            {
                throw new UnauthorizedException();
            }
            result = await response.Content.ReadAsStringAsync();
            // return user id
            // question about if it's needed
            return result;
        }
        // DI
        private IMetadataServices _metaService;

        public MetadataController(IMetadataServices metaService)
        {
            _metaService = metaService;
        }
        
        //http://localhost:5002/api/users/{id}/files/ [GET]
        // Gets all files by user id
        [Route("users/{userId:int}/files")]
        [HttpGet]
        public async Task<IActionResult> GetAllFilesByUserId(int userId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            var files = _metaService.GetAllFilesByUserId(userId);
            if (!files.Any())
            {
                throw new ResourceNotFoundException("This user has no files");
            }
            return Ok(files);
        }
        
        //http://localhost:5002/api/users/{id}/folders/ [GET]
        // Gets all folders by user id
        [Route("users/{userId:int}/folders")]
        [HttpGet]
        public async Task<IActionResult> GetAllFoldersByUserId(int userId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            var folders = _metaService.GetAllFoldersByUserId(userId);
            if(!folders.Any())
            {
                throw new ResourceNotFoundException("This user has no folders");
            }
            return Ok(folders);
        }
        
        //http://localhost:5002/api/user/{id}/file/{id} [GET]
        // Get file by userid and fileid ** Should be one file
        [Route("users/{userId:int}/files/{fileId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetFileByUserIdAndFileId(int userId, int fileId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            var file = _metaService.GetFileByUserIdAndFileId(userId, fileId);
            if(!file.Any())
            {
                throw new ResourceNotFoundException("No file was found with these requirements");
            }
            return Ok(file);
        }
        
        //http://localhost:5002/api/users/{id}/folders/{id} [GET]
        // Gets folder by userid, folderid 
        [Route("users/{userId:int}/folders/{folderId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetFolderByUserIdAndFolderId(int userId, int folderId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            var folder = _metaService.GetFolderByUserIdAndFolderId(userId, folderId);
            if(!folder.Any())
            {
                throw new ResourceNotFoundException("No folder was found with these requirements");
            }
            return Ok(folder);
        }
        
        //http://localhost:5002/api/users/{id}/files [POST]
        // Create file by user id
        [Route("users/{userId:int}/files")]
        [HttpPost]
        public async Task<IActionResult> CreateFileByUserId([FromBody] FileInputModel body, int userId)
        {   
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            if(!ModelState.IsValid)
            {
                return BadRequest("The input model was not correct");
            }
            // vill ég skila einhverju meira hérna en bara created ?
            _metaService.CreateFileByUserId(body, userId);
            return StatusCode(201);
        }
        
        //http://localhost:5002/api/users/{id}/folders [POST]
        // Create folder by user id
        [Route("users/{userId:int}/folders")]
        [HttpPost]
        public async Task<IActionResult> CreateFolderByUserId([FromBody] FolderInputModel body, int userId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
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

        //http://localhost:5002/api/files/{id} [PATCH]
        // Update partially file by file id
        [Route("files/{fileId:int}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateFilePartiallyByFileId([FromBody] FileInputModel body, int fileId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            _metaService.UpdateFilePartiallyByFileId(body, fileId);
            return NoContent();
        }
        
        //http://localhost:5002/api/folders/{id} [PATCH]
        // Update partially folder by folder id
        [Route("folders/{folderId:int}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateFolderPartiallyByFolderId([FromBody] FolderInputModel body, int folderId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            _metaService.UpdateFolderPartiallyByFolderId(body, folderId);
            return NoContent();
        }
        
        //http://localhost:5002/api/files/{id} [DELETE]
        // Delete file by fileid
        [Route("files/{fileId:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFileById(int fileId)
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            _metaService.DeleteFileById(fileId);
            return NoContent();
        }
        
        //http://localhost:5002/api/folders/{id} [DELETE]
        // Delete folder by folderid
        [Route("folders/{folderId:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFolderById(int folderId) 
        {
            var token = Request.Headers["Authorization"];
            var authToken = token.ToString();
            // If Authorization header is not present 
            // throw error
            if(string.IsNullOrEmpty(authToken))
            {
                throw new RequestElementsNeededException();
            }
            var queryString = Request.QueryString.ToString();
            // If Querystring is empty throw error
            if(string.IsNullOrEmpty(queryString))
            {
                throw new RequestElementsNeededException();
            }
            var userName = queryString.Split('=')[1];
            // returns user id, is it needed ?
            var result = await Validate(authToken, userName);
            _metaService.DeleteFolderById(folderId);
            return NoContent();
        }
    }
}
