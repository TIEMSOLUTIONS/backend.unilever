FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Sistema.Web/Sistema.Web.csproj", "Sistema.Web/"]
COPY ["Sistema.Entidades/Sistema.Entidades.csproj", "Sistema.Entidades/"]
COPY ["Sistema.Datos/Sistema.Datos.csproj", "Sistema.Datos/"]
RUN dotnet restore "Sistema.Web/Sistema.Web.csproj"
COPY . .
WORKDIR "/src/Sistema.Web"
RUN dotnet build "Sistema.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sistema.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sistema.Web.dll"]