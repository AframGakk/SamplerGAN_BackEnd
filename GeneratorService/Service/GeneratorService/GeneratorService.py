
from Mocks.kickArray import data as kickData

class GeneratorService:
    def __init__(self):
        self.KICK_MODEL = self.fetch_latest_model()


    def fetch_latest_model(self):
        # TODO: link with model repo
        return kickData


    def predict(self, label):
        if label == 'KICK':
            return self.__predict_kick()
        return None

    def __predict_kick(self):
        return self.KICK_MODEL