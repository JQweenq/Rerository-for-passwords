﻿FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PG.csproj", "./"]
RUN dotnet restore "PG.csproj"
COPY . .
WORKDIR "/src/PG"
RUN dotnet build "PG.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PG.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PG.dll"]
