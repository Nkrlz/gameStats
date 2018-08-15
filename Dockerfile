FROM microsoft/dotnet:2.1.400-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
#Build database
#Build project
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1.400-sdk
WORKDIR /app
COPY --from=build-env /app/rawStats.db .
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "gamestats.dll"]