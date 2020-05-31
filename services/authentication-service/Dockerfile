FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

ARG AUTH_DB_CONNECTION_STRING
ARG IDENTITY_ISSUER
ARG IDENTITY_ORIGIN

ENV ConnectionStrings__AuthDb=$AUTH_DB_CONNECTION_STRING
ENV Identity__Issuer=$IDENTITY_ISSUER
ENV Identity__Origin=$IDENTITY_ORIGIN

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore cov19.services.auth/cov19.services.auth.csproj

# Copy everything else and build
RUN dotnet publish cov19.services.auth/cov19.services.auth.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "cov19.services.auth.dll"]