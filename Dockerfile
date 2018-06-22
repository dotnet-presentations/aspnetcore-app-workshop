FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Build main branch source apps
FROM microsoft/dotnet:2.1-sdk AS build-src
COPY ConferencePlanner.sln ./
COPY src src
RUN dotnet restore -nowarn:msb3202,nu1503 --packages /nuget

WORKDIR /src/BackEnd
RUN dotnet build -c Release -o /app/backend

WORKDIR /src/FrontEnd
RUN dotnet build -c Release -o app/frontend

#Build save-points
#1-Create-API-and-EF-Model
FROM microsoft/dotnet:2.1-sdk AS build-save-1
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/1-Create-API-and-EF-Model/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY $DIR/BackEnd/BackEnd.csproj BackEnd/
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
COPY ${DIR} ./
RUN dotnet build -c Release -o /app

#2a-Refactor-to-ConferenceDTO
FROM microsoft/dotnet:2.1-sdk AS build-save-2a
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/2a-Refactor-to-ConferenceDTO/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY $DIR/BackEnd/BackEnd.csproj BackEnd/
COPY $DIR/ConferenceDTO/ConferenceDTO.csproj ConferenceDTO/

RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
COPY ${DIR} ./
RUN dotnet build -c Release -o /app

#2b-BackEnd-completed
FROM microsoft/dotnet:2.1-sdk AS build-save-2b
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/2b-BackEnd-completed/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY $DIR/BackEnd/BackEnd.csproj BackEnd/
COPY $DIR/ConferenceDTO/ConferenceDTO.csproj ConferenceDTO/

RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
COPY ${DIR} ./
RUN dotnet build -c Release -o /app

#3-Front-End-started
FROM microsoft/dotnet:2.1-sdk AS build-save-3
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/3-Front-End-started/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY ${DIR} ./
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget

WORKDIR /BackEnd
RUN dotnet build -c Release -o /app/backend

WORKDIR /FrontEnd
RUN dotnet build -c Release -o app/frontend

#4-Authentication-and-Tag-Helpers
FROM microsoft/dotnet:2.1-sdk AS build-save-4
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/4-Authentication-and-Tag-Helpers/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY ${DIR} ./
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget

WORKDIR /BackEnd
RUN dotnet build -c Release -o /app/backend

WORKDIR /FrontEnd
RUN dotnet build -c Release -o app/frontend

#5-User-association-and-personal-agenda
FROM microsoft/dotnet:2.1-sdk AS build-save-5
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/5-User-association-and-personal-agenda/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY ${DIR} ./
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget

WORKDIR /BackEnd
RUN dotnet build -c Release -o /app/backend

WORKDIR /FrontEnd
RUN dotnet build -c Release -o app/frontend

#6-Deployment-docker
FROM microsoft/dotnet:2.1-sdk AS build-save-6
COPY --from=build-src /nuget /nuget
ARG DIR=save-points/6-Deployment-docker/ConferencePlanner/
COPY $DIR/ConferencePlanner.sln ./
COPY ${DIR} ./

WORKDIR /BackEnd
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
RUN dotnet build -c Release -o /app/backend

WORKDIR /FrontEnd
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
RUN dotnet build -c Release -o app/frontend

#8a-Adding-FrontEnd-Spa-final
FROM microsoft/dotnet:2.1-sdk AS build-save-8a-final

ENV NODE_VERSION 8.11.2
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz
ENV NODE_DOWNLOAD_SHA 67dc4c06a58d4b23c5378325ad7e0a2ec482b48cea802252b99ebe8538a3ab79

RUN curl -SL "$NODE_DOWNLOAD_URL" --output nodejs.tar.gz \
  && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
  && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
  && rm nodejs.tar.gz \
  && ln -s /usr/local/bin/node /usr/local/bin/nodejs

COPY --from=build-src /nuget /nuget
ARG DIR=save-points/8a-Adding-FrontEnd-Spa-final/ConferencePlanner
COPY $DIR/ConferencePlanner.sln ./
COPY ${DIR}/src ./src

WORKDIR /src/BackEnd
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
RUN dotnet build -c Release -o /app/backend

WORKDIR /src/FrontEndSpa
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
WORKDIR /src/FrontEndSpa/ClientApp
RUN npm install
RUN npm run build
WORKDIR /src/FrontEndSpa
RUN dotnet build -c Release -o app/frontend

#8a-Adding-FrontEnd-Spa-started
FROM microsoft/dotnet:2.1-sdk AS build-save-8a-start

COPY --from=build-src /nuget /nuget
ARG DIR=save-points/8a-Adding-FrontEnd-Spa-started/ConferencePlanner
COPY $DIR/ConferencePlanner.sln ./
COPY ${DIR}/src ./src

WORKDIR /src/BackEnd
RUN dotnet restore -nowarn:msb3202,nu1503 -s /nuget
RUN dotnet build -c Release -o /app/backend

#produce final images
FROM build-src AS publish-backend
RUN dotnet publish -c Release -o /app

FROM build-src AS publish-frontend
RUN dotnet publish -c Release -o /app

# Produce this image using
# docker build --target final-backend -t aspnet-app-workshop-backend:latest .
FROM base AS final-backend
WORKDIR /app
COPY --from=publish-backend /app .
ENTRYPOINT ["dotnet", "BackEnd.dll"]

# Produce this image using
# docker build --target final-backend -t aspnet-app-workshop-frontend:latest .
FROM base AS final-frontend
WORKDIR /app
COPY --from=publish-frontend /app .
ENTRYPOINT ["dotnet", "FrontEnd.dll"]
