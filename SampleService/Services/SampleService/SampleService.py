
from Repositories.SampleRepo.SampleRepo import SampleRepo

_sRepo = SampleRepo()

class SampleService:

    def getFileByLocation(self, location):
        data = _sRepo.getFileByLocation(location)
        return data


    def saveFileByLocation(self, data, location):
        return _sRepo.saveFileByLocation(data, location)

    def deleteFileByLocation(self, location):
        return _sRepo.deleteByLocation(location)


    def moveFileLocation(self, old_location, new_location):
        return _sRepo.moveFileLocation(old_location, new_location)

    def fileExistsInLocation(self, location):
        return _sRepo.blobExists(location)