#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Api/AlkinanaPharmaManagment.Api/AlkinanaPharmaManagment.Api.csproj", "src/Api/AlkinanaPharmaManagment.Api/"]
COPY ["src/Infrastructure/AlkinanaPharmaManagment.Infrastructure/AlkinanaPharmaManagment.Infrastructure.csproj", "src/Infrastructure/AlkinanaPharmaManagment.Infrastructure/"]
COPY ["src/Infrastructure/AlkinanaPharma.Identity/AlkinanaPharma.Identity.csproj", "src/Infrastructure/AlkinanaPharma.Identity/"]
COPY ["src/Core/AlkinanaPharmaManagment.Application/AlkinanPharmaManagment.Application.crproj", "src/Core/AlkinanaPharmaManagment.Application/"]
COPY ["src/Core/AlkinanaPharmaManagment.Domian/AlkinanPharmaManagment.Domain.crproj", "src/Core/AlkinanaPharmaManagment.Domain/"]
COPY ["src/Shared/AlkinanaPharmaManagment.Shared.Abstraction/AlkinanPharmaManagment.Shared.Abstraction.crproj", "src/Shared/AlkinanaPharmaManagment.Shared.Abstraction/"]
RUN dotnet restore "./AlkinanaPharmaManagment.Api/AlkinanaPharmaManagment.Api.csproj"
COPY . .
WORKDIR "/src/AlkinanaPharmaManagment.Api"
RUN dotnet build "./AlkinanaPharmaManagment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AlkinanaPharmaManagment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlkinanaPharmaManagment.Api.dll"]