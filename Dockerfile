FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
COPY ["*.sln", "./"]
COPY ["Integration.DeveloperPortal/Integration.DeveloperPortal.csproj", "./Integration.DeveloperPortal/"]
COPY ["Integration.DeveloperPortal.Authentication/Integration.DeveloperPortal.Authentication.csproj", "./Integration.DeveloperPortal.Authentication/"]
COPY ["Integration.DeveloperPortal.DependencyResolution/Integration.DeveloperPortal.DependencyResolution.csproj", "./Integration.DeveloperPortal.DependencyResolution/"]
COPY ["Integration.DeveloperPortal.Repository/Integration.DeveloperPortal.Repository.csproj", "./Integration.DeveloperPortal.Repository/"]
COPY ["Integration.DeveloperPortal.Model/Integration.DeveloperPortal.Model.csproj", "./Integration.DeveloperPortal.Model/"]
COPY ["Integration.DeveloperPortal.Logic/Integration.DeveloperPortal.Logic.csproj", "./Integration.DeveloperPortal.Logic/"]
RUN dotnet restore "Integration.DeveloperPortal.sln"

COPY . .

FROM build AS publish
RUN dotnet publish -c Release -o /app -r linux-x64 -f netcoreapp2.2

FROM microsoft/dotnet:2.2-runtime AS final
WORKDIR /app
COPY --from=publish /app .

ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "Integration.DeveloperPortal.dll"]