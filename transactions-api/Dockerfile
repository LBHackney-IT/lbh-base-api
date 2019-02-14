FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
EXPOSE ${PORT:-80}

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app    
COPY --from=build-env /app/out .
EXPOSE ${PORT:-80}
CMD ASPNETCORE_URLS=http://+:${PORT:-80} dotnet transactions-api.dll