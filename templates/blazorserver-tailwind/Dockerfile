FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5257
ENV ASPNETCORE_URLS=http://+:5257

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["src/BlazorServerTailwindTemplate/BlazorServerTailwindTemplate.csproj", "src/BlazorServerTailwindTemplate/"]
RUN dotnet restore "src/BlazorServerTailwindTemplate/BlazorServerTailwindTemplate.csproj" \
&& npm install
COPY . .
WORKDIR "/src/src/BlazorServerTailwindTemplate"
RUN dotnet build "BlazorServerTailwindTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorServerTailwindTemplate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorServerTailwindTemplate.dll"]
