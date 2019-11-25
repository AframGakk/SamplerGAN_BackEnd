from unittest import TestCase
import requests
import json
import os

from Services.AuthService.AuthService import authenticate_token

class test_AuthServiceIntegraion(TestCase):

    def test_validate(self):

        token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpbGxpIiwibmJmIjoxNTczNDg4NDM1LCJleHAiOjE1NzM0ODg0OTUsImlhdCI6MTU3MzQ4ODQzNX0.0vth-N01AjH7aUOxJ-JMh92SFAPrzYNtwgpWqae-ITk'
        resp = authenticate_token(token, 'Villi')

        name = ''






