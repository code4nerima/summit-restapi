#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["summit-restapi/summit-restapi.csproj", "summit-restapi/"]
RUN dotnet restore "summit-restapi/summit-restapi.csproj"
COPY . .
WORKDIR "/src/summit-restapi"
RUN dotnet build "summit-restapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "summit-restapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "summit-restapi.dll"]