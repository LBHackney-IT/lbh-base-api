FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ENV DynamoDb_LocalMode='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./BaseApi.sln ./
COPY ./BaseApi/BaseApi.csproj ./BaseApi/
COPY ./BaseApi.Tests/BaseApi.Tests.csproj ./BaseApi.Tests/

RUN dotnet restore ./BaseApi/BaseApi.csproj
RUN dotnet restore ./BaseApi.Tests/BaseApi.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out BaseApi.Tests/BaseApi.Tests.csproj

CMD dotnet test
