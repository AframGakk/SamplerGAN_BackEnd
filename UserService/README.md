# README
# User Service
This is the service used to get, get by id, create, update partially and  delete users. Runs on port 5000 and it exposes five endpoints:  
* /api/users [HttpGet] - _Gets all users, returns list of users like seen below_  
    ``` json
    {
        "userName": "username",
        "firstName": "first name",
        "lastName": "last name"
    }
* /api/users/{id} [HttpGet] - _Gets user by id, returns one user like seen below_  
    ``` json
    {
        "id": "userID",
        "userName": "username",
        "firstName": "first name",
        "lastName": "last name",
        "email": "user email",
        "userCreated": "datetime of user created"
    }
* /api/users [HttpPost] - _Create a user returns new userID, this input model needs to be filled, as seen below_  
    ``` json
    {
        "userName": "username",
        "firstName": "first name",
        "lastName": "last name",
        "email": "user email",
        "password": "user password"
    }
* /api/users/{id} [HttpPatch] - _Update user partially by id, for example this input model as seen below_  
    ``` json
    {
        "firstName": "Editname",
        "lastName": "Editname",
    }
* /api/users/{id} [HttpDelete] - _Delete user by id_  
