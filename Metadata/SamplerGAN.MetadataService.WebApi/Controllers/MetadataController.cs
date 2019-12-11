using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamplerGAN.MetadataService.WebApi.Extensions;
using SamplerGAN.MetadataService.WebApi.Models.Entities;
using SamplerGAN.MetadataService.WebApi.Models.Exceptions;
using SamplerGAN.MetadataService.WebApi.Models.InputModels;
using SamplerGAN.MetadataService.WebApi.Services;

namespace SamplerGAN.MetadataService.WebApi.Controllers {
  [Route ("api/metadata/")]
  [ApiController]
  public class MetadataController : ControllerBase {
    // Helper function to consume Authentication WebApi
    // to validate the user who is trying to access endpoints
    static string _address = "http://wisebeatstudio.com/api/auth/validate";
    private string result;
    private async Task<string> Validate (string jwtToken, string userName) {
      var client = new HttpClient ();
      client.DefaultRequestHeaders.Add ("Authorization", jwtToken);
      HttpResponseMessage response = await client.GetAsync (_address + "?username=" + userName);
      var resp = response.IsSuccessStatusCode;
      // If resp is false, then user in unauthenticated
      // throw error
      if (resp == false) {
        throw new UnauthorizedException ();
      }
      result = await response.Content.ReadAsStringAsync ();
      // return user id
      // question about if it's needed
      return result;
    }
    // DI
    private IMetadataServices _metaService;

    public MetadataController (IMetadataServices metaService) {
      _metaService = metaService;
    }

    // Helper function for GCP Kubernets healthchecks
    //http://localhost:5099/api/metadata/healthchecks [GET]
    [Route ("healthchecks")]
    [HttpGet]
    public IActionResult GetHealthCheck () {
      return StatusCode (200);
    }

    //http://localhost:5099/api/metadata/users/{id}/files/ [GET]
    // Gets all files by user id
    [Route ("users/{userId:int}/files")]
    [HttpGet]
    public async Task<IActionResult> GetAllFilesByUserId (int userId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      var files = _metaService.GetAllFilesByUserId (userId);
      if (!files.Any ()) {
        throw new ResourceNotFoundException ("This user has no files");
      }
      return Ok (files);
    }

    //http://localhost:5099/api/metadata/users/{id}/folders/ [GET]
    // Gets all folders by user id
    [Route ("users/{userId:int}/folders")]
    [HttpGet]
    public async Task<IActionResult> GetAllFoldersByUserId (int userId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      var folders = _metaService.GetAllFoldersByUserId (userId);
      if (!folders.Any ()) {
        throw new ResourceNotFoundException ("This user has no folders");
      }
      return Ok (folders);
    }

    //http://localhost:5099/api/metadata/user/{id}/file/{id} [GET]
    // Get file by userid and fileid ** Should be one file
    [Route ("users/{userId:int}/files/{fileId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetFileByUserIdAndFileId (int userId, int fileId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      var file = _metaService.GetFileByUserIdAndFileId (userId, fileId);
      if (!file.Any ()) {
        throw new ResourceNotFoundException ("No file was found with these requirements");
      }
      return Ok (file);
    }

    //http://localhost:5099/api/metadata/users/{id}/folders/{id} [GET]
    // Gets folder by userid, folderid 
    [Route ("users/{userId:int}/folders/{folderId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetFolderByUserIdAndFolderId (int userId, int folderId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      var folder = _metaService.GetFolderByUserIdAndFolderId (userId, folderId);
      if (!folder.Any ()) {
        throw new ResourceNotFoundException ("No folder was found with these requirements");
      }
      return Ok (folder);
    }

    //http://localhost:5099/api/metadata/{id}[GET]
    // Gets metadata for file 
    [Route ("{fileId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetFileMetadataByFileId (int fileId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      var metadata = _metaService.GetFileMetadataByFileId (fileId);
      if (!metadata.Any ()) {
        throw new ResourceNotFoundException ("No file metadata was found with these requirements");
      }
      return Ok (metadata);
    }

    //http://localhost:5099/api/metadata/users/{id}/files [POST]
    // Create file by user id
    [Route ("users/{userId:int}/files")]
    [HttpPost]
    public async Task<IActionResult> CreateFileByUserId ([FromBody] FileInputModel body, int userId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      if (!ModelState.IsValid) {
        return BadRequest ("The input model was not correct");
      }
      var newFileId = _metaService.CreateFileByUserId (body, userId);
      // kalla hérna á _metaService
      _metaService.CreateMetadataForFile (newFileId);
      return StatusCode (201, newFileId);
    }

    //http://localhost:5099/api/metadata/users/{id}/folders [POST]
    // Create folder by user id
    [Route ("users/{userId:int}/folders")]
    [HttpPost]
    public async Task<IActionResult> CreateFolderByUserId ([FromBody] FolderInputModel body, int userId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      if (!ModelState.IsValid) {
        return BadRequest ("The input model was not correct");
      }
      // vill ég skila einhverju meira hérna en bara created ?
      var newFolderId = _metaService.CreateFolderByUserId (body, userId);
      return StatusCode (201, newFolderId);
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

    //http://localhost:5099/api/metadata/files/{id} [PATCH]
    // Update partially file by file id
    [Route ("files/{fileId:int}")]
    [HttpPatch]
    public async Task<IActionResult> UpdateFilePartiallyByFileId ([FromBody] FileInputModel body, int fileId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      _metaService.UpdateFilePartiallyByFileId (body, fileId);
      return NoContent ();
    }

    //http://localhost:5099/api/metadata/folders/{id} [PATCH]
    // Update partially folder by folder id
    [Route ("folders/{folderId:int}")]
    [HttpPatch]
    public async Task<IActionResult> UpdateFolderPartiallyByFolderId ([FromBody] FolderInputModel body, int folderId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      _metaService.UpdateFolderPartiallyByFolderId (body, folderId);
      return NoContent ();
    }

    //http://localhost:5099/api/metadata/{id} [PUT]
    // Update partially metadata by id
    [Route ("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> UpdateMetadataById ([FromBody] MetadataInputModel body, int id) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      var newMeta = _metaService.UpdateMetadataById (body, id);
      return StatusCode (202, newMeta);
    }

    //http://localhost:5099/api/metadata/files/{id} [DELETE]
    // Delete file by fileid
    // Needs to delete metadata for that file also
    [Route ("files/{fileId:int}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteFileById (int fileId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      _metaService.DeleteFileById (fileId);
      return NoContent ();
    }

    //http://localhost:5099/api/metadata/folders/{id} [DELETE]
    // Delete folder by folderid
    // Needs to check if this folder has any files and delete them to also their metadata
    [Route ("folders/{folderId:int}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteFolderById (int folderId) {
      var token = Request.Headers["Authorization"];
      var authToken = token.ToString ();
      // If Authorization header is not present 
      // throw error
      if (string.IsNullOrEmpty (authToken)) {
        throw new RequestElementsNeededException ();
      }
      var queryString = Request.QueryString.ToString ();
      // If Querystring is empty throw error
      if (string.IsNullOrEmpty (queryString)) {
        throw new RequestElementsNeededException ();
      }
      var userName = queryString.Split ('=') [1];
      // returns user id, is it needed ?
      var result = await Validate (authToken, userName);
      _metaService.DeleteFolderById (folderId);
      return NoContent ();
    }
  }
}