#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
# RUN apk add --no-cache icu-libs
# RUN apk add --no-cache fontconfig
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore Examich_PDF_Service/Examich_PDF_Service.csproj
RUN dotnet build Examich_PDF_Service/Examich_PDF_Service.csproj -c Production -o /app/build

FROM build AS publish
RUN dotnet publish Examich_PDF_Service/Examich_PDF_Service.csproj -c Production -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Examich_PDF_Service.dll"]
