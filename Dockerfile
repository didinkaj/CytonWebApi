FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CytonInterview.csproj ./
RUN dotnet restore /CytonInterview.csproj
COPY . .
WORKDIR /src/
RUN dotnet build CytonInterview.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CytonInterview.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CytonInterview.dll"]
