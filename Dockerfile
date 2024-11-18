# Use the official .NET image as a base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ledra.Api/Ledra.Api.csproj", "Ledra.Api/"]
COPY ["Ledra.Dal/Ledra.Dal.csproj", "Ledra.Dal/"]
COPY ["Ledra.Domain/Ledra.Domain.csproj", "Ledra.Domain/"]
COPY ["Ledra.Services/Ledra.Services.csproj", "Ledra.Services/"]
RUN dotnet restore "Ledra.Api/Ledra.Api.csproj"

# Copy the rest of the application code and build it
COPY . .
WORKDIR "/src/Ledra.Api"
RUN dotnet build "Ledra.Api.csproj" -c Release -o /app/build

# Publish the application for release
FROM build AS publish
RUN dotnet publish "Ledra.Api.csproj" -c Release -o /app/publish

# Final image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ledra.Api.dll"]
