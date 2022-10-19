#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MovieAppCoreApi/MovieAppCoreApi.csproj", "MovieAppCoreApi/"]
COPY ["MovieAppCore.DAL/MovieAppCore.DAL.csproj", "MovieAppCore.DAL/"]
COPY ["MovieAppCore.Entity/MovieAppCore.Entity.csproj", "MovieAppCore.Entity/"]
COPY ["MovieAppCore.BAL/MovieAppCore.BAL.csproj", "MovieAppCore.BAL/"]
RUN dotnet restore "MovieAppCoreApi/MovieAppCoreApi.csproj"
COPY . .
WORKDIR "/src/MovieAppCoreApi"
RUN dotnet build "MovieAppCoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieAppCoreApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieAppCoreApi.dll"]