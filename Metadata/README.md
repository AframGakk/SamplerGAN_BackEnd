# README
# Metadata Service
This is the service used to get, create, update, update partially and delete files  
and folder associated with a user. Runs on port 5099 and it exposes ten endpoints:  
* /api/users/{id}/files/ [HttpGet] - _Get all files by user id_  
    ``` json
    {
        "name": "filename",
        "sound_type": "sound type ID",
        "user": "user ID"
    }
* /api/users/{id}/folders/ [HttpGet] - _Get all folders by user id_  
    ``` json
    {
        "name": "foldername",
        "parent": "parent folder ID",
        "user": "user ID"
    }

* /api/users/{id}/files/{id} [HttpGet] - _Get file by userid, fileid_  
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
* /api/users/{id}/folders/{id} [HttpGet] - _Get folder by userid, folderid_  
    ``` json
    {
        "id": "folder ID",
        "name": "foldername",
        "parent": "parent folder ID",
        "user": "user ID",
        "location": "folder location",
        "folderCreated": "datetime of file created"
    }
* /api/users/{id}/files/ [HttpPost] - _Create file by user id_  
    ``` json
    {
        "Name": "filename",
        "Sound_type": "sound type ID",
        "Location": "file location",
        "Parent": "parent folder ID",
        "User": "user ID"
    }
* /api/users/{id}/folders/ [HttpPost] - _Create folder by user id_  
    ``` json
    {
        "Name": "foldername",
        "Parent": "parent folder ID",
        "User": "user ID",
        "location": "folder location"
    }
* /api/files/{id} [HttpPatch] - _Update file partially by file id_  
    ``` json
    {
        "Name": "updated filename",
    }
* /api/folders/{id} [HttpPatch] - _Update folder partially by folder id_  
    ``` json
    {
        "Name": "updated foldername"
    }
* /api/files/{id} [HttpDelete] - _Delete file by fileid_  
* /api/folders/{id} [HttpDelete] - _Delete folder by folderid_  