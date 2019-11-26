# README
# User Service
This is the service used to get, create, update partially and delete users.  
Runs on port 5000 and it exposes five endpoints:  
* /api/users [HttpGet] - _Get all users_  
    ``` json
    {
        "userName": "username",
        "firstName": "first name",
        "lastName": "last name"
    }
* /api/users/{id} [HttpGet] - _Gets user by id_  
    ``` json
    {
        "id": "userID",
        "userName": "username",
        "firstName": "first name",
        "lastName": "last name",
        "email": "user email",
        "userCreated": "datetime of user created"
    }
* /api/users [HttpPost] - _Create a user returns new userID_  
    ``` json
    {
        "id": "userID",
        "userName": "username",
        "firstName": "first name",
        "lastName": "last name",
        "email": "user email",
        "userCreated": "datetime of user created"
    }
* /api/users/{id} [HttpPatch] - _Update user partially by id_  
    ``` json
    {
        "firstName": "Editname",
        "lastName": "Editname",
    }
* /api/users/{id} [HttpDelete] - _Delete user by id_  
