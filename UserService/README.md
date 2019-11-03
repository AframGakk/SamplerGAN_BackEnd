# README
# User Service
This is the service used to get, create, update partially and delete users.  
Runs on port 5000 and it exposes five endpoints:  
* /api/users [HttpGet] - _Get all users_ 
* /api/users/{id} [HttpGet] - _Gets user by id_ 
* /api/users [HttpPost] - _Create a user_  
* /api/users/{id} [HttpPatch] - _Update user partially by id_
* /api/users/{id} [HttpDelete] - _Delete user by id_ 