import requests
from os import environ

SERVER_URL = environ['AUTH_SERVER']

def authenticate_token(token, username):
    URL_END = '/api/auth/validate'
    URL = SERVER_URL + URL_END

    header = {'Authorization': token }
    params = { 'username': username }

    auth_response = requests.get(URL, headers=header, params=params, timeout=5)

    if not auth_response.ok:
        print(auth_response)
        return False
    else:
        auth_response = auth_response.json()
        return auth_response