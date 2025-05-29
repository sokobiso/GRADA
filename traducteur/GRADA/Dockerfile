# Use official .NET SDK as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


# Install AWS CLI inside the container
# Copy project files to maintain dependencies
COPY ["traducteur/GRADA/GRADA.csproj", "/traducteur/GRADA"]


#
# Restore dependencies
WORKDIR /src
RUN dotnet restore "GRADA.csproj"




# Build and publish the application
WORKDIR /src/GRADA
RUN dotnet publish "GRADA.csproj" -c "${BUILD_CONFIGURATION}" -o /app/publish /p:UseAppHost=false


# Create final runtime image inside container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Create non-root user
RUN adduser --disabled-password --gecos "" appuser
USER appuser

# Copy application
COPY --from=build /app/publish .

# Expose necessary ports
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "GRADA.dll"]