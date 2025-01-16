# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project files
COPY *.sln .
COPY ./PopMulti ./PopMulti

# Restore dependencies
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose the port your app listens on
EXPOSE 8080

# Command to run the app
ENTRYPOINT ["dotnet", "PopMulti.dll"]
