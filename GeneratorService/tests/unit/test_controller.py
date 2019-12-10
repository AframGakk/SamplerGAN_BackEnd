from unittest import TestCase
import os

os.chdir('../..')

from Controller import test_get_sound

class test_controller(TestCase):

    def test_get_prediction(self):
        sound = test_get_sound()

        tmp = ''

