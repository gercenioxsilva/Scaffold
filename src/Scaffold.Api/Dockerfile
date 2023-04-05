#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Scaffold.Api/Scaffold.Api.csproj", "src/Scaffold.Api/"]
COPY ["src/Scaffold.Application/Scaffold.Application.csproj", "src/Scaffold.Application/"]
COPY ["src/Scaffold.Domain/Scaffold.Domain.csproj", "src/Scaffold.Domain/"]
COPY ["src/Scaffold.CrossCutting/Scaffold.CrossCutting.csproj", "src/Scaffold.CrossCutting/"]
COPY ["src/Scaffold.Infrastructure/Scaffold.Infrastructure.csproj", "src/Scaffold.Infrastructure/"]
RUN dotnet restore "src/Scaffold.Api/Scaffold.Api.csproj"
COPY . .
WORKDIR "/src/src/Scaffold.Api"
RUN dotnet build "Scaffold.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scaffold.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scaffold.Api.dll"]