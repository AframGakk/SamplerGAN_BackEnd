
from Mocks.kickArray import data as kickData
from Repositories.ModelRepo.ModelRepo import ModelRepo

_mRepo = ModelRepo()

class GeneratorService:
    def __init__(self):
        location = 'LOCATION'
        self.KICK_MODEL = _mRepo.getModelByLocation(location)

    def fetch_latest_model(self):
        # TODO: link with model repo
        return kickData

    def predict(self, label):
        if label == 'KICK':
            return self.__predict_kick()
        return None

    def __predict_kick(self):
        return self.KICK_MODEL