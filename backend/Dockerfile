FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
EXPOSE 80
# ENV ASPNETCORE_URLS=http://*:80

# Copy everything
COPY ./ ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN cd Backend.Infrastructure/ && dotnet publish -c Release -o /App/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Backend.Infrastructure.dll"]