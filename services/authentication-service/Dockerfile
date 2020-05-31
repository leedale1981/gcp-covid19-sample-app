FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

ARG ConnectionStrings__AuthDb
ARG Identity__Issuer
ARG Identity__Origin

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore cov19.services.auth/cov19.services.auth.csproj

# Copy everything else and build
RUN dotnet publish cov19.services.auth/cov19.services.auth.csproj -c Release -o out

ENV ConnectionStrings__AuthDb=$ConnectionStrings__AuthDb
ENV Identity__Issuer=$Identity__Issuer
ENV Identity__Origin=$Identity__Origin

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "cov19.services.auth.dll"]