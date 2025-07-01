FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

ARG ST__NuGetKey=""
ENV ST__NuGetKey=${ST__NuGetKey}

WORKDIR /source

COPY . .

RUN dotnet publish ./src/ContactCenter.Interactions.Service/ContactCenter.Interactions.Service.csproj -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "ServiceTitan.ContactCenter.Interactions.Service.dll"]
