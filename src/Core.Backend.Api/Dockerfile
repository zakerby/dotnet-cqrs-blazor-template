FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /source

COPY Core.Backend.Api.csproj ./aspnetapp/
WORKDIR /source/aspnetapp
RUN dotnet restore

COPY . ./aspnetapp/
RUN dotnet publish -c Release -o /app --no-restore

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Core.Backend.Api.dll"]

