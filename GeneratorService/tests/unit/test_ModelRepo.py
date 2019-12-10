from unittest import TestCase
import os

os.chdir('../..')

from Repositories.ModelRepo.ModelRepo import ModelRepo

class test_ModelRepo(TestCase):

    def test_get_model(self):
        repo = ModelRepo()
        location = 'latest/generator.h5'

        model = repo.getModelByLocation(location)

        tmp = ''
