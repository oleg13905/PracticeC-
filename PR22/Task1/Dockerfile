## Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy csproj first for better layer caching
COPY ["Task1.csproj", "./"]
RUN dotnet restore "./Task1.csproj"

# copy the rest and publish
COPY . .
RUN dotnet publish "./Task1.csproj" -c Release -o /app/publish --no-restore

## Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Render provides $PORT; default to 8080 for local runs
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}
EXPOSE 8080

COPY --from=build /app/publish ./

# Optionally keep app data under /app/data (Render disk can be mounted here)
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Task1.dll"]
