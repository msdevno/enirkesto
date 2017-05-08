FROM microsoft/dotnet:runtime
ENTRYPOINT ["dotnet","Web.dll"]
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000

ADD bin/Debug/netcoreapp1.1/publish/. /app

EXPOSE 5000