del Data\Migrations\*.cs

dotnet ef database drop --startup-project ../GraphQL --force --context AppDbContext 

dotnet ef migrations add CreateDatabase --startup-project ../GraphQL --context AppDbContext --verbose --output-dir Data/Migrations

dotnet ef database update --startup-project ../GraphQL --context AppDbContext 

