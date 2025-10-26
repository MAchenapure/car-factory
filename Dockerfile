FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/CarFactory.Sales.Api/CarFactory.Sales.Api.csproj", "src/CarFactory.Sales.Api/"]
COPY ["src/CarFactory.Sales.Application/CarFactory.Sales.Application.csproj", "src/CarFactory.Sales.Application/"]
COPY ["src/CarFactory.Sales.Domain/CarFactory.Sales.Domain.csproj", "src/CarFactory.Sales.Domain/"]
COPY ["src/CarFactory.Sales.Infrastructure/CarFactory.Sales.Infrastructure.csproj", "src/CarFactory.Sales.Infrastructure/"]
RUN dotnet restore "src/CarFactory.Sales.Api/CarFactory.Sales.Api.csproj"

COPY . .
WORKDIR "/src/src/CarFactory.Sales.Api"
RUN dotnet publish "CarFactory.Sales.Api.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8080

ENTRYPOINT ["dotnet", "CarFactory.Sales.Api.dll"]