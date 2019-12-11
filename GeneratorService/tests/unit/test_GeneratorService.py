from unittest import TestCase
import os
import requests

os.chdir('../..')

from Service.GeneratorService.GeneratorService import GeneratorService

class test_GeneratorService(TestCase):

    def test_init(self):
        service = GeneratorService()

        self.assertTrue(service.model)

    def test_predict_from_noise(self):
        service = GeneratorService()

        sound = service.predict()

        tmp = ''


    def test_request(self):
        URL = 'https://vrv.panda.encode.dk/panda/.well-known/jwks.json'
        tasks = requests.get(URL)

        if tasks.ok:
            tasks = tasks.json()

        name = ''

