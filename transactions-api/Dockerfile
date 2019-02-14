<<<<<<< HEAD
FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
EXPOSE ${PORT:-80}
=======
FROM microsoft/dotnet:2.2-sdk
WORKDIR /app
>>>>>>> bf90caed67b0c1344a0b59e849eacdd38678f785

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

<<<<<<< HEAD
# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app    
COPY --from=build-env /app/out .
EXPOSE ${PORT:-80}
CMD ASPNETCORE_URLS=http://+:${PORT:-80} dotnet transactions-api.dll
=======
EXPOSE ${PORT:-3000}

CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./out/transactions-api.dll
>>>>>>> bf90caed67b0c1344a0b59e849eacdd38678f785
