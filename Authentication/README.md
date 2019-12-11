# README
# Authentication Service
This is the service used to authenticate users and validate them.  
Runs on port 5050 and it exposes two endpoints:  
* /api/authenticate [HttpPost] - _Authenticates users and return JWT token in response_
    ``` json
    {
        "Username": "username",
	    "Password": "userpassword"
    }
* /api/validate [HttpGet] - _Validates user with username and authenticated jwt token returns User ID in response_
    ``` json
    {
        "userId"
    }
