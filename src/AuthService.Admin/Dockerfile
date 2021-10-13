FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/AuthService.Admin/AuthService.Admin.csproj", "src/AuthService.Admin/"]
COPY ["src/AuthService.Admin.EntityFramework.Shared/AuthService.Admin.EntityFramework.Shared.csproj", "src/AuthService.Admin.EntityFramework.Shared/"]
COPY ["src/AuthService.Admin.EntityFramework.SqlServer/AuthService.Admin.EntityFramework.SqlServer.csproj", "src/AuthService.Admin.EntityFramework.SqlServer/"]
COPY ["src/AuthService.Admin.EntityFramework.PostgreSQL/AuthService.Admin.EntityFramework.PostgreSQL.csproj", "src/AuthService.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/AuthService.Shared/AuthService.Shared.csproj", "src/AuthService.Shared/"]
COPY ["src/AuthService.Admin.EntityFramework.MySql/AuthService.Admin.EntityFramework.MySql.csproj", "src/AuthService.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/AuthService.Admin/AuthService.Admin.csproj"
COPY . .
WORKDIR "/src/src/AuthService.Admin"
RUN dotnet build "AuthService.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthService.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "AuthService.Admin.dll"]