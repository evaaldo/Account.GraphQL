FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/Account.GraphQL.Api/Account.GraphQL.Api.csproj src/Account.GraphQL.Api/
COPY src/Account.GraphQL.Application/Account.GraphQL.Application.csproj src/Account.GraphQL.Application/
COPY src/Account.GraphQL.Domain/Account.GraphQL.Domain.csproj src/Account.GraphQL.Domain/
COPY src/Account.GraphQL.Infrastructure/Account.GraphQL.Infrastructure.csproj src/Account.GraphQL.Infrastructure/
RUN dotnet restore src/Account.GraphQL.Api/Account.GraphQL.Api.csproj

COPY src/ src/
RUN dotnet publish src/Account.GraphQL.Api/Account.GraphQL.Api.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Account.GraphQL.Api.dll"]
