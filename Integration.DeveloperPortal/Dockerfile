FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Integration.DeveloperPortal/Integration.DeveloperPortal.csproj", "Integration.DeveloperPortal/"]
COPY ["Integration.DeveloperPortal.Authentication/Integration.DeveloperPortal.Authentication.csproj", "Integration.DeveloperPortal.Authentication/"]
COPY ["Integration.DeveloperPortal.DependencyResolution/Integration.DeveloperPortal.DependencyResolution.csproj", "Integration.DeveloperPortal.DependencyResolution/"]
COPY ["Integration.DeveloperPortal.Repository/Integration.DeveloperPortal.Repository.csproj", "Integration.DeveloperPortal.Repository/"]
COPY ["Integration.DeveloperPortal.Model/Integration.DeveloperPortal.Model.csproj", "Integration.DeveloperPortal.Model/"]
COPY ["Integration.DeveloperPortal.Logic/Integration.DeveloperPortal.Logic.csproj", "Integration.DeveloperPortal.Logic/"]
RUN dotnet restore "Integration.DeveloperPortal/Integration.DeveloperPortal.csproj"
COPY . .
WORKDIR "/src/Integration.DeveloperPortal"
RUN dotnet build "Integration.DeveloperPortal.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Integration.DeveloperPortal.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Integration.DeveloperPortal.dll"]