# README
# Metadata Service
This is the service used to get, create, update, update partially and delete files  
and folder associated with a user. Runs on port 5002 and it exposes twelve endpoints:  
* /api/user/{id}/file/ [HttpGet] - _Get all files by user id_ 
* /api/user/{id}/folder/ [HttpGet] - _Get all folders by user id_ 
* /api/user/{id}/file/{id} [HttpGet] - _Get file by userid, fileid_
* /api/user/{id}/folder/{id} [HttpGet] - _Get folder by userid, folderid_  
* /api/user/{id}/file/ [HttpPost] - _Create file by user id_  
* /api/user/{id}/folder/ [HttpPost] - _Create folder by user id_
* /api/file/{id} [HttpPut] - _Update file by file id_
* /api/folder/{id} [HttpPut] - _Update folder by folder id_ 
* /api/file/{id} [HttpPatch] - _Update file partially by file id_
* /api/folder/{id} [HttpPatch] - _Update folder partially by folder id_
* /api/file/{id} [HttpDelete] - _Delete file by fileid_
* /api/folder/{id} [HttpDelete] - _Delete folder by folderid_ 