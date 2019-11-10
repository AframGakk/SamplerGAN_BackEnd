# README
# Authentication Service
This is the service used to authenticate users and validate them.  
Runs on port 5001 and it exposes two endpoints:  
* /api/authenticate [HttpPost] - _Authenticates users_ return JWT token in respone
* /api/validate [HttpGet] - _Validates users_ returns users id in responses