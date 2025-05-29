# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY traducteur/GRADA/GRADA.csproj traducteur/GRADA/
WORKDIR /src/traducteur/GRADA
RUN dotnet restore

# Copy the remaining source files
COPY traducteur/GRADA/. ./

# Publish the app to the /app/publish directory
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Create final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "GRADA.dll"]
