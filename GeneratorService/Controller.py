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
        print(msg)
        abort(400, msg)

    if 'username' not in data:
        msg = 'username is missing from body'
        print(msg)
        abort(400, msg)

    auth_id = authenticate_token(request.headers['authorization'], data['username'])

    if not auth_id:
        print('authentication key is invalid')
        abort(403, 'Authentication key is invalid')

    if request.method == 'GET':

        if 'label' not in data:
            msg = 'label is missing from body'
            print(msg)
            abort(400, msg)

        g_data = _gService.predict()

        if g_data == None:
            msg = 'label is incorrect'
            print(msg)
            abort(400, msg)


        print('g_data'.format(g_data))

        return json.dumps({ 'success': True, 'data': g_data })



@app.route('/api/generator/version', methods = [ 'POST' ])
def job_request():
    # auth validation
    if not request.headers['Authorization']:
        abort(403, 'Header missing authenticaiton key')

    try:
        data = json.loads(request.data)
    except Exception:
        msg = 'body is not json serializable'
        abort(400, msg)

    if 'username' not in data:
        msg = 'username is missing from body'
        abort(400, msg)

    auth_id = authenticate_token(request.headers['Authorization'], data['username'])

    if not auth_id:
        abort(403, 'Authentication key is invalid')

    if request.method == 'POST':

        if 'location' not in data:
            msg = 'location is missing from body'
            abort(400, msg)

        _gService.update_model(data['location'])


        return json.dumps({ 'success': True, 'location': data['location'] })



@app.route('/healthcheck', methods = ['GET'])
def status():
    return json.dumps({'success':True}), 200, {'ContentType':'application/json'}


def test_get_sound():

    return _gService.predict()


if __name__ == '__main__':
    app.run(host='0.0.0.0', debug=False, port=5025)