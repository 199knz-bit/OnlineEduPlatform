#изграждане
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["OnlineEduPlatform.csproj", "./"]
RUN dotnet restore "OnlineEduPlatform.csproj"
COPY . .
RUN dotnet publish "OnlineEduPlatform.csproj" -c Release -o /app/publish

#изпълнение
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
RUN mkdir /app/data
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "OnlineEduPlatform.dll"]