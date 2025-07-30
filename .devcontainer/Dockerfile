FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Instalar herramientas necesarias
RUN apt-get update && apt-get install -y \
    curl \
    gnupg2 \
    unzip \
    git \
    apt-transport-https \
    software-properties-common && \
    rm -rf /var/lib/apt/lists/*

# Instalar Node.js si es necesario
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs

# Instalar ODBC Driver de SQL Server (versión 18)
RUN curl -sSL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl -sSL https://packages.microsoft.com/config/debian/11/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y msodbcsql18 unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc

# Configurar PATH
ENV PATH="${PATH}:/root/.dotnet/tools:/opt/mssql-tools/bin"

# Variables de entorno (puedes sobreescribirlas en devcontainer.json si es necesario)
ENV SQL_SERVER_HOST="sql-server-host"
ENV SQL_SERVER_USER="sa"
ENV SQL_SERVER_PASSWORD="your_strong_password"
ENV SQL_SERVER_DATABASE="master"
