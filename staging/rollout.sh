#!/usr/bin/env bash

kubectl scale deployment sample-service --replicas=0
kubectl scale deployment sample-service --replicas=1

kubectl scale deployment user-service --replicas=0
kubectl scale deployment user-service --replicas=1

kubectl scale deployment auth-service --replicas=0
kubectl scale deployment auth-service --replicas=1

kubectl scale deployment metadata-service --replicas=0
kubectl scale deployment metadata-service --replicas=1