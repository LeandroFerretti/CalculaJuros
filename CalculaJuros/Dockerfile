#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CalculaJuros/CalculaJuros.csproj", "CalculaJuros/"]
COPY ["Aplicacao/Aplicacao.csproj", "Aplicacao/"]
COPY ["ConexoesApi/ConexoesApi.csproj", "ConexoesApi/"]
RUN dotnet restore "CalculaJuros/CalculaJuros.csproj"
COPY . .
WORKDIR "/src/CalculaJuros"
RUN dotnet build "CalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculaJuros.dll"]
