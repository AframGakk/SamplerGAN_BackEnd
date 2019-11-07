from flask import Flask
from flask import request, abort, json, jsonify, g
import re

from Services.SampleService.SampleService import SampleService
from Services.AuthService.AuthService import authenticat_token

_sampleService = SampleService()

app = Flask(__name__)


@app.route('/api/sample', methods = ['POST', 'GET', 'DELETE', 'PUT' ])
def job_request():

    # auth validation
    if not request.headers['authorization']:
        abort(403, 'Header missing authenticaiton key')

    auth_id = authenticat_token(request.headers['authorization'])

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

        wav_data = _sampleService.getFileByLocation(data['location'])

        if wav_data is None:
            abort(404, 'File not found!')

        return json.dumps({ 'success': True, 'location': data['location'], 'data': wav_data.tolist() })


    elif request.method == 'POST':

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
        elif 'data' not in data:
            msg = 'Data missing from body'
            abort(400, msg)

        auth_pattern = '^{}/'.format(auth_id)
        if not re.match(auth_pattern, data['location']):
            msg = 'Forbidden access to folder'
            abort(403, msg)

        if not _sampleService.saveFileByLocation(data['data'], data['location']):
            return abort(500, 'File could not be saved!')

        return json.dumps({ 'success': True, 'location': data['location'] })


    elif request.method == 'DELETE':

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

        if not _sampleService.deleteFileByLocation(data['location']):
            abort(404, 'File was not found!')

        return json.dumps({ 'success': True, 'location': data['location'] })


    elif request.method == 'PUT':

        try:
            data = json.loads(request.data)
        except Exception:
            msg = 'body is not json serializable'
            abort(400, msg)

        if 'userId' not in data:
            msg = 'userId is missing from body'
            abort(400, msg)
        elif 'new_location' not in data:
            msg = 'new_location is missing from body'
            abort(400, msg)
        elif 'old_location' not in data:
            msg = 'old_location is missing from body'
            abort(400, msg)

        auth_pattern = '^{}/'.format(auth_id)
        if not re.match(auth_pattern, data['new_location']):
            msg = 'Forbidden access to folder {}'.format(data['new_location'])
            abort(403, msg)

        if not re.match('^' + str(auth_id), data['old_location']):
            msg = 'Forbidden access to folder {}'.format(data['old_location'])
            abort(403, msg)

        if not _sampleService.moveFileLocation(data['old_location'], data['new_location']):
            abort(404, 'File or folder not found!')

        return json.dumps({ 'success': True, 'location': data['new_location']})




@app.route('/api/sample/exists', methods = [ 'GET' ])
def sample_exists():

    # auth validation
    if not request.headers['authorization']:
        abort(403, 'Header missing authenticaiton key')

    auth_id = authenticat_token(request.headers['authorization'])

    if not auth_id:
        abort(403, 'Authentication key is invalid')

    if request.method == 'GET':
        try:
            data = json.loads(request.data)
        except Exception:
            msg = 'body is not json serializable'
            abort(400, msg)

        if 'location' not in data:
            msg = 'location is missing from body'
            abort(400, msg)

    auth_pattern = '^{}/'.format(auth_id)
    if not re.match(auth_pattern, data['location']):
        msg = 'Forbidden access to folder {}'.format(data['location'])
        abort(403, msg)

    return json.dumps({ 'success': True, 'data': _sampleService.fileExistsInLocation(data['location']) })


if __name__ == '__main__':
    app.run(debug=False, port=5020)



