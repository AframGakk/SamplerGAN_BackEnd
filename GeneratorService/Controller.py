from flask import Flask
from flask import request, abort, json, jsonify, g
import re

from Service.AuthService.AuthService import authenticate_token
from Service.GeneratorService.GeneratorService import GeneratorService

_gService = GeneratorService()

app = Flask(__name__)


@app.route('/api/generator', methods = ['GET' ])
def generate_sound_request():

    # auth validation
    if not request.headers['authorization']:
        abort(403, 'Header missing authenticaiton key')

    try:
        data = json.loads(request.data)
    except Exception:
        msg = 'body is not json serializable'
        abort(400, msg)

    if 'username' not in data:
        msg = 'username is missing from body'
        abort(400, msg)

    auth_id = authenticate_token(request.headers['authorization'], data['username'])

    if not auth_id:
        abort(403, 'Authentication key is invalid')

    if request.method == 'GET':

        if 'label' not in data:
            msg = 'label is missing from body'
            abort(400, msg)

        g_data = _gService.predict(data['label'])

        if g_data == None:
            msg = 'label is incorrect'
            abort(400, msg)


        return json.dumps({ 'success': True, 'data': g_data })



@app.route('/api/generator/version', methods = [ 'POST' ])
def job_request():

    # auth validation
    if not request.headers['authorization']:
        abort(403, 'Header missing authenticaiton key')

    auth_id = authenticate_token(request.headers['authorization'])

    if not auth_id:
        abort(403, 'Authentication key is invalid')

    if request.method == 'GET':
        try:
            data = json.loads(request.data)
        except Exception:
            msg = 'body is not json serializable'
            abort(400, msg)

        if 'userId' not in data:
            msg = 'userId is missing from body'
            abort(400, msg)
        elif 'location' not in data:
            msg = 'location is missing from body'
            abort(400, msg)

        auth_pattern = '^{}/'.format(auth_id)
        if not re.match(auth_pattern, data['location']):
            msg = 'Forbidden access to folder'
            abort(403, msg)




        return json.dumps({ 'success': True, 'location': data['location'] })


if __name__ == '__main__':
    app.run(debug=False, port=5025)