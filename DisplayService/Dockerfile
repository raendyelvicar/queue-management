FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DisplayService/DisplayService.csproj", "DisplayService/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "DisplayService/DisplayService.csproj"
COPY . .
WORKDIR "/src/DisplayService"
RUN dotnet build "DisplayService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DisplayService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DisplayService.dll"]
