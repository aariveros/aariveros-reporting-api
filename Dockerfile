FROM microsoft/dotnet

ARG MSSQL_DB_HOST
ARG MSSQL_DB_PORT
ARG MSSQL_DB_USER
ARG MSSQL_DB_PASSWORD
ARG MSSQL_DB_DATABASE

RUN printenv

COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]

RUN rm -rf /bin/release
RUN dotnet publish -c release
COPY /bin/release/netcoreapp1.0/publish/. .

ENTRYPOINT ["dotnet", "/app/aariveros-reporting-api.dll"]

EXPOSE 5000
