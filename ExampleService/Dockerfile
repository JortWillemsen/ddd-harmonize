FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./obj/docker/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ExampleService.dll"]