FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Assigment_Book/Assigment_Book.csproj", "Assigment_Book/"]
RUN dotnet restore "Assigment_Book/Assigment_Book.csproj"
COPY . .
WORKDIR "/src/Assigment_Book"
RUN dotnet build "Assigment_Book.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assigment_Book.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Assigment_Book.dll"]
