FROM microsoft/dotnet:2.2-sdk as builder

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use a smaller image
FROM microsoft/dotnet:2.2.0-aspnetcore-runtime-alpine

# Set env variables required for new relic
ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=./out/newrelic \
CORECLR_PROFILER_PATH=./out/newrelic/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY="${NEW_RELIC_LICENSE_KEY}" \
NEW_RELIC_APP_NAME="${NEW_RELIC_APP_NAME}"

# Copy over the compiled application from the build image
WORKDIR /app
COPY --from=builder /app/out .

EXPOSE ${PORT:-3000}
CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./base-api.dll
