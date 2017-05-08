FROM microsoft/dotnet:runtime
WORKDIR /app
ADD bin/Debug/netcoreapp1.1/publish/. /app

EXPOSE 5000
CMD ["dotnet","Web.dll"]