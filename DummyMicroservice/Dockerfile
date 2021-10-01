FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim

# Override the default 'docker stop' signal (SIGTERM) to use SIGINT. 
STOPSIGNAL SIGINT


WORKDIR /home/app

COPY . .

ENTRYPOINT ["dotnet", "DummyMicroservice.dll"]