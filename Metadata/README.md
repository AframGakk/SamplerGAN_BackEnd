# README
# Metadata Service
This is the service used to get, create, update, update partially and delete files  
and folder associated with a user. Runs on port 5099 and it exposes ten endpoints:  
* /api/user/{id}/file/ [HttpGet] - _Get all files by user id_  
    ``` json
    {
        "name": "filename",
        "sound_type": "sound type ID",
        "user": "user ID"
    }
    ``` json
* /api/user/{id}/folder/ [HttpGet] - _Get all folders by user id_  
    ``` json
    {
        "name": "foldername",
        "parent": "parent folder ID",
        "user": "user ID"
    }
    ``` json
* /api/user/{id}/file/{id} [HttpGet] - _Get file by userid, fileid_  
    ``` json
    {
        "id": "file ID",
        "name": "filename",
        "sound_type": "sound type ID",
        "location": "file location",
        "parent": "parent folder ID",
        "user": "user ID",
        "fileCreated": "datetime of file created"
    }
    ``` json
* /api/user/{id}/folder/{id} [HttpGet] - _Get folder by userid, folderid_  
    ``` json
    {
        "id": "folder ID",
        "name": "foldername",
        "parent": "parent folder ID",
        "user": "user ID",
        "location": "folder location",
        "folderCreated": "datetime of file created"
    }
    ``` json
* /api/user/{id}/file/ [HttpPost] - _Create file by user id_  
    ``` json
    {
        "Name": "filename",
        "Sound_type": "sound type ID",
        "Location": "file location",
        "Parent": "parent folder ID",
        "User": "user ID"
    }
    ``` json
* /api/user/{id}/folder/ [HttpPost] - _Create folder by user id_  
    ``` json
    {
        "Name": "foldername",
        "Parent": "parent folder ID",
        "User": "user ID",
        "location": "folder location"
    }
    ``` json
* /api/file/{id} [HttpPatch] - _Update file partially by file id_  
    ``` json
    {
        "Name": "updated filename",
    }
    ``` json
* /api/folder/{id} [HttpPatch] - _Update folder partially by folder id_  
    ``` json
    {
        "Name": "updated foldername"
    }
    ``` json
* /api/file/{id} [HttpDelete] - _Delete file by fileid_  
* /api/folder/{id} [HttpDelete] - _Delete folder by folderid_  