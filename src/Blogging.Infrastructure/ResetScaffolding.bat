del Data\Migrations\*.cs

dotnet ef database drop --startup-project ../API --force --context BloggingDbContext 

dotnet ef migrations add CreateDatabase --startup-project ../API --context BloggingDbContext --verbose --output-dir Data/Migrations

dotnet ef database update --startup-project ../API --context BloggingDbContext 

