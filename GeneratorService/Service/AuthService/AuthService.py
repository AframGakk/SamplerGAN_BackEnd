
TOKEN_MOCK = 'ghrwigljadfhlgjeflbk'
id = 2

def authenticate_token(token):

    if token != TOKEN_MOCK:
        # TODO: Request the token to authentication service
        return False

    return id