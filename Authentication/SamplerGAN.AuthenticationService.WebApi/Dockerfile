FROM mcr.microsoft.com/dotnet/core/sdk:2.2
LABEL maintainer="Ívar Kristinn & Vilhjálmur R"

ENV ASPNETCORE_URLS=http://+:5050

COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet build

EXPOSE 5050

ENTRYPOINT [ "dotnet", "run" ]