from Mocks.kickArray import data as kickData
from Repositories.ModelRepo.ModelRepo import ModelRepo
import traceback

from keras.models import load_model
import numpy as np

_mRepo = ModelRepo()

class GeneratorService:
    def __init__(self):
        location = 'latest/generator.h5'
        self.model = load_model(_mRepo.getModelByLocation(location))

    def update_model(self, location):
        print('Updating model')
        self.model = load_model(_mRepo.getModelByLocation(location))

    def predict(self):
        noise = np.random.normal(-1, 1, (1, 100))
        try:
            sound = self.model.predict(noise)
        except:
            print('Error in model prediction!')
            traceback.print_exc()

        return sound[0].tolist()


