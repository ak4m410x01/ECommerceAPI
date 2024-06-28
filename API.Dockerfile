# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the official SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj and restore dependencies
COPY ["ECommerceAPI.Presentation/ECommerceAPI.Presentation.csproj", "ECommerceAPI.Presentation/"]
COPY ["ECommerceAPI.Application/ECommerceAPI.Application.csproj", "ECommerceAPI.Application/"]
COPY ["ECommerceAPI.Domain/ECommerceAPI.Domain.csproj", "ECommerceAPI.Domain/"]
COPY ["ECommerceAPI.Shared/ECommerceAPI.Shared.csproj", "ECommerceAPI.Shared/"]
COPY ["ECommerceAPI.Infrastructure/ECommerceAPI.Infrastructure.csproj", "ECommerceAPI.Infrastructure/"]
COPY ["ECommerceAPI.Persistence/ECommerceAPI.Persistence.csproj", "ECommerceAPI.Persistence/"]
RUN dotnet restore "ECommerceAPI.Presentation/ECommerceAPI.Presentation.csproj"

# Copy the remaining source code and build the app
COPY . .
WORKDIR "/src/ECommerceAPI.Presentation"
RUN dotnet build "./ECommerceAPI.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app to the /app/publish directory
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerceAPI.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Copy the published app to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ECommerceAPI.Presentation.dll"]
