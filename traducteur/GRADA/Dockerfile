# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY GRADA.csproj ./
RUN dotnet restore

# Copy the remaining files and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# Expose port (change if your app uses a different one)
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "GRADA.dll"]
