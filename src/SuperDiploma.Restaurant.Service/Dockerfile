# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SuperDiploma.Restaurant.Service/SuperDiploma.Restaurant.Service.csproj", "src/SuperDiploma.Restaurant.Service/"]
COPY ["src/SuperDiploma.Restaurant.Api/SuperDiploma.Restaurant.Api.csproj", "src/SuperDiploma.Restaurant.Api/"]
COPY ["src/SuperDiploma.Restaurant.DomainService.Contracts/SuperDiploma.Restaurant.DomainService.Contracts.csproj", "src/SuperDiploma.Restaurant.DomainService.Contracts/"]
COPY ["src/SuperDiploma.Restaurant.DataContext.Models/SuperDiploma.Restaurant.DataContext.Entities.csproj", "src/SuperDiploma.Restaurant.DataContext.Models/"]
COPY ["src/SuperDiploma.Core/SuperDiploma.Core.csproj", "src/SuperDiploma.Core/"]
COPY ["src/SuperDiploma.Restaurant.DomainService.Dto/SuperDiploma.Restaurant.DomainService.Dto.csproj", "src/SuperDiploma.Restaurant.DomainService.Dto/"]
COPY ["src/SuperDiploma.Restaurant.DomainService.Enums/SuperDiploma.Restaurant.DomainService.Enums.csproj", "src/SuperDiploma.Restaurant.DomainService.Enums/"]
COPY ["src/SuperDiploma.Restaurant.DomainService.Dto.Mappings/SuperDiploma.Restaurant.DomainService.Dto.Mappings.csproj", "src/SuperDiploma.Restaurant.DomainService.Dto.Mappings/"]
COPY ["src/SuperDiploma.Restaurant.DataContext.EF/SuperDiploma.Restaurant.DataContext.EF.csproj", "src/SuperDiploma.Restaurant.DataContext.EF/"]
COPY ["src/SuperDiploma.Restaurant.DomainService/SuperDiploma.Restaurant.DomainService.csproj", "src/SuperDiploma.Restaurant.DomainService/"]
COPY ["src/SuperDiploma.Restaurant.DomainService.Validators/SuperDiploma.Restaurant.DomainService.Validators.csproj", "src/SuperDiploma.Restaurant.DomainService.Validators/"]
RUN dotnet restore "./src/SuperDiploma.Restaurant.Service/SuperDiploma.Restaurant.Service.csproj"
COPY . .
WORKDIR "/src/src/SuperDiploma.Restaurant.Service"
RUN dotnet build "./SuperDiploma.Restaurant.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SuperDiploma.Restaurant.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuperDiploma.Restaurant.Service.dll"]