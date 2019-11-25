FROM mcr.microsoft.com/dotnet/core/sdk:2.2
LABEL maintainer="Ívar Kristinn & Vilhjálmur R"

ENV ASPNETCORE_URLS=http://*:5000

COPY . /app
WORKDIR /app/SamplerGAN.UserService.WebApi
RUN dotnet restore
RUN dotnet build

ENTRYPOINT [ "dotnet", "run" ]