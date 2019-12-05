#!/usr/bin/env bash

gcloud builds submit --tag gcr.io/samplergan/sample-service ./SampleService/
gcloud builds submit --tag gcr.io/samplergan/user-service ./UserService/
gcloud builds submit --tag gcr.io/samplergan/auth-service ./Authentication/SamplerGAN.AuthenticationService.WebApi
gcloud builds submit --tag gcr.io/samplergan/metadata-service ./Metadata/SamplerGAN.MetadataService.WebApi


