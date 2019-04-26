FROM microsoft/dotnet:2.1.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1.301-sdk AS build
WORKDIR /src
#COPY ConferencePlanner.sln ./
COPY BackEnd/BackEnd.csproj BackEnd/
COPY ConferenceDTO/ConferenceDTO.csproj ConferenceDTO/
RUN dotnet restore BackEnd/BackEnd.csproj -nowarn:msb3202,nu1503
RUN dotnet restore ConferenceDTO/ConferenceDTO.csproj -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/BackEnd
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BackEnd.dll"]
