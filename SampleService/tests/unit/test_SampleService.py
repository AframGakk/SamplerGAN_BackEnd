from unittest import TestCase
import simpleaudio as sa
import requests

from Services.SampleService.SampleService import SampleService
from Services.AuthService.AuthService import authenticate_token

class test_SampleService(TestCase):

    def test_getFileByLocation(self):
        location = '2/heavy/KICK.wav'
        service = SampleService()

        data = service.getFileByLocation(location)

        wave_obj = sa.WaveObject(data, 1, 2, 16000)

        name = ''

    def test_get_requests(self):
        URL = 'http://wisebeatstudio.com/api/auth/validate'
        token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpbGxpIiwibmJmIjoxNTc2MDAzMjI4LCJleHAiOjE1NzYwMTAxMjgsImlhdCI6MTU3NjAwMzIyOH0.NT8kmBpVHLjsYmzUx2oMoyYQfi_QsoYmgB4wMKUxCMA'

        header = {'Authorization': token}

        params = {'username': 'Villi'}
        auth_response = requests.get(URL, headers=header, params=params)

        tmp = ''


    def test_auth_service(self):
        token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpbGxpIiwibmJmIjoxNTc2MDAzMjI4LCJleHAiOjE1NzYwMTAxMjgsImlhdCI6MTU3NjAwMzIyOH0.NT8kmBpVHLjsYmzUx2oMoyYQfi_QsoYmgB4wMKUxCMA'
        username = 'Villi'

        authenticate_token(token, username)

        name = ''


