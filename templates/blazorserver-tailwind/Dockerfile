FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5097

ENV ASPNETCORE_URLS=http://+:5097

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["BlazorTailwindTemplate.csproj", "./"]
RUN dotnet restore "BlazorTailwindTemplate.csproj"
COPY . .
WORKDIR "/src/."
RUN npm install
RUN dotnet build "BlazorTailwindTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTailwindTemplate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorTailwindTemplate.dll"]
