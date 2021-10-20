from google.cloud import storage

class ModelRepo:

    def __init__(self):
        self.BUCKET = storage.Client().bucket('wisebeat-model-storage')

    def getModelByLocation(self, location):
        local_file = './tmp/generator.h5'
        try:
            blob = self.BUCKET.blob(location)
            blob.download_to_filename(local_file)
        except Exception:
            print('Could not locate file in bucket')
            return None

        return local_file


