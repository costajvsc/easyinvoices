FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /src
COPY ["api/api.csproj", "api/"]
RUN dotnet restore "api/api.csproj"
COPY . .

WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c Release -o /app
RUN dotnet publish "api.csproj" -c Release -o /app

EXPOSE 80
EXPOSE 443

WORKDIR /app
ENTRYPOINT ["dotnet", "api.dll"]