FROM microsoft/dotnet

COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]

RUN rm -rf /bin/release
RUN dotnet publish -c release

ENTRYPOINT ["dotnet", "/app/bin/release/netcoreapp1.0/publish/aariveros-reporting-api.dll"]

EXPOSE 5000
