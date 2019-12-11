from unittest import TestCase
import os
import numpy as np

os.chdir('../../')

from Repositories.SampleRepo.SampleRepo import SampleRepo


class test_SampleRepo(TestCase):

    def setUp(self):
        self.repo = SampleRepo()

    def test_init(self):
        self.assertTrue(self.repo)

    def test_getFileByLocation(self):
        location = '2/heavy/KICK.wav'

        item = self.repo.getFileByLocation(location)

        self.assertGreater(len(item), 0)


    def test_saveFileByLocation(self):

        location = '2/heavy/KICK2.wav'

        file = np.random.random(16000)

        ret = self.repo.saveFileByLocation(file, location)

        self.assertTrue(ret)


    def test_deleteByLocation(self):
        location = '2/heavy/KICK2.wav'

        ret = self.repo.deleteByLocation(location)

        name = ''

    def test_blobExists(self):
        location = '2/heavy/KICK.wav'

        ret = self.repo.blobExists(location)



