#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Twitter.GraphQL.API/Twitter.GraphQL.API.csproj", "Twitter.GraphQL.API/"]
COPY ["Twitter.MongoDB.Core/Twitter.MongoDB.Core.csproj", "Twitter.MongoDB.Core/"]
COPY ["Twitter.MongoDB.Infra/Twitter.MongoDB.Infra.csproj", "Twitter.MongoDB.Infra/"]
RUN dotnet restore "Twitter.GraphQL.API/Twitter.GraphQL.API.csproj"
COPY . .
WORKDIR "/src/Twitter.GraphQL.API"
RUN dotnet build "Twitter.GraphQL.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Twitter.GraphQL.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Twitter.GraphQL.API.dll"]
