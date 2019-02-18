
FROM microsoft/dotnet:2.2-sdk

ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/path/to/newrelic-netcore20-agent \
CORECLR_PROFILER_PATH=/path/to/newrelic-netcore20-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=eu01xx677709909843dec1699a6e95f0409cea4d \
NEW_RELIC_APP_NAME=transactions-api

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

EXPOSE ${PORT:-3000}

CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./out/transactions-api.dll
