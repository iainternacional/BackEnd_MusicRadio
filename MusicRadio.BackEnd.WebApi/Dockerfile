# Imagen base para build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiamos los archivos de la solución
COPY . ./

# Restauramos paquetes NuGet
RUN dotnet restore MusicRadio.BackEnd.WebApi/MusicRadio.BackEnd.WebApi.csproj

# Publicamos en modo release
RUN dotnet publish MusicRadio.BackEnd.WebApi/MusicRadio.BackEnd.WebApi.csproj -c Release -o /out

# Imagen base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copiamos la app publicada desde la etapa anterior
COPY --from=build /out .

# Configurar variable de entorno si deseas
ENV ASPNETCORE_URLS=http://+:8080

# Expone el puerto que se usará en el contenedor
EXPOSE 8080

# Comando para correr la aplicación
ENTRYPOINT ["dotnet", "MusicRadio.BackEnd.WebApi.dll"]