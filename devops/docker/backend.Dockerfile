
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["backend/WarSafe.API/WarSafe.API.csproj", "WarSafe.API/"]
COPY ["backend/WarSafe.Application/WarSafe.Application.csproj", "WarSafe.Application/"]
COPY ["backend/WarSafe.Domain/WarSafe.Domain.csproj", "WarSafe.Domain/"]
COPY ["backend/WarSafe.Infrastructure/WarSafe.Infrastructure.csproj", "WarSafe.Infrastructure/"]

RUN dotnet restore "WarSafe.API/WarSafe.API.csproj"

COPY backend/. .
WORKDIR "/src/WarSafe.API"

RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WarSafe.API.dll"]
