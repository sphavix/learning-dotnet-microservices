FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 9000

USER app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["microservices/Catalog/Catalog.API/Catalog.API.csproj", "microservices/Catalog/Catalog.API/"]
COPY ["microservices/Catalog/Catalog.Application/Catalog.Application.csproj", "microservices/Catalog/Catalog.Application/"]
COPY ["microservices/Catalog/Catalog.Core/Catalog.Core.csproj", "microservices/Catalog/Catalog.Core/"]
COPY ["microservices/Catalog/Catalog.Infrastructure/Catalog.Infrastructure.csproj", "microservices/Catalog/Catalog.Infrastructure/"]

RUN dotnet restore "microservices/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/microservices/Catalog/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]
