del Data\Migrations\*.cs

dotnet ef database drop --startup-project ../IntelliBlog.API --force --context AppDbContext 

dotnet ef migrations add CreateDatabase --startup-project ../IntelliBlog.API --context AppDbContext --verbose --output-dir Data/Migrations

dotnet ef database update --startup-project ../IntelliBlog.API --context AppDbContext 

