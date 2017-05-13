FROM microsoft/dotnet:runtime
ENTRYPOINT ["dotnet","Web.dll"]
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
ENV REDIS_CONNECTIONSTRING redis:6379
ENV READMODELS_CONNECTIONSTRING mongodb://readmodels:27017
ENV EVENTSTORE_CONNECTIONSTRING mongodb://eventstore:27017

ADD bin/Debug/netcoreapp1.1/publish/. /app

EXPOSE 5000