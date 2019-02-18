FROM microsoft/dotnet:2.2-sdk

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./transactions-api.sln ./
COPY ./transactions-api/transactions-api.csproj ./transactions-api/
COPY ./transactions-api.Tests/transactions-api.Tests.csproj ./transactions-api.Tests/

RUN dotnet restore ./transactions-api/transactions-api.csproj
RUN dotnet restore ./transactions-api.Tests/transactions-api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out transactions-api.Tests/transactions-api.Tests.csproj

CMD dotnet test
