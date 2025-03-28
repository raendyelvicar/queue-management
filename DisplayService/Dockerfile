# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solusi utama dan semua project file
COPY QueueManagement.sln ./
COPY Shared/*.csproj ./Shared/
COPY LoketService/*.csproj ./LoketService/
COPY KioskService/*.csproj ./KioskService/
COPY DisplayService/*.csproj ./DisplayService/

# Restore dependencies
RUN dotnet restore QueueManagement.sln

# Copy seluruh source code
COPY . .

EXPOSE 5054

# Build DisplayService
WORKDIR /app/DisplayService
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "DisplayService.dll"]
