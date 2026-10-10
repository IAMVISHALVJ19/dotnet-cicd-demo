FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/WebApp/WebApp.csproj src/WebApp/
RUN dotnet restore src/WebApp/WebApp.csproj
COPY src/ src/
RUN dotnet publish src/WebApp/WebApp.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER app
ENTRYPOINT ["dotnet", "WebApp.dll"]
