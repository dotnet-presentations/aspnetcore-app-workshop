FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FrontEnd/FrontEnd.csproj", "FrontEnd/"]
COPY ["ConferenceDTO/ConferenceDTO.csproj", "ConferenceDTO/"]
RUN dotnet restore "FrontEnd/FrontEnd.csproj"
COPY . .
WORKDIR "/src/FrontEnd"
RUN dotnet build "FrontEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrontEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrontEnd.dll"]