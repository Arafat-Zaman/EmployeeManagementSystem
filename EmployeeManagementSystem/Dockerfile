# Use the ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EmployeeManagementSystem.csproj", "./"]
RUN dotnet restore "EmployeeManagementSystem.csproj"
COPY . .
RUN dotnet build "EmployeeManagementSystem.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "EmployeeManagementSystem.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagementSystem.dll"]
