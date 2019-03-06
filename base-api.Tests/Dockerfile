FROM microsoft/dotnet:2.2-sdk

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./base-api.sln ./
COPY ./base-api/base-api.csproj ./base-api/
COPY ./base-api.Tests/base-api.Tests.csproj ./base-api.Tests/

RUN dotnet restore ./base-api/base-api.csproj
RUN dotnet restore ./base-api.Tests/base-api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out base-api.Tests/base-api.Tests.csproj

CMD dotnet test
