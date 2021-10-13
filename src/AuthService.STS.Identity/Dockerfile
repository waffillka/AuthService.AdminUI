FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/AuthService.STS.Identity/AuthService.STS.Identity.csproj", "src/AuthService.STS.Identity/"]
COPY ["src/AuthService.Admin.EntityFramework.Shared/AuthService.Admin.EntityFramework.Shared.csproj", "src/AuthService.Admin.EntityFramework.Shared/"]
COPY ["src/AuthService.Shared/AuthService.Shared.csproj", "src/AuthService.Shared/"]
RUN dotnet restore "src/AuthService.STS.Identity/AuthService.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/AuthService.STS.Identity"
RUN dotnet build "AuthService.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthService.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "AuthService.STS.Identity.dll"]