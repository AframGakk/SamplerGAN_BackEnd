from Repositories.ModelRepo.ModelRepo import ModelRepo
import traceback
from keras.models import load_model
import numpy as np

_mRepo = ModelRepo()

class GeneratorService:
    def __init__(self):
        '''
        Generator services
        '''
        location = 'latest/generator.h5'
        self.model = load_model(_mRepo.getModelByLocation(location))
        self.model._make_predict_function()

    def update_model(self, location):
        print('Updating model')
        location = 'latest/generator.h5'
        del self.model
        self.model = load_model(_mRepo.getModelByLocation(location))
        self.model._make_predict_function()

    def predict(self):
        noise = np.random.normal(-1, 1, (1, 100))
        try:
            sound = self.model.predict(noise).flatten()
        except:
            print('Error in model prediction!')
            traceback.print_exc()

        return sound.tolist()


