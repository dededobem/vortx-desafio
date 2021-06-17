FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Vortx.Api/Vortx.Api.csproj", "Vortx.Api/"]
RUN dotnet restore "Vortx.Api/Vortx.Api.csproj"
COPY . .
WORKDIR "/src/Vortx.Api"
RUN dotnet build "Vortx.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vortx.Api.csproj" -c Release -o /app/publish
COPY ["Vortx.Api/DB_VORTX.db", "/app/publish"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vortx.Api.dll"]
