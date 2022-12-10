FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RopeBridge-AdventOfCodeDay9.csproj", "./"]
RUN dotnet restore "RopeBridge-AdventOfCodeDay9.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RopeBridge-AdventOfCodeDay9.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RopeBridge-AdventOfCodeDay9.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RopeBridge-AdventOfCodeDay9.dll"]
