# README

# Metadata Service

This is the service used to get, create, update, update partially and delete files, metadata for those files and folders associated with a user. Runs on port 5099 and it exposes ten endpoints:

- /api/users/{id}/files/ [HttpGet] - _Get all files by user id, returns list of files, as seen below_
  ```json
  {
    "id": "file ID",
    "name": "filename",
    "sound_type": "sound type ID",
    "location": "location of the file",
    "parent": "parent ID",
    "user": "user ID"
  }
  ```
- /api/users/{id}/folders/ [HttpGet] - _Get all folders by user id, returns list of folders, as seen below_

  ```json
  {
    "id": "folder ID",
    "name": "foldername",
    "parent": "parent folder ID",
    "user": "user ID"
  }
  ```

- /api/users/{id}/files/{id} [HttpGet] - _Get file by userid, fileid. Returns one file, as seen below_
  ```json
  {
    "id": "file ID",
    "name": "filename",
    "sound_type": "sound type ID",
    "location": "file location",
    "parent": "parent folder ID",
    "user": "user ID",
    "fileCreated": "datetime of file created"
  }
  ```
- /api/users/{id}/folders/{id} [HttpGet] - _Get folder by userid, folderid. Returns one folder, as seen below_
  ```json
  {
    "id": "folder ID",
    "name": "foldername",
    "parent": "parent folder ID",
    "user": "user ID",
    "location": "folder location",
    "folderCreated": "datetime of file created"
  }
  ```
- /api/metadata/{id} [HttpGet] - _Get metadata for file by fileid. Returns one metadata, as seen below_
  ```json
  {
    "id": "metadata ID",
    "file_id": "file ID corresponding with metadata",
    "gain": "value of gain",
    "attack": "value of attack",
    "decay": "value of decay",
    "hold": "value of hold",
    "reverb": "value of reverb",
    "delay": "value of delay",
    "cutoff": "value of cutoff",
    "reso": "value of reso",
    "fx": "bool value of fx",
    "envelopes": "bool value of envelopes",
    "filters": "bool value of filters"
  }
  ```

* /api/users/{id}/files/ [HttpPost] - _Create file by user id, this input model needs to be filled, as seen below_
  ```json
  {
    "name": "filename",
    "sound_type": "sound type ID",
    "location": "file location",
    "parent": "parent folder ID"
  }
  ```
* /api/users/{id}/folders/ [HttpPost] - _Create folder by user id, this input model needs to be filled, as seen below_
  ```json
  {
    "name": "foldername",
    "parent": "parent folder ID",
    "location": "folder location"
  }
  ```
* /api/files/{id} [HttpPatch] - _Update file partially by file id, for example this input model as seen below_
  ```json
  {
    "name": "updated filename"
  }
  ```
* /api/folders/{id} [HttpPatch] - _Update folder partially by folder id, for example this input model as seen below_
  ```json
  {
    "name": "updated foldername"
  }
  ```
* /api/metadata/{id} [HttpPut] - _Update metadata by id, this input model needs to be filled, as seen below_
  ```json
  {
    "id": "metadata ID",
    "file_id": "file ID corresponding with metadata",
    "gain": "value of gain",
    "attack": "value of attack",
    "decay": "value of decay",
    "hold": "value of hold",
    "reverb": "value of reverb",
    "delay": "value of delay",
    "cutoff": "value of cutoff",
    "reso": "value of reso",
    "fx": "bool value of fx",
    "envelopes": "bool value of envelopes",
    "filters": "bool value of filters"
  }
  ```
* /api/files/{id} [HttpDelete] - _Delete file by fileid_
* /api/folders/{id} [HttpDelete] - _Delete folder by folderid_
