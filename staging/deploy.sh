#!/bin/bash

#gcloud config set project samplergan
#gcloud config set compute/zone europe-west3-a

# Authentication service deployment
kubectl apply -f ./staging/AuthService-dpl.yaml
kubectl apply -f ./staging/AuthService-srv.yaml

# Sample service deployment
kubectl apply -f ./staging/SampleService-dpl.yaml
kubectl apply -f ./staging/SampleService-srv.yaml

# User service deployment
kubectl apply -f ./staging/UserService-dpl.yaml
kubectl apply -f ./staging/UserService-srv.yaml

# User service deployment
kubectl apply -f ./staging/MetadataService-dpl.yaml
kubectl apply -f ./staging/MetadataService-srv.yaml


