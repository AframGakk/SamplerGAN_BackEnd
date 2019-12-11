FROM python:3.7

RUN apt-get update
RUN apt-get install -y libsndfile1-dev

WORKDIR /usr/src/app

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt

ENV PYTHONUNBUFFERED=1

COPY . .

ENV AUTH_SERVER='http://localhost:5050'

# TODO: REMOVE
ENV GOOGLE_APPLICATION_CREDENTIALS=./bucket.json


EXPOSE 5020

CMD [ "python", "./Controller.py" ]