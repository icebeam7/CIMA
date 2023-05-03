FROM mcr.microsoft.com/mssql/server:2022-latest

ENV SA_PASSWORD=Cima_2023*
ENV ACCEPT_EULA=Y

COPY /Script.sql /usr/src/app/

RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i /usr/src/app/Script.sql \
    && pkill sqlservr 
