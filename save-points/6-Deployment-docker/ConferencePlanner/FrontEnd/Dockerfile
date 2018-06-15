FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1.300-sdk AS build
WORKDIR /src
#COPY ConferencePlanner.sln ./
COPY FrontEnd/FrontEnd.csproj FrontEnd/
COPY ConferenceDTO/ConferenceDTO.csproj ConferenceDTO/
RUN dotnet restore FrontEnd/FrontEnd.csproj -nowarn:msb3202,nu1503
RUN dotnet restore ConferenceDTO/ConferenceDTO.csproj -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/FrontEnd
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FrontEnd.dll"]
