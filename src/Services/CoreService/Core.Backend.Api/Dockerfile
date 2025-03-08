FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files first
COPY ["src/Core.Backend.Api/*.csproj", "Core.Backend.Api/"]
COPY ["src/Core.Backend.Application/*.csproj", "Core.Backend.Application/"]
COPY ["src/Core.Backend.Domain/*.csproj", "Core.Backend.Domain/"]
COPY ["src/Core.Backend.Infrastructure/*.csproj", "Core.Backend.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "Core.Backend.Api/Core.Backend.Api.csproj"

# Copy everything else
COPY ["src/Core.Backend.Api/", "Core.Backend.Api/"]
COPY ["src/Core.Backend.Application/", "Core.Backend.Application/"]
COPY ["src/Core.Backend.Domain/", "Core.Backend.Domain/"]
COPY ["src/Core.Backend.Infrastructure/", "Core.Backend.Infrastructure/"]

# Build the application
WORKDIR "/src/Core.Backend.Api"
RUN dotnet build "Core.Backend.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Core.Backend.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core.Backend.Api.dll"]

