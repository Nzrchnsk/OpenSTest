migration dotnet: ef migrations add Initial --context ordercontext -p ../Infrastructure/Infrastructure.csproj -s WebApi.csproj -o Data/Migrations

update database: dotnet ef database update -c ordercontext -p ../Infrastructure/Infrastructure.csproj -s WebApi.csproj

