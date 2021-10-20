from unittest import TestCase
import os
import requests
import tensorflow as tf

os.chdir('../..')

from Service.GeneratorService.GeneratorService import GeneratorService


class test_GeneratorService(TestCase):

    def test_init(self):
        service = GeneratorService()
        self.assertTrue(service.model)

    def test_predict_from_noise(self):
        service = GeneratorService()
        sound = service.predict()
        self.assertEqual(len(sound), 64000)

    def test_update_model(self):
        service = GeneratorService()

        location = 'latest/generator.h5'
        service.update_model(location)
        sound = service.predict()
        self.assertEqual(len(sound), 64000)













