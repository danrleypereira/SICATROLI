# Use the official .NET Core runtime image as a base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory in the container to /app
WORKDIR /app

# Copy the project file to the container and restore the dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code to the container
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Start with a new image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Set the working directory in the container to /app
WORKDIR /app

# Copy the application files to the container
COPY --from=build-env /app/out .


# Expose the port used by the application
EXPOSE 5000

# Start the application when the container starts
ENTRYPOINT ["dotnet", "backend.dll"]
