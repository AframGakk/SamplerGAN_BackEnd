#!/usr/bin/env bash

kubectl scale deployment sample-service-v1 --replicas=0
kubectl scale deployment sample-service-v1 --replicas=1

kubectl scale deployment user-service-v1 --replicas=0
kubectl scale deployment user-service-v1 --replicas=1

kubectl scale deployment auth-service-v1 --replicas=0
kubectl scale deployment auth-service-v1 --replicas=1

kubectl scale deployment metadata-service-v1 --replicas=0
kubectl scale deployment metadata-service-v1 --replicas=1

kubectl scale deployment generator-service-v1 --replicas=0
kubectl scale deployment generator-service-v1 --replicas=1

