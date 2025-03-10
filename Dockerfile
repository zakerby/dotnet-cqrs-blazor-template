# Starting from MS's dotnet image that has all the SDKs installed,
# build and unit test the app
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

COPY . /
WORKDIR /
RUN dotnet restore Core.Backend.sln

# Build
RUN dotnet build --configuration Release --no-restore Core.Backend.sln

# Create dotnet artifacts
RUN dotnet publish --no-restore -c Release --output /app Core.Backend.sln

# Build the deployment container. Switch base images from 'sdk' to
# 'runtime', and use Apline Linux, to reduce image size
FROM mcr.microsoft.com/dotnet/runtime:9.0-alpine AS runtime

# Set up the app to run
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Core.Backend.Api.dll"]
