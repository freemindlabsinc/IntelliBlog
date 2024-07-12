del Data\Migrations\*.cs

dotnet ef database drop --startup-project ../API --force --context AppDbContext 

dotnet ef migrations add CreateDatabase --startup-project ../API --context AppDbContext --verbose --output-dir Data/Migrations

dotnet ef database update --startup-project ../API --context AppDbContext 

