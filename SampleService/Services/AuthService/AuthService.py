import requests
from os import environ

SERVER_URL = 'http://localhost:5001'#environ['AUTH_SERVER']

def authenticate_token(token, username):
    URL_END = '/api/validate'
    URL = SERVER_URL + URL_END

    header = {'Authorization': token }
    params = { 'UserName': username }
    auth_response = requests.get(URL, headers=header, params=params)

    if not auth_response.ok:
        return False
    else:
        auth_response = auth_response.json()

        return auth_response


