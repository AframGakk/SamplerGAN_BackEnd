from unittest import TestCase
import simpleaudio as sa

from Services.SampleService.SampleService import SampleService

class test_SampleService(TestCase):

    def test_getFileByLocation(self):
        location = '2/heavy/KICK.wav'
        service = SampleService()

        data = service.getFileByLocation(location)

        wave_obj = sa.WaveObject(data, 1, 2, 16000)

        name = ''

