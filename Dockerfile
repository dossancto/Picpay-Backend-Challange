FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

COPY . ./

RUN dotnet publish -c Release -o /out ./Picpay.UI/Picpay.UI.csproj

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "Picpay.UI.dll"]
