# ASP.NET Core - App Building Workshop

[![Build Status](https://dev.azure.com/dotnet/AspNetCoreWorkshop/_apis/build/status/ASP.NET%20Workshop-ASP.NET%20Core%203.x?branchName=master)](https://dev.azure.com/dotnet/AspNetCoreWorkshop/_build/latest?definitionId=71&branchName=master)

[BackEnd Web API](https://aspnetcorews-backend.azurewebsites.net) | [FrontEnd Web App](https://aspnetcorews-frontend.azurewebsites.net)

## Setup

[Download](https://www.microsoft.com/net/download) and install the .NET Core SDK and Visual Studio.

> Note: When installing Visual Studio you only need to install the `ASP.NET and web development` workload.

If you have issues downloading the installers we may have USB sticks with offline installers for you to use.

## What you'll be building
In this workshop, you'll learn by building a full-featured ASP.NET Core application from scratch. We'll start from File/ New and build up to an API back-end application, a web front-end application, and a common library for shared data transfer objects using .NET Standard.

### Application Architecture
![Architecture Diagram](/docs/images/ConferencePlannerArchitectureDiagram.svg)

### Database Schema
![Database Schema Diagram](/docs/conference-planner-db-diagram.png)

## Sessions

| Session | Topics |
| ----- | ---- |
| [Session #1](/docs/1.%20Create%20BackEnd%20API%20project.md) | Build the back-end API with basic EF model |
| [Session #2](/docs/2.%20Build%20out%20BackEnd%20and%20Refactor.md) | Finish the back-end API and EF model, refactor into view models |  |
| [Session #3](/docs/3.%20Add%20front-end%2C%20render%20agenda%2C%20set%20up%20front-end%20models.md) | Add front-end, render agenda, set up front-end models |
| [Session #4](/docs/4.%20Add%20auth%20features.md) | Add authentication, add admin policy, allow editing sessions, users can sign-in with Identity, custom auth tag helper |
| [Session #5](/docs/5.%20Add%20personal%20agenda.md) | Add user association and personal agenda |
| [Session #6](docs/6.%20Production%20Readiness%20and%20Deployment.md) | Deployment, Azure and other production environments, configuring environments, diagnostics |
| [Session #7](/docs/7.%20Challenges.md) | Challenges |
| [Session #8](/docs/8.%20SPA%20FrontEnd.md) | SPA front-end |
