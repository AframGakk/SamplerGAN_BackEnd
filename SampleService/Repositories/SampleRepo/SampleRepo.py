import numpy as np
from google.cloud import storage
import os
import librosa
import soundfile as sf
import traceback
from scipy.io.wavfile import write
import io

class SampleRepo:

    def __init__(self):
        self.BUCKET_NAME = 'wisebeat-user-storage'
        self.BUCKET = storage.Client().bucket(self.BUCKET_NAME)

    def getFileByLocation(self, location):
        '''
        Fetches a file from GCP buckets by location in blob
        :param location: string, the location and filename in a string
        :return: nparray, an array of decimals making up the data of the file. None if it was not successful.
        '''
        try:
            blob = self.BUCKET.blob(location)
            file_as_string = blob.download_as_string()
        except Exception:
            print('Could not locate file in bucket')
            traceback.print_exc()
            return None

        data, sample_rate = sf.read(io.BytesIO(file_as_string))

        return data


    def saveFileByLocation(self, file, location):
        '''
        Saves the data or file in a specific location in GCP buckets. Overwrites the file if it is there
        :param file: nparray, an array of decimal numbers
        :param location: string, the location string for the file in GCP blob.
        :return: boolean, True if successful, false otherwise
        '''
        s = os.path.split(location)
        local_file = './tmp/' + os.path.split(s[0])[0] + s[1]

        try:
            sf.write(local_file, file,  16000)
        except Exception:
            print('Could not save file to tmp location')
            self.__cleanUpLocalFile(local_file)
            return False

        try:
            blob = self.BUCKET.blob(location)
            blob.upload_from_filename(local_file)
        except Exception:
            print('Could not save file to bucket')
            self.__cleanUpLocalFile(local_file)
            return False

        self.__cleanUpLocalFile(local_file)

        return True


    def deleteByLocation(self, location):
        '''
        Deletes the file by location in GCP buckets
        :param location: string, the location of the file in GCP blob
        :return: boolean, True if successful, false otherwise
        '''
        try:
            blob = self.BUCKET.blob(location)
            blob.delete()
        except Exception:
            print('Could not delete file')
            return False

        return True


    def moveFileLocation(self, old_location, new_location):
        '''
        Function moves file from old location to new location in GCP buckets
        :param old_location: string, the old location string in GCP bucket
        :param new_location: string, the new location string in GCP bucket
        :return: boolean, Was the operation success or not.
        '''
        try:
            blob = self.BUCKET.blob(old_location)
            new_blob = self.BUCKET.rename_blob(blob, new_location)
        except Exception:
            print('Locations not found')
            return False
        return True


    def blobExists(self, location):
        '''
        Check if file is located in GCP bucket
        :param location: string, the blob location string
        :return: boolean
        '''
        return storage.Blob(bucket=self.BUCKET, name=location).exists()




    def __cleanUpLocalFile(self, location):
        '''
        Helper to clean up a file in tmp folder
        :param location: string, the location of the file in tmp bucket.
        :return:
        '''
        os.remove(location)
