FROM microsoft/dotnet:latest
COPY ./bin/Release/netcoreapp1.0/publish /root/
EXPOSE 80/tcp
ENTRYPOINT dotnet /root/SKMBingo.dll